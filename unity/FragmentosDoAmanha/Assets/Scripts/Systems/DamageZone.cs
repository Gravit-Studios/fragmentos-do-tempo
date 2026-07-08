using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.Systems
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class DamageZone : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float repeatDamageDelay = 0.6f;

        private float nextDamageTime;

        private void Reset()
        {
            Collider2D zoneCollider = GetComponent<Collider2D>();
            zoneCollider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TryDamage(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            TryDamage(other);
        }

        private void TryDamage(Collider2D other)
        {
            if (Time.time < nextDamageTime)
            {
                return;
            }

            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
            if (playerHealth == null)
            {
                return;
            }

            playerHealth.TakeDamage(damage, transform.position);
            nextDamageTime = Time.time + repeatDamageDelay;
        }
    }
}
