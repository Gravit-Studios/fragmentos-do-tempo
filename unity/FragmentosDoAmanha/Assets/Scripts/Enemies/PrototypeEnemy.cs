using FragmentosDoAmanha.Combat;
using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class PrototypeEnemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 2;
        [SerializeField] private int contactDamage = 1;
        [SerializeField] private float contactDamageDelay = 0.7f;
        [SerializeField] private float patrolSpeed = 1.6f;
        [SerializeField] private float patrolDistance = 2.4f;
        [SerializeField] private float hitFlashDuration = 0.12f;

        private Vector3 startPosition;
        private Renderer enemyRenderer;
        private Color baseColor;
        private int currentHealth;
        private int direction = 1;
        private float nextContactDamageTime;
        private float flashEndTime;

        private void Awake()
        {
            startPosition = transform.position;
            currentHealth = maxHealth;
            enemyRenderer = GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                baseColor = enemyRenderer.sharedMaterial.color;
            }
        }

        private void Update()
        {
            Patrol();
            UpdateHitFlash();
        }

        public void TakeHit(int damage, Vector2 sourcePosition)
        {
            if (damage <= 0)
            {
                return;
            }

            currentHealth = Mathf.Max(0, currentHealth - damage);
            flashEndTime = Time.time + hitFlashDuration;
            if (enemyRenderer != null)
            {
                enemyRenderer.sharedMaterial.color = new Color(1f, 0.9f, 0.95f);
            }

            if (currentHealth == 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            TryDamagePlayer(collision.collider);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            TryDamagePlayer(collision.collider);
        }

        private void Patrol()
        {
            transform.position += Vector3.right * direction * patrolSpeed * Time.deltaTime;
            float distanceFromStart = transform.position.x - startPosition.x;
            if (Mathf.Abs(distanceFromStart) >= patrolDistance)
            {
                direction = distanceFromStart > 0f ? -1 : 1;
            }
        }

        private void TryDamagePlayer(Collider2D other)
        {
            if (Time.time < nextContactDamageTime)
            {
                return;
            }

            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
            if (playerHealth == null)
            {
                return;
            }

            playerHealth.TakeDamage(contactDamage, transform.position);
            nextContactDamageTime = Time.time + contactDamageDelay;
        }

        private void UpdateHitFlash()
        {
            if (enemyRenderer == null || Time.time < flashEndTime)
            {
                return;
            }

            enemyRenderer.sharedMaterial.color = baseColor;
        }
    }
}
