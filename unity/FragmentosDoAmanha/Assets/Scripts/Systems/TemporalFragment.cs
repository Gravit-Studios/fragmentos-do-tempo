using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.Systems
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class TemporalFragment : MonoBehaviour
    {
        [SerializeField] private int amount = 1;
        [SerializeField] private float bobSpeed = 3f;
        [SerializeField] private float bobAmplitude = 0.12f;

        private Vector3 startPosition;

        private void Awake()
        {
            startPosition = transform.position;
            Collider2D fragmentCollider = GetComponent<Collider2D>();
            fragmentCollider.isTrigger = true;
        }

        private void Update()
        {
            float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobAmplitude;
            transform.position = startPosition + Vector3.up * yOffset;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            FragmentInventory inventory = other.GetComponentInParent<FragmentInventory>();
            if (inventory == null)
            {
                return;
            }

            inventory.AddFragment(amount);
            gameObject.SetActive(false);
        }
    }
}
