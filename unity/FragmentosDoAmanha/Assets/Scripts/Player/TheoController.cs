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
        [SerializeField] private float groundCheckWidth = 0.68f;
        [SerializeField] private float coyoteTime = 0.12f;
        [SerializeField] private float sideCheckDistance = 0.08f;
        [SerializeField] private float antiSnagFallSpeed = -0.75f;

        private Rigidbody2D body;
        private Collider2D bodyCollider;
        private float horizontalInput;
        private float groundedTimer;
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
            bool grounded = IsGrounded();
            groundedTimer = grounded ? coyoteTime : Mathf.Max(0f, groundedTimer - Time.fixedDeltaTime);
            int sideContactDirection = GetSideContactDirection();
            float desiredHorizontalVelocity = horizontalInput * moveSpeed;
            if (!grounded && sideContactDirection != 0 && Mathf.Sign(horizontalInput) == sideContactDirection)
            {
                desiredHorizontalVelocity = 0f;
            }

            body.linearVelocity = new Vector2(desiredHorizontalVelocity, body.linearVelocity.y);

            if (jumpPressed && groundedTimer > 0f)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
                groundedTimer = 0f;
            }
            else if (!grounded && sideContactDirection != 0 && Mathf.Abs(body.linearVelocity.y) < 0.05f)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, antiSnagFallSpeed);
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
            Vector2 boxSize = new Vector2(bounds.size.x * groundCheckWidth, 0.08f);
            Vector2 boxCenter = new Vector2(bounds.center.x, bounds.min.y + 0.04f);
            RaycastHit2D hit = Physics2D.BoxCast(boxCenter, boxSize, 0f, Vector2.down, groundCheckDistance, groundMask);
            return hit.collider != null;
        }

        private int GetSideContactDirection()
        {
            if (bodyCollider == null)
            {
                return 0;
            }

            Bounds bounds = bodyCollider.bounds;
            Vector2 boxSize = new Vector2(0.08f, bounds.size.y * 0.72f);
            Vector2 leftCenter = new Vector2(bounds.min.x, bounds.center.y);
            Vector2 rightCenter = new Vector2(bounds.max.x, bounds.center.y);
            bool touchingLeft = Physics2D.BoxCast(leftCenter, boxSize, 0f, Vector2.left, sideCheckDistance, groundMask).collider != null;
            bool touchingRight = Physics2D.BoxCast(rightCenter, boxSize, 0f, Vector2.right, sideCheckDistance, groundMask).collider != null;
            if (touchingLeft && horizontalInput < 0f)
            {
                return -1;
            }

            if (touchingRight && horizontalInput > 0f)
            {
                return 1;
            }

            return 0;
        }
    }
}
