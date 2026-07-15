using UnityEditor;
using UnityEngine;

namespace FragmentosDoAmanha.Editor
{
    public static class TheoSpriteSetup
    {
        private const string SpritePath = "Assets/Art/Characters/Theo/theo-sprite-v02.png";

        // With the camera's orthographicSize of 5 (10 world units tall visible
        // area), this puts Theo at ~24% of screen height -- between Symphony of
        // the Night's ~20% (320x224, sprite ~46px) and Guacamelee's ~28-30%
        // (rough estimates, not pixel-verified against the actual games).
        internal const float TargetWorldHeight = 2.4f;

        [MenuItem("Fragmentos do Amanha/Import Theo Sprite")]
        public static void ImportTheoSprite()
        {
            TextureImporter importer = AssetImporter.GetAtPath(SpritePath) as TextureImporter;
            if (importer == null)
            {
                Debug.LogError($"Fragmentos do Amanha: texture not found at {SpritePath}. Make sure the file was imported by Unity first.");
                return;
            }

            Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(SpritePath);
            if (texture == null)
            {
                Debug.LogError($"Fragmentos do Amanha: could not read texture at {SpritePath}. Make sure the file was imported by Unity first (not just an LFS pointer).");
                return;
            }

            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Single;
            importer.filterMode = FilterMode.Point;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
            importer.mipmapEnabled = false;
            importer.alphaIsTransparency = true;
            importer.spritePixelsPerUnit = texture.height / TargetWorldHeight;

            EditorUtility.SetDirty(importer);
            importer.SaveAndReimport();

            Debug.Log($"Fragmentos do Amanha: Theo sprite imported at {SpritePath}, targeting ~{TargetWorldHeight} world units tall. Run 'Replace Theo Blockout With Sprite' next, then tune the height visually in Play Mode if needed.");
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
