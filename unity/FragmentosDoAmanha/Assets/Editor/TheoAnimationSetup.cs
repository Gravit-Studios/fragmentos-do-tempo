using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace FragmentosDoAmanha.Editor
{
    public static class TheoAnimationSetup
    {
        private const string IdleFramesFolder = "Assets/Art/Characters/Theo/Idle";
        private const string RunFramesFolder = "Assets/Art/Characters/Theo/Run";
        private const string JumpFramesFolder = "Assets/Art/Characters/Theo/Jump";
        private const string AnimationOutputFolder = "Assets/Animations/Theo";
        private const string ControllerPath = AnimationOutputFolder + "/Theo.controller";
        private const float IdleFrameRate = 6f;
        private const float RunFrameRate = 10f;
        private const float RunToIdleThreshold = 0.05f;

        // Single non-looping clip covering the whole airborne arc (takeoff
        // crouch -> rise -> apex -> fall -> landing reach/crouch), since there
        // is no separate Fall art yet. 6 frames over ~0.6s; if Theo is airborne
        // longer than that (e.g. off a tall ledge), the animator just holds on
        // the last (landing-crouch) frame until Grounded flips back to true --
        // acceptable placeholder behavior, revisit once Fall/Land art exists.
        private const float JumpFrameRate = 10f;

        [MenuItem("Fragmentos do Amanha/Import Theo Jump Frames")]
        public static void ImportJumpFrames()
        {
            string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { JumpFramesFolder });
            if (guids.Length == 0)
            {
                Debug.LogError($"Fragmentos do Amanha: no textures found in {JumpFramesFolder}.");
                return;
            }

            int imported = 0;
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
                if (importer == null)
                {
                    Debug.LogWarning($"Fragmentos do Amanha: could not read texture at {path}, skipping (LFS pointer not pulled?).");
                    continue;
                }

                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Single;
                importer.filterMode = FilterMode.Point;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.mipmapEnabled = false;
                importer.alphaIsTransparency = true;
                // Same 1024px canvas / character scale as idle+run, but the
                // foot line is NOT realigned to y=987 here: each jump frame's
                // foot height within the canvas represents how high off the
                // ground Theo actually is at that phase of the arc.
                importer.spritePixelsPerUnit = TheoSpriteSetup.IdleSpritePixelsPerUnit;
                EditorUtility.SetDirty(importer);
                importer.SaveAndReimport();
                imported++;
            }

            Debug.Log($"Fragmentos do Amanha: imported {imported} jump frame(s) from {JumpFramesFolder} at the same scale as the idle sprite.");
        }

        [MenuItem("Fragmentos do Amanha/Import Theo Run Frames")]
        public static void ImportRunFrames()
        {
            string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { RunFramesFolder });
            if (guids.Length == 0)
            {
                Debug.LogError($"Fragmentos do Amanha: no textures found in {RunFramesFolder}.");
                return;
            }

            int imported = 0;
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
                if (importer == null)
                {
                    Debug.LogWarning($"Fragmentos do Amanha: could not read texture at {path}, skipping (LFS pointer not pulled?).");
                    continue;
                }

                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Single;
                importer.filterMode = FilterMode.Point;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.mipmapEnabled = false;
                importer.alphaIsTransparency = true;
                // The run frames were re-composited (see normalize_run_frames.py)
                // to share the idle sprite's exact character scale and foot
                // line within the same 1536px canvas height, so they use the
                // same measured PPU constant.
                importer.spritePixelsPerUnit = TheoSpriteSetup.IdleSpritePixelsPerUnit;
                EditorUtility.SetDirty(importer);
                importer.SaveAndReimport();
                imported++;
            }

            Debug.Log($"Fragmentos do Amanha: imported {imported} run frame(s) from {RunFramesFolder} at the same scale as the idle sprite.");
        }

        [MenuItem("Fragmentos do Amanha/Build Theo Animator Controller")]
        public static void BuildAnimatorController()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Animations"))
            {
                AssetDatabase.CreateFolder("Assets", "Animations");
            }

            if (!AssetDatabase.IsValidFolder(AnimationOutputFolder))
            {
                AssetDatabase.CreateFolder("Assets/Animations", "Theo");
            }

            Sprite[] idleSprites = AssetDatabase.FindAssets("t:Texture2D", new[] { IdleFramesFolder })
                .Select(AssetDatabase.GUIDToAssetPath)
                .Distinct()
                .OrderBy(path => path)
                .Select(AssetDatabase.LoadAssetAtPath<Sprite>)
                .Where(sprite => sprite != null)
                .ToArray();

            if (idleSprites.Length == 0)
            {
                Debug.LogError($"Fragmentos do Amanha: no sprites found in {IdleFramesFolder}. Run 'Import Theo Sprite' first.");
                return;
            }

            Sprite[] runSprites = AssetDatabase.FindAssets("t:Texture2D", new[] { RunFramesFolder })
                .Select(AssetDatabase.GUIDToAssetPath)
                .Distinct()
                .OrderBy(path => path)
                .Select(AssetDatabase.LoadAssetAtPath<Sprite>)
                .Where(sprite => sprite != null)
                .ToArray();

            if (runSprites.Length == 0)
            {
                Debug.LogError($"Fragmentos do Amanha: no sprites found in {RunFramesFolder}. Run 'Import Theo Run Frames' first.");
                return;
            }

            Sprite[] jumpSprites = AssetDatabase.FindAssets("t:Texture2D", new[] { JumpFramesFolder })
                .Select(AssetDatabase.GUIDToAssetPath)
                .Distinct()
                .OrderBy(path => path)
                .Select(AssetDatabase.LoadAssetAtPath<Sprite>)
                .Where(sprite => sprite != null)
                .ToArray();

            AnimationClip idleClip = CreateClip("Theo_Idle", idleSprites, IdleFrameRate, AnimationOutputFolder);
            AnimationClip runClip = CreateClip("Theo_Run", runSprites, RunFrameRate, AnimationOutputFolder);
            AnimationClip jumpClip = jumpSprites.Length > 0
                ? CreateClip("Theo_Jump", jumpSprites, JumpFrameRate, AnimationOutputFolder, loop: false)
                : null;

            AnimatorController controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(ControllerPath);
            if (controller == null)
            {
                controller = AnimatorController.CreateAnimatorControllerAtPath(ControllerPath);
            }

            if (controller.parameters.All(p => p.name != "Speed"))
            {
                controller.AddParameter("Speed", AnimatorControllerParameterType.Float);
            }

            // Grounded/VerticalSpeed are set by TheoController every frame.
            // Grounded now drives the Jump state below; VerticalSpeed is still
            // unused (no separate Fall/Land art yet), declared so
            // TheoController.UpdateVisual() never hits a "no parameter" warning.
            if (controller.parameters.All(p => p.name != "Grounded"))
            {
                controller.AddParameter("Grounded", AnimatorControllerParameterType.Bool);
            }

            if (controller.parameters.All(p => p.name != "VerticalSpeed"))
            {
                controller.AddParameter("VerticalSpeed", AnimatorControllerParameterType.Float);
            }

            AnimatorStateMachine stateMachine = controller.layers[0].stateMachine;
            AnimatorState idleState = FindOrAddState(stateMachine, "Idle", idleClip);
            AnimatorState runState = FindOrAddState(stateMachine, "Run", runClip);
            stateMachine.defaultState = idleState;

            EnsureTransition(idleState, runState, "Speed", AnimatorConditionMode.Greater, RunToIdleThreshold);
            EnsureTransition(runState, idleState, "Speed", AnimatorConditionMode.Less, RunToIdleThreshold);

            string jumpStatus;
            if (jumpClip != null)
            {
                AnimatorState jumpState = FindOrAddState(stateMachine, "Jump", jumpClip);
                EnsureTransition(idleState, jumpState, "Grounded", AnimatorConditionMode.IfNot, 0f);
                EnsureTransition(runState, jumpState, "Grounded", AnimatorConditionMode.IfNot, 0f);
                EnsureTransition(jumpState, idleState, "Grounded", AnimatorConditionMode.If, 0f);
                jumpStatus = $" and {jumpSprites.Length} jump frame(s)";
            }
            else
            {
                jumpStatus = " (no jump frames found, Jump state not built -- run 'Import Theo Jump Frames' first if you have art for it)";
            }

            EditorUtility.SetDirty(controller);
            AssetDatabase.SaveAssets();
            Debug.Log($"Fragmentos do Amanha: Theo animator controller built at {ControllerPath} with {idleSprites.Length} idle frame(s) and {runSprites.Length} run frame(s){jumpStatus}. Run 'Apply Theo Animator (Current Scene)' next.");
        }

        [MenuItem("Fragmentos do Amanha/Apply Theo Animator (Current Scene)")]
        public static void ApplyAnimatorToScene()
        {
            GameObject theo = GameObject.Find("Theo Placeholder");
            if (theo == null)
            {
                Debug.LogError("Fragmentos do Amanha: no 'Theo Placeholder' GameObject found in the open scene.");
                return;
            }

            Transform visual = theo.transform.Find("Theo Sprite");
            if (visual == null)
            {
                Debug.LogError("Fragmentos do Amanha: no 'Theo Sprite' child found. Run 'Replace Theo Blockout With Sprite' first.");
                return;
            }

            AnimatorController controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(ControllerPath);
            if (controller == null)
            {
                Debug.LogError($"Fragmentos do Amanha: no animator controller found at {ControllerPath}. Run 'Build Theo Animator Controller' first.");
                return;
            }

            Animator animator = visual.GetComponent<Animator>();
            if (animator == null)
            {
                animator = visual.gameObject.AddComponent<Animator>();
            }

            animator.runtimeAnimatorController = controller;
            EditorUtility.SetDirty(visual.gameObject);
            Debug.Log("Fragmentos do Amanha: Animator applied to 'Theo Sprite' in the open scene. Save the scene and test in Play Mode.");
        }

        private static AnimationClip CreateClip(string name, Sprite[] sprites, float frameRate, string folder, bool loop = true)
        {
            string path = $"{folder}/{name}.anim";
            AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(path);
            if (clip == null)
            {
                clip = new AnimationClip();
                AssetDatabase.CreateAsset(clip, path);
            }
            else
            {
                clip.ClearCurves();
            }

            clip.frameRate = frameRate;
            EditorCurveBinding binding = new EditorCurveBinding
            {
                type = typeof(SpriteRenderer),
                path = string.Empty,
                propertyName = "m_Sprite"
            };

            ObjectReferenceKeyframe[] keyframes = new ObjectReferenceKeyframe[sprites.Length];
            for (int i = 0; i < sprites.Length; i++)
            {
                keyframes[i] = new ObjectReferenceKeyframe { time = i / frameRate, value = sprites[i] };
            }

            AnimationUtility.SetObjectReferenceCurve(clip, binding, keyframes);

            AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(clip);
            settings.loopTime = loop;
            AnimationUtility.SetAnimationClipSettings(clip, settings);

            EditorUtility.SetDirty(clip);
            return clip;
        }

        private static AnimatorState FindOrAddState(AnimatorStateMachine stateMachine, string name, AnimationClip clip)
        {
            AnimatorState existing = stateMachine.states.Select(s => s.state).FirstOrDefault(s => s.name == name);
            if (existing != null)
            {
                existing.motion = clip;
                return existing;
            }

            AnimatorState state = stateMachine.AddState(name);
            state.motion = clip;
            return state;
        }

        private static void EnsureTransition(AnimatorState from, AnimatorState to, string parameter, AnimatorConditionMode mode, float threshold)
        {
            if (from.transitions.Any(t => t.destinationState == to))
            {
                return;
            }

            AnimatorStateTransition transition = from.AddTransition(to);
            transition.hasExitTime = false;
            transition.duration = 0.05f;
            transition.AddCondition(mode, threshold, parameter);
        }
    }
}