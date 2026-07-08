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
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float groundCheckRadius = 0.12f;

        private Rigidbody2D body;
        private float horizontalInput;
        private bool jumpPressed;
        private int facingDirection = 1;

        public int FacingDirection => facingDirection;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
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
            if (groundCheck == null)
            {
                return false;
            }

            return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask) != null;
        }
    }
}
