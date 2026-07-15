using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace FragmentosDoAmanha.Editor
{
    public static class TheoAnimationSetup
    {
        private const string IdleSpritePath = "Assets/Art/Characters/Theo/theo-sprite-v02.png";
        private const string RunFramesFolder = "Assets/Art/Characters/Theo/Run";
        private const string AnimationOutputFolder = "Assets/Animations/Theo";
        private const string ControllerPath = AnimationOutputFolder + "/Theo.controller";
        private const float RunFrameRate = 10f;
        private const float RunToIdleThreshold = 0.05f;

        // The run frames' character silhouette only fills ~475-567px of their
        // 1536px canvas (average ~532px, measured via PIL) -- much smaller a
        // proportion than the idle sprite (~1049px), so using canvas height
        // for PPU made Theo shrink noticeably while running. Measured/
        // hardcoded per asset; re-measure if the art is regenerated.
        // 532 / TheoSpriteSetup.TargetWorldHeight.
        private const float RunFramePixelsPerUnit = 221.6f;

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
                importer.spritePixelsPerUnit = RunFramePixelsPerUnit;
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

            Sprite idleSprite = AssetDatabase.LoadAssetAtPath<Sprite>(IdleSpritePath);
            if (idleSprite == null)
            {
                Debug.LogError($"Fragmentos do Amanha: idle sprite not found at {IdleSpritePath}. Run 'Import Theo Sprite' first.");
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

            AnimationClip idleClip = CreateClip("Theo_Idle", new[] { idleSprite }, 1f, AnimationOutputFolder);
            AnimationClip runClip = CreateClip("Theo_Run", runSprites, RunFrameRate, AnimationOutputFolder);

            AnimatorController controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(ControllerPath);
            if (controller == null)
            {
                controller = AnimatorController.CreateAnimatorControllerAtPath(ControllerPath);
            }

            if (controller.parameters.All(p => p.name != "Speed"))
            {
                controller.AddParameter("Speed", AnimatorControllerParameterType.Float);
            }

            AnimatorStateMachine stateMachine = controller.layers[0].stateMachine;
            AnimatorState idleState = FindOrAddState(stateMachine, "Idle", idleClip);
            AnimatorState runState = FindOrAddState(stateMachine, "Run", runClip);
            stateMachine.defaultState = idleState;

            EnsureTransition(idleState, runState, "Speed", AnimatorConditionMode.Greater, RunToIdleThreshold);
            EnsureTransition(runState, idleState, "Speed", AnimatorConditionMode.Less, RunToIdleThreshold);

            EditorUtility.SetDirty(controller);
            AssetDatabase.SaveAssets();
            Debug.Log($"Fragmentos do Amanha: Theo animator controller built at {ControllerPath} with {runSprites.Length} run frame(s). Run 'Apply Theo Animator (Current Scene)' next.");
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

        private static AnimationClip CreateClip(string name, Sprite[] sprites, float frameRate, string folder)
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
            settings.loopTime = true;
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
