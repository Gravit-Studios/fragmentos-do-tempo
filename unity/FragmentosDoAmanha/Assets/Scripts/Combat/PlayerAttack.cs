using System.Collections;
using FragmentosDoAmanha.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FragmentosDoAmanha.Combat
{
    [RequireComponent(typeof(TheoController))]
    public sealed class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private Vector2 hitboxSize = new Vector2(1.15f, 0.85f);
        [SerializeField] private Vector2 hitboxOffset = new Vector2(0.85f, 0.05f);
        [SerializeField] private float activeDuration = 0.12f;
        [SerializeField] private float cooldownDuration = 0.28f;
        [SerializeField] private Transform hitboxPreview;

        private TheoController controller;
        private bool isAttacking;
        private float nextAttackTime;

        private void Awake()
        {
            controller = GetComponent<TheoController>();
            SetPreviewVisible(false);
        }

        private void Update()
        {
            if (Time.time < nextAttackTime || isAttacking)
            {
                return;
            }

            Keyboard keyboard = Keyboard.current;
            Mouse mouse = Mouse.current;
            bool attackPressed = keyboard != null && keyboard.jKey.wasPressedThisFrame;
            attackPressed |= mouse != null && mouse.leftButton.wasPressedThisFrame;

            if (attackPressed)
            {
                StartCoroutine(AttackRoutine());
            }
        }

        private IEnumerator AttackRoutine()
        {
            isAttacking = true;
            nextAttackTime = Time.time + cooldownDuration;
            SetPreviewVisible(true);

            Vector2 center = GetHitboxCenter();
            Collider2D[] hits = Physics2D.OverlapBoxAll(center, hitboxSize, 0f);
            foreach (Collider2D hit in hits)
            {
                IDamageable damageable = hit.GetComponentInParent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeHit(damage, transform.position);
                }
            }

            yield return new WaitForSeconds(activeDuration);

            SetPreviewVisible(false);
            isAttacking = false;
        }

        private Vector2 GetHitboxCenter()
        {
            int direction = controller != null ? controller.FacingDirection : 1;
            return new Vector2(
                transform.position.x + hitboxOffset.x * direction,
                transform.position.y + hitboxOffset.y);
        }

        private void LateUpdate()
        {
            if (hitboxPreview == null)
            {
                return;
            }

            hitboxPreview.position = GetHitboxCenter();
        }

        private void SetPreviewVisible(bool isVisible)
        {
            if (hitboxPreview != null)
            {
                hitboxPreview.gameObject.SetActive(isVisible);
            }
        }

        private void OnDrawGizmosSelected()
        {
            TheoController theoController = controller != null ? controller : GetComponent<TheoController>();
            int direction = theoController != null ? theoController.FacingDirection : 1;
            Vector2 center = new Vector2(
                transform.position.x + hitboxOffset.x * direction,
                transform.position.y + hitboxOffset.y);

            Gizmos.color = new Color(1f, 0.72f, 0.22f, 0.45f);
            Gizmos.DrawCube(center, hitboxSize);
        }
    }
}
