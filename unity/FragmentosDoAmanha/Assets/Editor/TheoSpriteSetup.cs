using UnityEditor;
using UnityEngine;

namespace FragmentosDoAmanha.Editor
{
    public static class TheoSpriteSetup
    {
        private const string IdleFramesFolder = "Assets/Art/Characters/Theo/Idle";

        // Representative frame used for the static blockout replacement
        // (before the Animator takes over) and as the PPU measurement
        // reference for the whole idle+run set below.
        private const string SpritePath = IdleFramesFolder + "/theo-sprite-idle-01.png";

        // With the camera's orthographicSize of 5 (10 world units tall visible
        // area), this puts Theo at ~24% of screen height -- between Symphony of
        // the Night's ~20% (320x224, sprite ~46px) and Guacamelee's ~28-30%
        // (rough estimates, not pixel-verified against the actual games).
        internal const float TargetWorldHeight = 2.4f;

        // Hand-crafted in Photoshop (v04 style, superseding the AI-generated
        // v03 set): fixed 1024x1024 canvas across every pose, character foot
        // line locked to canvas y=987 (idle's own average; the run frames
        // were shifted with tools/art-pipeline/align_foot_line.py to match).
        // theo-sprite-idle-01.png's character silhouette measures 947px tall
        // (PIL alpha bbox, min>40). PPU can't be derived from canvas height
        // alone -- this is measured/hardcoded per asset; re-measure if the
        // idle art is redrawn. 947 / TargetWorldHeight.
        internal const float IdleSpritePixelsPerUnit = 394.58f;

        [MenuItem("Fragmentos do Amanha/Import Theo Sprite")]
        public static void ImportTheoSprite()
        {
            string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { IdleFramesFolder });
            if (guids.Length == 0)
            {
                Debug.LogError($"Fragmentos do Amanha: no textures found in {IdleFramesFolder}.");
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
                importer.spritePixelsPerUnit = IdleSpritePixelsPerUnit;
                EditorUtility.SetDirty(importer);
                importer.SaveAndReimport();
                imported++;
            }

            Debug.Log($"Fragmentos do Amanha: imported {imported} idle frame(s) from {IdleFramesFolder}, targeting ~{TargetWorldHeight} world units tall. Run 'Replace Theo Blockout With Sprite' next, then tune the height visually in Play Mode if needed.");
        }

        [MenuItem("Fragmentos do Amanha/Replace Theo Blockout With Sprite (Current Scene)")]
        public static void ReplaceTheoBlockoutWithSprite()
        {
            GameObject theo = GameObject.Find("Theo Placeholder");
            if (theo == null)
            {
                Debug.LogError("Fragmentos do Amanha: no 'Theo Placeholder' GameObject found in the open scene.");
                return;
            }

            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(SpritePath);
            if (sprite == null)
            {
                Debug.LogError($"Fragmentos do Amanha: no Sprite found at {SpritePath}. Run 'Import Theo Sprite' first.");
                return;
            }

            Transform[] children = theo.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in children)
            {
                if (child == theo.transform || !child.name.StartsWith("Theo "))
                {
                    continue;
                }

                Object.DestroyImmediate(child.gameObject);
            }

            SpriteRenderer existingOnRoot = theo.GetComponent<SpriteRenderer>();
            if (existingOnRoot != null)
            {
                Object.DestroyImmediate(existingOnRoot);
            }

            Transform visualTransform = theo.transform.Find("Theo Sprite");
            GameObject visual = visualTransform != null ? visualTransform.gameObject : new GameObject("Theo Sprite");
            visual.transform.SetParent(theo.transform);
            visual.transform.localPosition = Vector3.zero;
            Vector3 parentScale = theo.transform.localScale;
            visual.transform.localScale = new Vector3(1f / parentScale.x, 1f / parentScale.y, 1f / parentScale.z);

            SpriteRenderer spriteRenderer = visual.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = visual.AddComponent<SpriteRenderer>();
            }

            spriteRenderer.sprite = sprite;
            EditorUtility.SetDirty(theo);
            Debug.Log("Fragmentos do Amanha: Theo blockout replaced with sprite in the current scene. Remember to save the scene, then tune scale/position in Play Mode if needed.");
        }
    }
}
