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
    public static class EgyptBlockoutSceneBuilder
    {
        private const string ScenePath = "Assets/Scenes/VS_Egypt_Blockout.unity";
        private const string TheoSpritePath = "Assets/Art/Characters/Theo/theo-sprite-v01.png";
        private const string PrototypeScenePath = "Assets/Scenes/Prototype_Theo_Controller.unity";
        private const string GroundLayerName = "Ground";
        private const float BackgroundZ = 2f;
        private const float EnvironmentZ = 0f;
        private const float GameplayZ = -1f;
        private const float TopPlatformEdgeInset = 0.22f;
        private static readonly Vector2 CameraMin = new Vector2(-12.5f, -4f);
        private static readonly Vector2 CameraMax = new Vector2(18.5f, 4f);
        private static readonly PhysicsMaterial2D NoFrictionMaterial = new PhysicsMaterial2D("Prototype No Friction")
        {
            friction = 0f,
            bounciness = 0f
        };

        [MenuItem("Fragmentos do Amanha/Create VS Egypt Blockout Scene")]
        public static void CreateEgyptBlockoutScene()
        {
            EnsureGroundLayer();

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            scene.name = "VS_Egypt_Blockout";

            GameObject root = new GameObject("VS_Egypt_Blockout");
            PrototypeObjectiveState objectiveState = root.AddComponent<PrototypeObjectiveState>();
            GameObject environment = new GameObject("Ancient Egypt Temple Blockout");
            environment.transform.SetParent(root.transform);

            CreateBackground(environment.transform);
            CreateRoom(environment.transform, objectiveState);
            CreateTempleProps(environment.transform);
            CreatePrototypeEnemy(environment.transform, new Vector2(5.2f, -1.55f));
            CreatePrototypeEnemy(environment.transform, new Vector2(12.5f, -1.55f));
            CreateTemporalFragment(environment.transform);
            CreateFallRespawnZone(environment.transform);

            GameObject theo = CreateTheo(new Vector2(-10f, -1.5f));
            theo.transform.SetParent(root.transform);
            objectiveState.SetInventory(theo.GetComponent<FragmentInventory>());

            GameObject mainCamera = CreateCamera(theo.transform);
            mainCamera.transform.SetParent(root.transform);

            GameObject hud = CreatePrototypeHud(theo.GetComponent<PlayerHealth>(), theo.GetComponent<FragmentInventory>(), objectiveState);
            hud.transform.SetParent(root.transform);

            EditorSceneManager.SaveScene(scene, ScenePath);
            EditorBuildSettings.scenes = new[]
            {
                new EditorBuildSettingsScene(PrototypeScenePath, true),
                new EditorBuildSettingsScene(ScenePath, true)
            };
            AssetDatabase.Refresh();
            Debug.Log($"Fragmentos do Amanha: Egypt blockout scene saved at {ScenePath}");
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
            camera.backgroundColor = new Color(0.055f, 0.048f, 0.038f);
            camera.clearFlags = CameraClearFlags.SolidColor;

            CameraFollow2D follow = cameraObject.AddComponent<CameraFollow2D>();
            follow.SetTarget(target);
            follow.SetBounds(CameraMin, CameraMax);
            cameraObject.transform.position = new Vector3(target.position.x, target.position.y + 1.25f, -10f);
            return cameraObject;
        }

        private static void CreateBackground(Transform parent)
        {
            CreateBox("Temple Back Wall", new Vector2(3f, 0f), new Vector2(36f, 8.5f), new Color(0.13f, 0.1f, 0.075f), "Default", BackgroundZ).transform.SetParent(parent);
            CreateBox("Sand Haze", new Vector2(4f, -2.25f), new Vector2(34f, 1.2f), new Color(0.34f, 0.25f, 0.13f, 0.65f), "Default", BackgroundZ).transform.SetParent(parent);
            CreateBox("Cyan Temporal Scar", new Vector2(-8.9f, 0.35f), new Vector2(0.18f, 3.4f), new Color(0.25f, 0.95f, 1f), "Default", GameplayZ).transform.SetParent(parent);
            CreateBox("Distant Door Glow", new Vector2(15.8f, -0.15f), new Vector2(1.8f, 3.2f), new Color(0.06f, 0.28f, 0.31f), "Default", BackgroundZ).transform.SetParent(parent);
        }

        private static void CreateRoom(Transform parent, PrototypeObjectiveState objectiveState)
        {
            CreateTopOnlyPlatform(parent, "Arrival Sand Floor", new Vector2(-8.8f, -2.6f), new Vector2(6.4f, 1f), new Color(0.36f, 0.27f, 0.15f), 0.05f);
            CreateTopOnlyPlatform(parent, "Broken Temple Floor A", new Vector2(-2.6f, -2.6f), new Vector2(4.2f, 1f), new Color(0.31f, 0.25f, 0.18f), 0.05f);
            CreateTopOnlyPlatform(parent, "Combat Causeway", new Vector2(4.6f, -2.6f), new Vector2(6.2f, 1f), new Color(0.29f, 0.24f, 0.18f), 0.05f);
            CreateTopOnlyPlatform(parent, "Obelisk Floor", new Vector2(11.8f, -2.6f), new Vector2(5.6f, 1f), new Color(0.29f, 0.24f, 0.18f), 0.05f);
            CreateTopOnlyPlatform(parent, "Exit Platform", new Vector2(16.1f, -1.15f), new Vector2(2.8f, 0.35f), new Color(0.34f, 0.26f, 0.17f));

            CreateTopOnlyPlatform(parent, "Collapsed Column Step", new Vector2(-5.3f, -1.25f), new Vector2(2f, 0.35f), new Color(0.39f, 0.31f, 0.22f));
            CreateTopOnlyPlatform(parent, "Temple Mid Platform", new Vector2(0.3f, 0.2f), new Vector2(3.4f, 0.35f), new Color(0.38f, 0.3f, 0.21f));
            CreateTopOnlyPlatform(parent, "Glyph Catwalk", new Vector2(7.4f, 0.95f), new Vector2(4.6f, 0.35f), new Color(0.34f, 0.28f, 0.2f));
            CreateTopOnlyPlatform(parent, "Fragment Ledge", new Vector2(10.8f, -0.85f), new Vector2(2f, 0.35f), new Color(0.42f, 0.33f, 0.22f));

            CreateBox("Arrival Rift Marker", new Vector2(-10.65f, -1.75f), new Vector2(0.18f, 1.7f), new Color(0.25f, 0.95f, 1f), "Default", GameplayZ).transform.SetParent(parent);
            CreateBox("Naiara Signal Cloth", new Vector2(14.2f, -1.25f), new Vector2(0.45f, 1.55f), new Color(0.72f, 0.42f, 0.18f), "Default", GameplayZ).transform.SetParent(parent);
            CreateGoalZone(parent, objectiveState);
        }

        private static void CreateTempleProps(Transform parent)
        {
            CreateBox("Fallen Column", new Vector2(-4.8f, -2.05f), new Vector2(2.4f, 0.35f), new Color(0.48f, 0.39f, 0.28f), "Default").transform.SetParent(parent);
            CreateBox("Voss Glyph Obelisk", new Vector2(12.4f, -0.95f), new Vector2(0.8f, 3.15f), new Color(0.1f, 0.08f, 0.07f), "Default").transform.SetParent(parent);
            CreateBox("Obelisk Gold Line", new Vector2(12.4f, -0.9f), new Vector2(0.12f, 2.45f), new Color(0.86f, 0.52f, 0.14f), "Default", GameplayZ).transform.SetParent(parent);
            CreateBox("Temporal Corruption Light", new Vector2(12.4f, 0.65f), new Vector2(0.52f, 0.18f), new Color(0.25f, 0.95f, 1f), "Default", GameplayZ).transform.SetParent(parent);
            CreateBox("Temple Exit Rift", new Vector2(16.15f, 0.35f), new Vector2(0.28f, 2.8f), new Color(0.25f, 0.95f, 1f), "Default", GameplayZ).transform.SetParent(parent);
        }

        private static void CreatePrototypeEnemy(Transform parent, Vector2 position)
        {
            GameObject enemy = CreateBox("Egypt Prototype Enemy", position, new Vector2(0.9f, 1.25f), new Color(0.62f, 0.24f, 0.1f), "Default", GameplayZ);
            BoxCollider2D collider = enemy.AddComponent<BoxCollider2D>();
            collider.sharedMaterial = NoFrictionMaterial;
            Rigidbody2D body = enemy.AddComponent<Rigidbody2D>();
            body.freezeRotation = true;
            body.gravityScale = 4.2f;
            enemy.AddComponent<PrototypeEnemy>();
            enemy.transform.SetParent(parent);
        }

        private static void CreateTemporalFragment(Transform parent)
        {
            GameObject fragment = CreateBox("Temple Temporal Fragment", new Vector2(10.8f, -0.35f), new Vector2(0.55f, 0.55f), new Color(0.25f, 0.95f, 1f), "Default", GameplayZ);
            BoxCollider2D collider = fragment.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            fragment.AddComponent<TemporalFragment>();
            fragment.transform.SetParent(parent);
        }

        private static void CreateFallRespawnZone(Transform parent)
        {
            GameObject fallZone = CreateBox("Egypt Fall Respawn Zone", new Vector2(3f, -6.45f), new Vector2(38f, 1f), new Color(0.12f, 0.05f, 0.025f), "Default", GameplayZ);
            BoxCollider2D collider = fallZone.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            fallZone.AddComponent<FallRespawnZone>();
            fallZone.transform.SetParent(parent);
        }

        private static void CreateGoalZone(Transform parent, PrototypeObjectiveState objectiveState)
        {
            GameObject goalZone = CreateBox("Egypt Goal Zone", new Vector2(16.15f, 0.05f), new Vector2(1.25f, 3.1f), new Color(0.25f, 0.95f, 1f, 0.25f), "Default", GameplayZ);
            Object.DestroyImmediate(goalZone.GetComponent<MeshRenderer>());
            BoxCollider2D collider = goalZone.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
            PrototypeGoalZone goal = goalZone.AddComponent<PrototypeGoalZone>();
            goal.SetObjectiveState(objectiveState);
            goalZone.transform.SetParent(parent);
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
