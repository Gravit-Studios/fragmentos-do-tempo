using FragmentosDoAmanha.CameraTools;
using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

namespace FragmentosDoAmanha.Editor
{
    public static class CameraUpgradeSetup
    {
        private const string CameraObjectName = "Prototype Camera";
        private const string TheoObjectName = "Theo Placeholder";
        private const string VcamObjectName = "Theo Follow Vcam";
        private const float DefaultOrthographicSize = 5f;

        // Tiles and Theo were imported at different source resolutions (Era Zero
        // tiles ~627 PPU, Egypt tiles ~512 PPU, Theo ~795 PPU), so no single value
        // gives crisp per-pixel snapping for every asset yet. 100 is a neutral
        // placeholder; revisit once the art pipeline settles on one native
        // resolution per pixel-art tile/sprite.
        private const int PlaceholderAssetsPpu = 100;

        [MenuItem("Fragmentos do Amanha/Upgrade Camera To Cinemachine + Pixel Perfect (Current Scene)")]
        public static void UpgradeCamera()
        {
            GameObject cameraObject = GameObject.Find(CameraObjectName);
            if (cameraObject == null)
            {
                Debug.LogError($"Fragmentos do Amanha: no '{CameraObjectName}' GameObject found in the open scene.");
                return;
            }

            GameObject theo = GameObject.Find(TheoObjectName);
            if (theo == null)
            {
                Debug.LogError($"Fragmentos do Amanha: no '{TheoObjectName}' GameObject found in the open scene.");
                return;
            }

            Camera camera = cameraObject.GetComponent<Camera>();
            if (camera == null)
            {
                Debug.LogError($"Fragmentos do Amanha: '{CameraObjectName}' has no Camera component.");
                return;
            }

            float orthographicSize = camera.orthographicSize > 0f ? camera.orthographicSize : DefaultOrthographicSize;

            CameraFollow2D legacyFollow = cameraObject.GetComponent<CameraFollow2D>();
            if (legacyFollow != null)
            {
                Object.DestroyImmediate(legacyFollow);
            }

            if (cameraObject.GetComponent<CinemachineBrain>() == null)
            {
                cameraObject.AddComponent<CinemachineBrain>();
            }

            PixelPerfectCamera pixelPerfect = cameraObject.GetComponent<PixelPerfectCamera>();
            if (pixelPerfect == null)
            {
                pixelPerfect = cameraObject.AddComponent<PixelPerfectCamera>();
            }

            pixelPerfect.assetsPPU = PlaceholderAssetsPpu;
            pixelPerfect.refResolutionX = 480;
            pixelPerfect.refResolutionY = 270;
            pixelPerfect.upscaleRT = true;
            pixelPerfect.pixelSnapping = true;
            pixelPerfect.cropFrameX = false;
            pixelPerfect.cropFrameY = false;

            Transform siblingRoot = cameraObject.transform.parent;
            Transform existingVcamTransform = siblingRoot != null ? siblingRoot.Find(VcamObjectName) : null;
            GameObject vcamObject = existingVcamTransform != null ? existingVcamTransform.gameObject : new GameObject(VcamObjectName);
            if (siblingRoot != null)
            {
                vcamObject.transform.SetParent(siblingRoot);
            }

            CinemachineCamera vcam = vcamObject.GetComponent<CinemachineCamera>();
            if (vcam == null)
            {
                vcam = vcamObject.AddComponent<CinemachineCamera>();
            }

            vcam.Follow = theo.transform;
            LensSettings lens = vcam.Lens;
            lens.Orthographic = true;
            lens.OrthographicSize = orthographicSize;
            vcam.Lens = lens;

            CinemachineFollow followBody = vcamObject.GetComponent<CinemachineFollow>();
            if (followBody == null)
            {
                followBody = vcamObject.AddComponent<CinemachineFollow>();
            }

            followBody.FollowOffset = new Vector3(0f, 1.25f, -10f);

            EditorUtility.SetDirty(cameraObject);
            EditorUtility.SetDirty(vcamObject);
            Debug.Log("Fragmentos do Amanha: camera atualizada para Cinemachine + Pixel Perfect Camera. " +
                "O confinamento de bounds do CameraFollow2D antigo NAO foi migrado automaticamente " +
                "(precisa de um Cinemachine Confiner2D com um PolygonCollider2D manual) — adicione " +
                "se a camera estiver saindo dos limites da sala. Salve a cena e teste em Play Mode.");
        }
    }
}
