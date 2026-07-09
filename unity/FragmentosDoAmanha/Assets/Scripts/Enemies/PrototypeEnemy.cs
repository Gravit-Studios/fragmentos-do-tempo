using System.Collections;
using FragmentosDoAmanha.Combat;
using FragmentosDoAmanha.Player;
using UnityEngine;

namespace FragmentosDoAmanha.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class PrototypeEnemy : MonoBehaviour, IDamageable
    {
        private enum State
        {
            Patrol,
            Telegraph,
            Attacking,
            Cooldown
        }

        [SerializeField] private int maxHealth = 2;
        [SerializeField] private float patrolSpeed = 1.6f;
        [SerializeField] private float patrolDistance = 2.4f;
        [SerializeField] private float hitFlashDuration = 0.12f;

        [Header("Attack Telegraph")]
        [SerializeField] private float detectionRange = 3.2f;
        [SerializeField] private float telegraphDuration = 0.45f;
        [SerializeField] private float telegraphBlinkInterval = 0.09f;
        [SerializeField] private float attackActiveDuration = 0.15f;
        [SerializeField] private float cooldownDuration = 0.5f;
        [SerializeField] private int attackDamage = 1;
        [SerializeField] private Vector2 hitboxSize = new Vector2(1.1f, 1f);
        [SerializeField] private Vector2 hitboxOffset = new Vector2(0.75f, 0f);
        [SerializeField] private Color telegraphColor = new Color(1f, 0.95f, 0.2f);
        [SerializeField] private Color attackColor = new Color(1f, 0.35f, 0.15f);

        private Vector3 startPosition;
        private Renderer enemyRenderer;
        private Color baseColor;
        private int currentHealth;
        private int patrolDirection = 1;
        private int attackDirection = 1;
        private float flashEndTime;
        private State state = State.Patrol;
        private PlayerHealth trackedPlayer;
        private Coroutine attackRoutine;

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
            if (state == State.Patrol)
            {
                Patrol();
                TryDetectPlayer();
            }

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

        private void Patrol()
        {
            transform.position += Vector3.right * patrolDirection * patrolSpeed * Time.deltaTime;
            float distanceFromStart = transform.position.x - startPosition.x;
            if (Mathf.Abs(distanceFromStart) >= patrolDistance)
            {
                patrolDirection = distanceFromStart > 0f ? -1 : 1;
            }
        }

        private void TryDetectPlayer()
        {
            Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, detectionRange);
            foreach (Collider2D candidate in nearby)
            {
                PlayerHealth playerHealth = candidate.GetComponentInParent<PlayerHealth>();
                if (playerHealth == null)
                {
                    continue;
                }

                trackedPlayer = playerHealth;
                attackRoutine = StartCoroutine(TelegraphAndAttackRoutine());
                return;
            }
        }

        private IEnumerator TelegraphAndAttackRoutine()
        {
            state = State.Telegraph;
            attackDirection = trackedPlayer != null && trackedPlayer.transform.position.x < transform.position.x ? -1 : 1;

            float elapsed = 0f;
            bool blinkOn = true;
            while (elapsed < telegraphDuration)
            {
                SetColor(blinkOn ? telegraphColor : baseColor);
                blinkOn = !blinkOn;
                yield return new WaitForSeconds(telegraphBlinkInterval);
                elapsed += telegraphBlinkInterval;
            }

            state = State.Attacking;
            SetColor(attackColor);

            Vector2 center = GetHitboxCenter();
            Collider2D[] hits = Physics2D.OverlapBoxAll(center, hitboxSize, 0f);
            foreach (Collider2D hit in hits)
            {
                PlayerHealth playerHealth = hit.GetComponentInParent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage, transform.position);
                }
            }

            yield return new WaitForSeconds(attackActiveDuration);

            state = State.Cooldown;
            SetColor(baseColor);
            yield return new WaitForSeconds(cooldownDuration);

            state = State.Patrol;
            attackRoutine = null;
        }

        private Vector2 GetHitboxCenter()
        {
            return new Vector2(
                transform.position.x + hitboxOffset.x * attackDirection,
                transform.position.y + hitboxOffset.y);
        }

        private void SetColor(Color color)
        {
            if (enemyRenderer != null)
            {
                enemyRenderer.sharedMaterial.color = color;
            }
        }

        private void UpdateHitFlash()
        {
            if (enemyRenderer == null || Time.time < flashEndTime)
            {
                return;
            }

            if (state == State.Patrol || state == State.Cooldown)
            {
                enemyRenderer.sharedMaterial.color = baseColor;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1f, 0.95f, 0.2f, 0.25f);
            Gizmos.DrawWireSphere(transform.position, detectionRange);

            Gizmos.color = new Color(1f, 0.35f, 0.15f, 0.45f);
            Gizmos.DrawCube(GetHitboxCenter(), hitboxSize);
        }
    }
}
