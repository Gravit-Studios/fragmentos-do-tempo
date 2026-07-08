using System.Collections;
using System;
using UnityEngine;

namespace FragmentosDoAmanha.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;
        [SerializeField] private float invulnerabilityDuration = 0.75f;
        [SerializeField] private float respawnDelay = 0.35f;
        [SerializeField] private Vector2 knockbackForce = new Vector2(7f, 6f);
        [SerializeField] private Transform respawnPoint;

        private Rigidbody2D body;
        private Vector3 fallbackRespawnPosition;
        private int currentHealth;
        private bool isInvulnerable;
        private bool isRespawning;

        public int CurrentHealth => currentHealth;
        public int MaxHealth => maxHealth;
        public bool IsInvulnerable => isInvulnerable;

        public event Action<int, int> HealthChanged;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            fallbackRespawnPosition = transform.position;
            currentHealth = maxHealth;
            HealthChanged?.Invoke(currentHealth, maxHealth);
        }

        private void Start()
        {
            HealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public void SetRespawnPoint(Transform newRespawnPoint)
        {
            respawnPoint = newRespawnPoint;
        }

        public void RespawnNow()
        {
            if (isRespawning)
            {
                return;
            }

            StartCoroutine(RespawnRoutine());
        }

        public void TakeDamage(int damage, Vector2 sourcePosition)
        {
            if (damage <= 0 || isInvulnerable || isRespawning)
            {
                return;
            }

            currentHealth = Mathf.Max(0, currentHealth - damage);
            HealthChanged?.Invoke(currentHealth, maxHealth);
            ApplyKnockback(sourcePosition);

            if (currentHealth == 0)
            {
                StartCoroutine(RespawnRoutine());
                return;
            }

            StartCoroutine(InvulnerabilityRoutine());
        }

        private void ApplyKnockback(Vector2 sourcePosition)
        {
            float direction = transform.position.x >= sourcePosition.x ? 1f : -1f;
            body.linearVelocity = new Vector2(direction * knockbackForce.x, knockbackForce.y);
        }

        private IEnumerator InvulnerabilityRoutine()
        {
            isInvulnerable = true;
            yield return new WaitForSeconds(invulnerabilityDuration);
            isInvulnerable = false;
        }

        private IEnumerator RespawnRoutine()
        {
            isRespawning = true;
            isInvulnerable = true;
            body.linearVelocity = Vector2.zero;

            yield return new WaitForSeconds(respawnDelay);

            transform.position = respawnPoint != null ? respawnPoint.position : fallbackRespawnPosition;
            currentHealth = maxHealth;
            HealthChanged?.Invoke(currentHealth, maxHealth);
            body.linearVelocity = Vector2.zero;

            yield return new WaitForSeconds(invulnerabilityDuration);

            isInvulnerable = false;
            isRespawning = false;
        }
    }
}
