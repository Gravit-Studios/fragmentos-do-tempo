using UnityEngine;
using UnityEngine.InputSystem;

namespace FragmentosDoAmanha.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public sealed class TheoController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float jumpForce = 14f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float groundCheckDistance = 0.08f;
        [SerializeField] private float groundCheckWidth = 0.86f;

        private Rigidbody2D body;
        private Collider2D bodyCollider;
        private float horizontalInput;
        private bool jumpPressed;
        private int facingDirection = 1;

        public int FacingDirection => facingDirection;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            bodyCollider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard == null)
            {
                horizontalInput = 0f;
                return;
            }

            float left = keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed ? -1f : 0f;
            float right = keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed ? 1f : 0f;
            horizontalInput = left + right;
            if (horizontalInput > 0f)
            {
                facingDirection = 1;
            }
            else if (horizontalInput < 0f)
            {
                facingDirection = -1;
            }

            if (keyboard.spaceKey.wasPressedThisFrame || keyboard.wKey.wasPressedThisFrame || keyboard.upArrowKey.wasPressedThisFrame)
            {
                jumpPressed = true;
            }
        }

        private void FixedUpdate()
        {
            body.linearVelocity = new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y);

            if (jumpPressed && IsGrounded())
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            }

            jumpPressed = false;
        }

        private bool IsGrounded()
        {
            if (bodyCollider == null)
            {
                return false;
            }

            Bounds bounds = bodyCollider.bounds;
            Vector2 boxSize = new Vector2(bounds.size.x * groundCheckWidth, bounds.size.y);
            RaycastHit2D hit = Physics2D.BoxCast(bounds.center, boxSize, 0f, Vector2.down, groundCheckDistance, groundMask);
            return hit.collider != null;
        }
    }
}
