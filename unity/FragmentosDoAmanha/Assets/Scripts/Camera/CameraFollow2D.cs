using UnityEngine;

namespace FragmentosDoAmanha.CameraTools
{
    public sealed class CameraFollow2D : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0f, 1.25f, -10f);
        [SerializeField] private float followSmoothTime = 0.14f;
        [SerializeField] private bool useBounds = true;
        [SerializeField] private Vector2 minPosition = new Vector2(-9f, -1.25f);
        [SerializeField] private Vector2 maxPosition = new Vector2(10f, 2.5f);

        private Camera followCamera;
        private Vector3 velocity;

        private void Awake()
        {
            followCamera = GetComponent<Camera>();
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        public void SetBounds(Vector2 newMinPosition, Vector2 newMaxPosition)
        {
            minPosition = newMinPosition;
            maxPosition = newMaxPosition;
            useBounds = true;
        }

        private void LateUpdate()
        {
            if (target == null)
            {
                return;
            }

            Vector3 desiredPosition = target.position + offset;
            if (useBounds)
            {
                desiredPosition = ClampToVisibleBounds(desiredPosition);
            }

            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSmoothTime);
        }

        private Vector3 ClampToVisibleBounds(Vector3 desiredPosition)
        {
            if (followCamera == null)
            {
                return new Vector3(
                    Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x),
                    Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y),
                    desiredPosition.z);
            }

            float halfHeight = followCamera.orthographicSize;
            float halfWidth = halfHeight * followCamera.aspect;
            desiredPosition.x = ClampAxis(desiredPosition.x, minPosition.x + halfWidth, maxPosition.x - halfWidth);
            desiredPosition.y = ClampAxis(desiredPosition.y, minPosition.y + halfHeight, maxPosition.y - halfHeight);
            return desiredPosition;
        }

        private static float ClampAxis(float value, float min, float max)
        {
            return min <= max ? Mathf.Clamp(value, min, max) : (min + max) * 0.5f;
        }
    }
}
