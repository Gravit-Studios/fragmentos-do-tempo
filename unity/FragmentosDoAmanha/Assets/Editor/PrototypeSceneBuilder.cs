using System.Linq;
using FragmentosDoAmanha.CameraTools;
using FragmentosDoAmanha.Combat;
using FragmentosDoAmanha.Enemies;
using FragmentosDoAmanha.Player;
using FragmentosDoAmanha.Systems;
using FragmentosDoAmanha.UI;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace FragmentosDoAmanha.Editor
{
    public static class PrototypeSceneBuilder
    {
        private const string ScenePath = "Assets/Scenes/Prototype_Theo_Controller.unity";
        private const string EraZeroLabScenePath = "Assets/Scenes/VS_EraZero_Lab.unity";
        private const string TheoSpritePath = "Assets/Art/Characters/Theo/theo-sprite-v01.png";
        private const string EgyptScenePath = "Assets/Scenes/VS_Egypt_Blockout.unity";
        private const string GroundLayerName = "Ground";
        private const float BackgroundZ = 2f;
        private const float EnvironmentZ = 0f;
        private const float GameplayZ = -1f;
        private const float TopPlatformEdgeInset = 0.22f;
        private static readonly Vector2 CameraMin = new Vector2(-12.5f, -3.15f);
        private static readonly Vector2 CameraMax = new Vector2(13.5f, 3.15f);
        private static readonly PhysicsMaterial2D NoFrictionMaterial = new PhysicsMaterial2D("Prototype No Friction")
        {
            friction = 0f,
            bounciness = 0f
        };

        [MenuItem("Fragmentos do Amanha/Create Prototype Theo Scene")]
        public static void CreatePrototypeTheoScene()
        {
            BuildScene(ScenePath, "Prototype_Theo_Controller");
        }

        [MenuItem("Fragmentos do Amanha/Create VS Era Zero Lab Scene")]
        public static void CreateEraZeroLabScene()
        {
            BuildScene(EraZeroLabScenePath, "VS_EraZero_Lab");
        }

        private static void BuildScene(string scenePath, string sceneName)
        {
            EnsureGroundLayer();

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            scene.name = sceneName;

            GameObject root = new GameObject(sceneName);
            PrototypeObjectiveState objectiveState = root.AddComponent<PrototypeObjectiveState>();
            GameObject environment = new GameObject("Era Zero Lab Blockout");
            environment.transform.SetParent(root.transform);

            CreateLabBackground(environment.transform);
            CreateVerticalSliceRoom(environment.transform, objectiveState);
            CreateTemporalMachine(environment.transform);
            CreateVossMonitor(environment.transform);
            CreateDamageZone(environment.transform);
            CreateFallRespawnZone(environment.transform);
            CreatePrototypeEnemy(environment.transform);
            CreateTemporalFragment(environment.transform);

            GameObject theo = CreateTheo(new Vector2(-9f, -1.5f));
            theo.transform.SetParent(root.transform);
            objectiveState.SetInventory(theo.GetComponent<FragmentInventory>());

            GameObject mainCamera = CreateCamera(theo.transform);
            mainCamera.transform.SetParent(root.transform);

            GameObject hud = CreatePrototypeHud(theo.GetComponent<PlayerHealth>(), theo.GetComponent<FragmentInventory>(), objectiveState);
            hud.transform.SetParent(root.transform);

            EditorSceneManager.SaveScene(scene, scenePath);
            AddSceneToBuildSettings(scenePath);
            AddSceneToBuildSettings(EgyptScenePath);
            AssetDatabase.Refresh();
            Debug.Log($"Fragmentos do Amanha: scene saved at {scenePath}");
        }

        private static void AddSceneToBuildSettings(string scenePath)
        {
            var scenes = EditorBuildSettings.scenes.ToList();
            if (scenes.Any(existing => existing.path == scenePath))
            {
                return;
            }

            scenes.Add(new EditorBuildSettingsScene(scenePath, true));
            EditorBuildSettings.scenes = scenes.ToArray();
        }

        private static GameObject CreateTheo(Vector2 position)
        {
            GameObject theo = CreateBox("Theo Placeholder", position, new Vector2(0.8f, 1.6f), new Color(1f, 0.72f, 0.22f), "Default", GameplayZ);
            Object.DestroyImmediate(theo.GetComponent<MeshRenderer>());
            Object.DestroyImmediate(theo.GetComponent<MeshFilter>());
            CapsuleCollider2D theoCollider = theo.AddComponent<CapsuleCollider2D>();
            theoCollider.direction = CapsuleDirection2D.Vertical;
            theoCollider.size = new Vector2(0.68f, 1.52f);
            theoCollider.sharedMaterial = NoFrictionMaterial;
            Rigidbody2D body = theo.AddComponent<Rigidbody2D>();
            body.freezeRotation = true;
            body.gravityScale = 4.2f;
            body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            TheoController controller = theo.AddComponent<TheoController>();
            SerializedObject serializedController = new SerializedObject(controller);
            serializedController.FindProperty("groundMask").intValue = LayerMask.GetMask(GroundLayerName);
            serializedController.ApplyModifiedPropertiesWithoutUndo();

            theo.AddComponent<PlayerHealth>();
            theo.AddComponent<FragmentInventory>();
            PlayerAttack attack = theo.AddComponent<PlayerAttack>();
            GameObject hitboxPreview = CreateBox("Attack Hitbox Preview", new Vector2(position.x + 0.85f, position.y + 0.05f), new Vector2(1.15f, 0.85f), new Color(1f, 0.72f, 0.22f, 0.55f), "Default", GameplayZ);
            hitboxPreview.transform.SetParent(theo.transform);
            Object.DestroyImmediate(hitboxPreview.GetComponent<MeshCollider>());
            SerializedObject serializedAttack = new SerializedObject(attack);
            serializedAttack.FindProperty("hitboxPreview").objectReferenceValue = hitboxPreview.transform;
            serializedAttack.ApplyModifiedPropertiesWithoutUndo();
            hitboxPreview.SetActive(false);

            CreateTheoVisual(theo.transform);
            return theo;
        }

        private static void CreateTheoVisual(Transform parent)
        {
            Sprite theoSprite = AssetDatabase.LoadAssetAtPath<Sprite>(TheoSpritePath);
            if (theoSprite != null)
            {
                SpriteRenderer spriteRenderer = parent.gameObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = theoSprite;
                return;
            }

            CreateTheoBlockoutVisual(parent);
        }

        private static void CreateTheoBlockoutVisual(Transform parent)
        {
            Color jacket = new Color(0.82f, 0.36f, 0.14f);
            Color undersuit = new Color(0.05f, 0.22f, 0.25f);
            Color skin = new Color(0.86f, 0.58f, 0.39f);
            Color dark = new Color(0.03f, 0.04f, 0.05f);
            Color copperGlow = new Color(1f, 0.55f, 0.12f);
            Color lensGlow = new Color(0.35f, 0.9f, 1f);

            CreateTheoVisualPart(parent, "Theo Undersuit", new Vector2(0f, -0.16f), new Vector2(0.48f, 0.95f), undersuit);
            CreateTheoVisualPart(parent, "Theo Jacket", new Vector2(-0.03f, -0.12f), new Vector2(0.62f, 0.82f), jacket);
            CreateTheoVisualPart(parent, "Theo Asymmetric Strap", new Vector2(0.16f, 0.01f), new Vector2(0.1f, 0.74f), dark);
            CreateTheoVisualPart(parent, "Theo Head", new Vector2(0f, 0.62f), new Vector2(0.42f, 0.36f), skin);
            CreateTheoVisualPart(parent, "Theo Hair", new Vector2(0.02f, 0.82f), new Vector2(0.46f, 0.16f), dark);
            CreateTheoVisualPart(parent, "Theo Goggles", new Vector2(0.02f, 0.77f), new Vector2(0.5f, 0.08f), lensGlow);
            CreateTheoVisualPart(parent, "Theo Left Arm", new Vector2(-0.39f, -0.1f), new Vector2(0.14f, 0.72f), jacket);
            CreateTheoVisualPart(parent, "Theo Right Arm", new Vector2(0.38f, -0.09f), new Vector2(0.13f, 0.68f), undersuit);
            CreateTheoVisualPart(parent, "Theo Chronometer", new Vector2(0.46f, -0.33f), new Vector2(0.16f, 0.12f), copperGlow);
            CreateTheoVisualPart(parent, "Theo Left Leg", new Vector2(-0.16f, -0.82f), new Vector2(0.16f, 0.5f), undersuit);
            CreateTheoVisualPart(parent, "Theo Right Leg", new Vector2(0.16f, -0.8f), new Vector2(0.16f, 0.54f), undersuit);
            CreateTheoVisualPart(parent, "Theo Boots", new Vector2(0f, -1.1f), new Vector2(0.58f, 0.12f), dark);
        }

        private static GameObject CreateTheoVisualPart(Transform parent, string name, Vector2 localPosition, Vector2 size, Color color)
        {
            GameObject part = CreateBox(name, Vector2.zero, size, color, "Default", GameplayZ - 0.02f);
            part.transform.SetParent(parent);
            part.transform.localPosition = new Vector3(localPosition.x, localPosition.y, 0f);
            Object.DestroyImmediate(part.GetComponent<MeshCollider>());
            return part;
        }

        private static GameObject CreatePrototypeHud(PlayerHealth playerHealth, FragmentInventory fragmentInventory, PrototypeObjectiveState objectiveState)
        {
            GameObject hudObject = new GameObject("Prototype HUD");
            PrototypeHealthHud healthHud = hudObject.AddComponent<PrototypeHealthHud>();
            healthHud.SetPlayerHealth(playerHealth);
            PrototypeFragmentHud fragmentHud = hudObject.AddComponent<PrototypeFragmentHud>();
            fragmentHud.SetInventory(fragmentInventory);
            PrototypeObjectiveHud objectiveHud = hudObject.AddComponent<PrototypeObjectiveHud>();
            objectiveHud.SetObjectiveState(objectiveState);
            return hudObject;
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
            follow.SetBounds(CameraMin, CameraMax);
            cameraObject.transform.position = new Vector3(target.position.x, target.position.y + 1.25f, -10f);
            return cameraObject;
        }

        private static void CreateLabBackground(Transform parent)
        {
            CreateBox("Back Wall", new Vector2(2f, 0f), new Vector2(32f, 8f), new Color(0.08f, 0.12f, 0.15f), "Default", BackgroundZ).transform.SetParent(parent);
            CreateBox("Start Bay Light", new Vector2(-9.5f, 2.65f), new Vector2(4.2f, 0.15f), new Color(0.35f, 0.9f, 1f), "Default", GameplayZ).transform.SetParent(parent);
            CreateBox("Hazard Warning Light", new Vector2(-3.6f, 2.45f), new Vector2(2.4f, 0.15f), new Color(1f, 0.24f, 0.08f), "Default", GameplayZ).transform.SetParent(parent);
            CreateBox("Fragment Goal Light", new Vector2(9.5f, 2.75f), new Vector2(3.8f, 0.15f), new Color(0.35f, 0.9f, 1f), "Default", GameplayZ).transform.SetParent(parent);
            CreateBox("Server Rack A", new Vector2(-12.6f, -0.25f), new Vector2(1.4f, 3.6f), new Color(0.1f, 0.13f, 0.15f), "Default").transform.SetParent(parent);
            CreateBox("Server Rack B", new Vector2(13.2f, -0.1f), new Vector2(1.6f, 4f), new Color(0.1f, 0.13f, 0.15f), "Default").transform.SetParent(parent);
        }

        private static void CreateVerticalSliceRoom(Transform parent, PrototypeObjectiveState objectiveState)
        {
            CreateTopOnlyPlatform(parent, "Start Floor", new Vector2(-8.5f, -2.6f), new Vector2(7f, 1f), new Color(0.16f, 0.19f, 0.22f), 0.05f);
            CreateTopOnlyPlatform(parent, "Hazard Approach Floor", new Vector2(-1.9f, -2.6f), new Vector2(4.4f, 1f), new Color(0.16f, 0.19f, 0.22f), 0.05f);
            CreateTopOnlyPlatform(parent, "Combat Floor", new Vector2(4.8f, -2.6f), new Vector2(6f, 1f), new Color(0.16f, 0.19f, 0.22f), 0.05f);
            CreateTopOnlyPlatform(parent, "Fragment Pedestal Floor", new Vector2(10.2f, -2.6f), new Vector2(4.2f, 1f), new Color(0.16f, 0.19f, 0.22f), 0.05f);

            CreateTopOnlyPlatform(parent, "Training Step", new Vector2(-5.35f, -1.25f), new Vector2(2.2f, 0.35f), new Color(0.24f, 0.28f, 0.29f));
            CreateTopOnlyPlatform(parent, "Upper Recovery Catwalk", new Vector2(-1.2f, 0.05f), new Vector2(3.2f, 0.35f), new Color(0.22f, 0.28f, 0.32f));
            CreateTopOnlyPlatform(parent, "Combat Catwalk", new Vector2(5.8f, 0.95f), new Vector2(4.8f, 0.35f), new Color(0.22f, 0.28f, 0.32f));
            CreateTopOnlyPlatform(parent, "Fragment Step", new Vector2(8.75f, -1.25f), new Vector2(2f, 0.35f), new Color(0.24f, 0.28f, 0.29f));

            CreateBox("Start Marker", new Vector2(-10.9f, -1.85f), new Vector2(0.18f, 1.5f), new Color(0.35f, 0.9f, 1f), "Default", GameplayZ).transform.SetParent(parent);
            CreateBox("Goal Marker", new Vector2(12.1f, -1.65f), new Vector2(0.18f, 1.9f), new Color(0.35f, 0.9f, 1f), "Default", GameplayZ).transform.SetParent(parent);
            CreateGoalZone(parent, objectiveState);
        }

        private static void CreateTemporalMachine(Transform parent)
        {
            CreateBox("Temporal Machine Core", new Vector2(0.4f, 0.55f), new Vector2(1.6f, 2.6f), new Color(0.35f, 0.23f, 0.13f), "Default").transform.SetParent(parent);
            CreateBox("Temporal Machine Glow", new Vector2(0.4f, 0.55f), new Vector2(0.75f, 0.75f), new Color(1f, 0.48f, 0.12f), "Default").transform.SetParent(parent);
            CreateBox("Temporal Machine Base", new Vector2(0.4f, -0.95f), new Vector2(3f, 0.45f), new Color(0.18f, 0.18f, 0.18f), "Default").transform.SetParent(parent);
        }

        private static void CreateVossMonitor(Transform parent)
        {
            CreateBox("Voss Monitor", new Vector2(6.9f, -0.2f), new Vector2(2.2f, 1.25f), new Color(0.05f, 0.28f, 0.34f), "Default").transform.SetParent(parent);
            CreateBox("Voss Portrait Signal", new Vector2(6.9f, -0.15f), new Vector2(0.62f, 0.82f), new Color(0.06f, 0.06f, 0.07f), "Default").transform.SetParent(parent);
        }

        private static void CreateDamageZone(Transform parent)
        {
            GameObject zone = CreateBox("Unstable Time Field", new Vector2(-3.05f, -1.95f), new Vector2(1.9f, 0.75f), new Color(1f, 0.08f, 0.04f), "Default", GameplayZ);
            BoxCollider2D collider = zone.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            zone.AddComponent<DamageZone>();
            zone.transform.SetParent(parent);
        }

        private static void CreateFallRespawnZone(Transform parent)
        {
            GameObject fallZone = CreateBox("Fall Respawn Zone", new Vector2(1.5f, -6.2f), new Vector2(34f, 1f), new Color(0.1f, 0.02f, 0.02f), "Default", GameplayZ);
            BoxCollider2D collider = fallZone.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            fallZone.AddComponent<FallRespawnZone>();
            fallZone.transform.SetParent(parent);
        }

        private static void CreatePrototypeEnemy(Transform parent)
        {
            GameObject enemy = CreateBox("Prototype Enemy", new Vector2(4.2f, -1.55f), new Vector2(0.9f, 1.25f), new Color(0.64f, 0.12f, 0.75f), "Default", GameplayZ);
            enemy.AddComponent<BoxCollider2D>();
            enemy.GetComponent<BoxCollider2D>().sharedMaterial = NoFrictionMaterial;
            Rigidbody2D body = enemy.AddComponent<Rigidbody2D>();
            body.freezeRotation = true;
            body.gravityScale = 4.2f;
            enemy.AddComponent<PrototypeEnemy>();
            enemy.transform.SetParent(parent);
        }

        private static void CreateTemporalFragment(Transform parent)
        {
            GameObject fragment = CreateBox("Temporal Fragment", new Vector2(10.25f, -1.2f), new Vector2(0.55f, 0.55f), new Color(0.35f, 0.9f, 1f), "Default", GameplayZ);
            BoxCollider2D collider = fragment.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            fragment.AddComponent<TemporalFragment>();
            fragment.transform.SetParent(parent);
        }

        private static void CreateGoalZone(Transform parent, PrototypeObjectiveState objectiveState)
        {
            GameObject goalZone = CreateBox("Prototype Goal Zone", new Vector2(12.1f, -1.55f), new Vector2(1.15f, 2.25f), new Color(0.35f, 0.9f, 1f, 0.25f), "Default", GameplayZ);
            Object.DestroyImmediate(goalZone.GetComponent<MeshRenderer>());
            BoxCollider2D collider = goalZone.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            PrototypeGoalZone goal = goalZone.AddComponent<PrototypeGoalZone>();
            goal.SetObjectiveState(objectiveState);
            TemporalScenePortal portal = goalZone.AddComponent<TemporalScenePortal>();
            portal.SetObjectiveState(objectiveState);
            portal.SetTargetScene("VS_Egypt_Blockout");
            goalZone.transform.SetParent(parent);
        }

        private static GameObject CreatePlatform(Transform parent, string name, Vector2 position, Vector2 size, Color color)
        {
            GameObject platform = CreateBox(name, position, size, color, GroundLayerName);
            BoxCollider2D collider = platform.AddComponent<BoxCollider2D>();
            collider.sharedMaterial = NoFrictionMaterial;
            platform.transform.SetParent(parent);
            return platform;
        }

        private static GameObject CreateTopOnlyPlatform(Transform parent, string name, Vector2 position, Vector2 size, Color color)
        {
            return CreateTopOnlyPlatform(parent, name, position, size, color, TopPlatformEdgeInset);
        }

        private static GameObject CreateTopOnlyPlatform(Transform parent, string name, Vector2 position, Vector2 size, Color color, float edgeInset)
        {
            GameObject platform = CreateBox(name, position, size, color, "Default");
            platform.transform.SetParent(parent);

            GameObject topCollider = new GameObject($"{name} Top Collider");
            topCollider.layer = LayerMask.NameToLayer(GroundLayerName);
            topCollider.transform.position = new Vector3(position.x, position.y + (size.y * 0.5f) - 0.02f, GameplayZ);
            topCollider.transform.SetParent(parent);

            float halfColliderWidth = Mathf.Max(0.05f, (size.x * 0.5f) - edgeInset);
            EdgeCollider2D collider = topCollider.AddComponent<EdgeCollider2D>();
            collider.points = new[]
            {
                new Vector2(-halfColliderWidth, 0f),
                new Vector2(halfColliderWidth, 0f)
            };
            collider.sharedMaterial = NoFrictionMaterial;
            collider.usedByEffector = true;

            PlatformEffector2D platformEffector = topCollider.AddComponent<PlatformEffector2D>();
            platformEffector.useOneWay = true;
            platformEffector.useSideFriction = false;
            platformEffector.useSideBounce = false;
            platformEffector.surfaceArc = 160f;
            return platform;
        }

        private static GameObject CreateBox(string name, Vector2 position, Vector2 size, Color color, string layerName)
        {
            return CreateBox(name, position, size, color, layerName, EnvironmentZ);
        }

        private static GameObject CreateBox(string name, Vector2 position, Vector2 size, Color color, string layerName, float zPosition)
        {
            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.name = name;
            box.transform.position = new Vector3(position.x, position.y, zPosition);
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
