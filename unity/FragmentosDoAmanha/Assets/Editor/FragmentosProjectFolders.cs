using System.IO;
using UnityEditor;
using UnityEngine;

namespace FragmentosDoAmanha.Editor
{
    public static class FragmentosProjectFolders
    {
        [MenuItem("Fragmentos do Amanha/Create Base Folders")]
        public static void CreateBaseFolders()
        {
            string[] folders =
            {
                "Assets/Art/Characters",
                "Assets/Art/Environments",
                "Assets/Art/Tilesets",
                "Assets/Art/UI",
                "Assets/Art/FX",
                "Assets/Audio",
                "Assets/Data/Characters",
                "Assets/Data/Weapons",
                "Assets/Data/Abilities",
                "Assets/Data/Enemies",
                "Assets/Gameplay",
                "Assets/Prefabs",
                "Assets/Resources",
                "Assets/Scenes",
                "Assets/Scripts/Core",
                "Assets/Scripts/Player",
                "Assets/Scripts/Combat",
                "Assets/Scripts/Enemies",
                "Assets/Scripts/Camera",
                "Assets/Scripts/UI",
                "Assets/Scripts/Systems",
                "Assets/Settings"
            };

            foreach (string folder in folders)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }

            EditorSettings.serializationMode = SerializationMode.ForceText;
            AssetDatabase.Refresh();
            Debug.Log("Fragmentos do Amanha: base folders created.");
        }
    }
}
