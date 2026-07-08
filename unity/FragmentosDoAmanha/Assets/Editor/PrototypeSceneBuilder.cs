using FragmentosDoAmanha.CameraTools;
using FragmentosDoAmanha.Player;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace FragmentosDoAmanha.Editor
{
    public static class PrototypeSceneBuilder
    {
        private const string ScenePath = "Assets/Scenes/Prototype_Theo_Controller.unity";
        private const string GroundLayerName = "Ground";

        [MenuItem("Fragmentos do Amanha/Create Prototype Theo Scene")]
        public static void CreatePrototypeTheoScene()
        {
            EnsureGroundLayer();

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            scene.name = "Prototype_Theo_Controller";

            GameObject root = new GameObject("Prototype_Theo_Controller");
            GameObject environment = new GameObject("Era Zero Lab Blockout");
            environment.transform.SetParent(root.transform);

            CreateLabBackground(environment.transform);
            CreatePlatform(environment.transform, "Main Floor", new Vector2(0f, -2.6f), new Vector2(24f, 1f), new Color(0.16f, 0.19f, 0.22f));
            CreatePlatform(environment.transform, "Left Catwalk", new Vector2(-7f, 0.1f), new Vector2(5.5f, 0.35f), new Color(0.22f, 0.28f, 0.32f));
            CreatePlatform(environment.transform, "Right Catwalk", new Vector2(6.8f, 1.15f), new Vector2(6f, 0.35f), new Color(0.22f, 0.28f, 0.32f));
            CreatePlatform(environment.transform, "Short Step", new Vector2(0.5f, -1.25f), new Vector2(2.4f, 0.35f), new Color(0.24f, 0.28f, 0.29f));
            CreateTemporalMachine(environment.transform);
            CreateVossMonitor(environment.transform);

            GameObject theo = CreateTheo(new Vector2(-9f, -1.5f));
            theo.transform.SetParent(root.transform);

            GameObject mainCamera = CreateCamera(theo.transform);
            mainCamera.transform.SetParent(root.transform);

            EditorSceneManager.SaveScene(scene, ScenePath);
            EditorBuildSettings.scenes = new[]
            {
                new EditorBuildSettingsScene(ScenePath, true)
            };
            AssetDatabase.Refresh();
            Debug.Log($"Fragmentos do Amanha: prototype scene saved at {ScenePath}");
        }

        private static GameObject CreateTheo(Vector2 position)
        {
            GameObject theo = CreateBox("Theo Placeholder", position, new Vector2(0.8f, 1.6f), new Color(0.74f, 0.36f, 0.16f), "Default");
            theo.AddComponent<BoxCollider2D>();
            Rigidbody2D body = theo.AddComponent<Rigidbody2D>();
            body.freezeRotation = true;
            body.gravityScale = 4.2f;

            GameObject groundCheck = new GameObject("Ground Check");
            groundCheck.transform.SetParent(theo.transform);
            groundCheck.transform.localPosition = new Vector3(0f, -0.86f, 0f);

            TheoController controller = theo.AddComponent<TheoController>();
            SerializedObject serializedController = new SerializedObject(controller);
            serializedController.FindProperty("groundCheck").objectReferenceValue = groundCheck.transform;
            serializedController.FindProperty("groundMask").intValue = LayerMask.GetMask(GroundLayerName);
            serializedController.ApplyModifiedPropertiesWithoutUndo();

            return theo;
        }

        private static GameObject CreateCamera(Transform target)
        {
            GameObject cameraObject = new GameObject("Prototype Camera");
            Camera camera = cameraObject.AddComponent<Camera>();
            camera.orthographic = true;
            camera.orthographicSize = 5f;
            camera.backgroundColor = new Color(0.03f, 0.05f, 0.07f);
            camera.clearFlags = CameraClearFlags.SolidColor;

            CameraFollow2D follow = cameraObject.AddComponent<CameraFollow2D>();
            follow.SetTarget(target);
            cameraObject.transform.position = new Vector3(target.position.x, target.position.y + 1.25f, -10f);
            return cameraObject;
        }

        private static void CreateLabBackground(Transform parent)
        {
            CreateBox("Back Wall", new Vector2(0f, 0f), new Vector2(26f, 8f), new Color(0.08f, 0.12f, 0.15f), "Default").transform.SetParent(parent);
            CreateBox("Cold Light Strip", new Vector2(-4.5f, 2.75f), new Vector2(5.5f, 0.15f), new Color(0.35f, 0.9f, 1f), "Default").transform.SetParent(parent);
            CreateBox("Cold Light Strip Right", new Vector2(6f, 3.15f), new Vector2(4.8f, 0.15f), new Color(0.35f, 0.9f, 1f), "Default").transform.SetParent(parent);
            CreateBox("Server Rack A", new Vector2(-10f, -0.35f), new Vector2(1.4f, 3.6f), new Color(0.1f, 0.13f, 0.15f), "Default").transform.SetParent(parent);
            CreateBox("Server Rack B", new Vector2(10f, -0.1f), new Vector2(1.6f, 4f), new Color(0.1f, 0.13f, 0.15f), "Default").transform.SetParent(parent);
        }

        private static void CreateTemporalMachine(Transform parent)
        {
            CreateBox("Temporal Machine Core", new Vector2(0f, 0.55f), new Vector2(1.6f, 2.6f), new Color(0.35f, 0.23f, 0.13f), "Default").transform.SetParent(parent);
            CreateBox("Temporal Machine Glow", new Vector2(0f, 0.55f), new Vector2(0.75f, 0.75f), new Color(1f, 0.48f, 0.12f), "Default").transform.SetParent(parent);
            CreateBox("Temporal Machine Base", new Vector2(0f, -0.95f), new Vector2(3f, 0.45f), new Color(0.18f, 0.18f, 0.18f), "Default").transform.SetParent(parent);
        }

        private static void CreateVossMonitor(Transform parent)
        {
            CreateBox("Voss Monitor", new Vector2(7.2f, -0.25f), new Vector2(2.2f, 1.25f), new Color(0.05f, 0.28f, 0.34f), "Default").transform.SetParent(parent);
            CreateBox("Voss Portrait Signal", new Vector2(7.2f, -0.2f), new Vector2(0.62f, 0.82f), new Color(0.06f, 0.06f, 0.07f), "Default").transform.SetParent(parent);
        }

        private static GameObject CreatePlatform(Transform parent, string name, Vector2 position, Vector2 size, Color color)
        {
            GameObject platform = CreateBox(name, position, size, color, GroundLayerName);
            platform.AddComponent<BoxCollider2D>();
            platform.transform.SetParent(parent);
            return platform;
        }

        private static GameObject CreateBox(string name, Vector2 position, Vector2 size, Color color, string layerName)
        {
            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.name = name;
            box.transform.position = new Vector3(position.x, position.y, 0f);
            box.transform.localScale = new Vector3(size.x, size.y, 0.2f);
            Object.DestroyImmediate(box.GetComponent<BoxCollider>());
            int layer = LayerMask.NameToLayer(layerName);
            box.layer = layer >= 0 ? layer : 0;

            var renderer = box.GetComponent<MeshRenderer>();
            renderer.sharedMaterial = new Material(Shader.Find("Sprites/Default"))
            {
                color = color
            };

            return box;
        }

        private static void EnsureGroundLayer()
        {
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            SerializedProperty layers = tagManager.FindProperty("layers");

            for (int i = 0; i < layers.arraySize; i++)
            {
                SerializedProperty layer = layers.GetArrayElementAtIndex(i);
                if (layer.stringValue == GroundLayerName)
                {
                    return;
                }
            }

            for (int i = 8; i < layers.arraySize; i++)
            {
                SerializedProperty layer = layers.GetArrayElementAtIndex(i);
                if (string.IsNullOrEmpty(layer.stringValue))
                {
                    layer.stringValue = GroundLayerName;
                    tagManager.ApplyModifiedProperties();
                    return;
                }
            }

            Debug.LogWarning("Fragmentos do Amanha: no empty user layer slot available for Ground.");
        }
    }
}
