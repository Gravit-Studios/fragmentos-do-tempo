using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace FragmentosDoAmanha.Editor
{
    public static class TilesetImportSetup
    {
        private const float SpritePixelsPerUnit = 32f;
        private static readonly string[] QuadrantNames = { "Ground", "Platform", "Wall", "Border" };

        [MenuItem("Fragmentos do Amanha/Slice Era Zero Core Tiles")]
        public static void SliceEraZeroCoreTiles()
        {
            SliceCoreTileSheet(
                "Assets/Art/Tilesets/EraZero/era-zero-lab-tiles-core-v02.png",
                "Assets/Art/Tilesets/EraZero/Tiles",
                "EraZero");
        }

        [MenuItem("Fragmentos do Amanha/Slice Egypt Core Tiles")]
        public static void SliceEgyptCoreTiles()
        {
            SliceCoreTileSheet(
                "Assets/Art/Tilesets/Egypt/egypt-temple-tiles-core-v02.png",
                "Assets/Art/Tilesets/Egypt/Tiles",
                "Egypt");
        }

        private static void SliceCoreTileSheet(string texturePath, string tilesFolder, string namePrefix)
        {
            TextureImporter importer = AssetImporter.GetAtPath(texturePath) as TextureImporter;
            if (importer == null)
            {
                Debug.LogError($"Fragmentos do Amanha: texture not found at {texturePath}. Make sure the file was imported by Unity first.");
                return;
            }

            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Multiple;
            importer.filterMode = FilterMode.Point;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
            importer.mipmapEnabled = false;
            importer.alphaIsTransparency = true;
            importer.spritePixelsPerUnit = SpritePixelsPerUnit;

            Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
            float halfWidth = texture.width * 0.5f;
            float halfHeight = texture.height * 0.5f;

            Rect[] quadrantRects =
            {
                new Rect(0f, halfHeight, halfWidth, halfHeight),
                new Rect(halfWidth, halfHeight, halfWidth, halfHeight),
                new Rect(0f, 0f, halfWidth, halfHeight),
                new Rect(halfWidth, 0f, halfWidth, halfHeight)
            };

            var metas = new List<SpriteMetaData>();
            for (int i = 0; i < QuadrantNames.Length; i++)
            {
                metas.Add(new SpriteMetaData
                {
                    name = $"{namePrefix}_{QuadrantNames[i]}",
                    rect = quadrantRects[i],
                    alignment = (int)SpriteAlignment.Center,
                    pivot = new Vector2(0.5f, 0.5f)
                });
            }

            importer.spritesheet = metas.ToArray();
            EditorUtility.SetDirty(importer);
            importer.SaveAndReimport();

            CreateTileAssets(texturePath, tilesFolder, namePrefix);
        }

        private static void CreateTileAssets(string texturePath, string tilesFolder, string namePrefix)
        {
            EnsureFolder(tilesFolder);

            var spritesByName = new Dictionary<string, Sprite>();
            foreach (Object asset in AssetDatabase.LoadAllAssetsAtPath(texturePath))
            {
                if (asset is Sprite sprite)
                {
                    spritesByName[sprite.name] = sprite;
                }
            }

            foreach (string quadrantName in QuadrantNames)
            {
                string spriteName = $"{namePrefix}_{quadrantName}";
                if (!spritesByName.TryGetValue(spriteName, out Sprite sprite))
                {
                    Debug.LogWarning($"Fragmentos do Amanha: sprite {spriteName} not found after slicing {texturePath}.");
                    continue;
                }

                string tileAssetPath = $"{tilesFolder}/{spriteName}.asset";
                Tile tile = AssetDatabase.LoadAssetAtPath<Tile>(tileAssetPath);
                if (tile == null)
                {
                    tile = ScriptableObject.CreateInstance<Tile>();
                    AssetDatabase.CreateAsset(tile, tileAssetPath);
                }

                tile.sprite = sprite;
                tile.colliderType = Tile.ColliderType.None;
                EditorUtility.SetDirty(tile);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"Fragmentos do Amanha: tiles ready in {tilesFolder}. Create a Tile Palette (Window > 2D > Tile Palette > Create New Palette) and drag these tiles into it.");
        }

        private static void EnsureFolder(string folderPath)
        {
            if (AssetDatabase.IsValidFolder(folderPath))
            {
                return;
            }

            string parentFolder = Path.GetDirectoryName(folderPath)?.Replace("\\", "/");
            string newFolderName = Path.GetFileName(folderPath);
            AssetDatabase.CreateFolder(parentFolder, newFolderName);
        }
    }
}
