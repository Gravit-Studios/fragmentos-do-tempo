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

        private Vector3 velocity;

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
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
                desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);
            }

            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSmoothTime);
        }
    }
}
