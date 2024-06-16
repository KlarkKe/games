using UnityEngine;

namespace Scripts.Hero
{
    public class Hero : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField] private bool _invertScale;
        [SerializeField] private float _speed;
        [SerializeField] protected float JumpSpeed;
        [SerializeField] private float _damageVelocity;

        [Header("Chekers ")]
        //[SerializeField] protected LayerMask _groundLayer;
        [SerializeField] private LayerCheck GroundCheck;

        [SerializeField] private Rigidbody2D Rigidbody;
        [SerializeField] private Animator Animator;

        private Vector2 Direction;
        private bool IsGrounded;

        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int IsWalking = Animator.StringToHash("is-walking");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");

        public void SetDirection(Vector2 direction)
        {
            Direction = direction;
        }

        private void Update()
        {
            IsGrounded = GroundCheck.IsTouchingLayer;
        }

        private void FixedUpdate()
        {
            var xVelocity = Direction.x * _speed;
            var yVelocuty = CalculateYVelocity();
            Rigidbody.velocity = new Vector2(xVelocity, yVelocuty);

            Animator.SetBool(IsGroundKey, IsGrounded);
            Animator.SetBool(IsWalking, Direction.x != 0);
            Animator.SetFloat(VerticalVelocity, Rigidbody.velocity.y);

            UpdateSpriteDirection(Direction);
        }

        private float CalculateYVelocity()
        {
            var yVelocity = Rigidbody.velocity.y;
            var isJumpPressing = Direction.y > 0;

            if (isJumpPressing)
            {
                var isFalling = Rigidbody.velocity.y <= 0.001f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;
            }
            else if (Rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            var isFalling = Rigidbody.velocity.y <= 0.001f;
            if (IsGrounded)
            {
                yVelocity += JumpSpeed;
            }

            return yVelocity;
        }

        public void UpdateSpriteDirection(Vector2 direction)
        {
            var multiplier = _invertScale ? -1 : 1;
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(multiplier, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1 * multiplier, 1, 1);
            }
        }

        public void TakeDamage()
        {
            //Animator.SetTrigger(Hit);
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, _damageVelocity);
        }
    }
}