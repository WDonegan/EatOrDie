using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.PlayerLoop;

namespace EatOrDie
{
    /// <summary>
    /// Will tied together the InputManager, Animator, and character physics
    /// </summary>
    [DefaultExecutionOrder(-50)]
    public class CharacterController2D : MonoBehaviour
    {
        private static readonly int HorizontalVelocity = Animator.StringToHash("HorizontalVelocity");
        private static readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
        private static readonly int Grounded = Animator.StringToHash("Grounded");
        private static readonly int Ducking = Animator.StringToHash("Duck");

        private const float GroundedRadius = 0.2f;

        [SerializeField] private InputManager inputManager;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask grouncLayer;
        [SerializeField] private bool airControl;
        [SerializeField, Range(0, 0.3f)] private float smoothing = 0.05f;
        [SerializeField] private float moveForce = 200f;
        [SerializeField] private float duckMoveForce = 100f;
        [SerializeField] private float jumpForce = 10f;
        
        private Transform tf;
        private Rigidbody2D rb;
        private Animator animator;

        private void Awake()
        {
            tf = GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        #region Input Callbacks

        private void OnEnable()
        {
            inputManager.OnForward += ForwardFlipAction;
            inputManager.OnForward += ForwardMoveAction;
            inputManager.OnBackward += BackwardFlipAction;
            inputManager.OnBackward += BackwardMoveAction;
            inputManager.OnJump += JumpAction;
            inputManager.OnDuck += DuckAction;
            
        }
        private void OnDisable()
        {
            inputManager.OnForward -= ForwardFlipAction;
            inputManager.OnForward -= ForwardMoveAction;
            inputManager.OnBackward -= BackwardFlipAction;
            inputManager.OnBackward -= BackwardMoveAction;
            inputManager.OnJump -= JumpAction;
            inputManager.OnDuck -= DuckAction;
        }
        private void ForwardFlipAction(object s, EventArgs e) { if (!facingForward) Flip(); }
        private void BackwardFlipAction(object s, EventArgs e) { if (facingForward) Flip(); }
        private void ForwardMoveAction(object s, EventArgs e) { iHorizontalDirection = 1; }
        private void BackwardMoveAction(object s, EventArgs e) { iHorizontalDirection = -1; }
        private void JumpAction(object s, EventArgs e) { if (grounded) iJump = true; }
        private void DuckAction(object s, EventArgs e) { ducking = true; playDuckAnimation = true; }

        #endregion
        
        private void FixedUpdate()
        {
            GroundCheck();
            
            PreformJump();
            PreformMove();
            PreformDuck();

            UpdateAnimationProperties();
        }

        #region Horizontal Movement
        
        private int iHorizontalDirection;
        private float hVelocitySmoothing;
        /// <summary>
        /// Add force based on current input direction (-1,1) or (0) if no current input this frame.
        /// Horizontal velocity will be smoothly damped based on teh smoothing value.
        /// Note: This function consumes the input. I.E. It sets iHorizontalDirection=0 after preforming actions.
        /// </summary>
        private void PreformMove()
        {
            var force = ducking
                ? new Vector2(iHorizontalDirection * duckMoveForce, 0)
                : new Vector2(iHorizontalDirection * moveForce, 0);
            
            rb.AddForce(force, ForceMode2D.Force);
            
            var currentVelocity = rb.velocity;
            currentVelocity.x = Mathf.SmoothDamp(currentVelocity.x, iHorizontalDirection, ref hVelocitySmoothing, smoothing);
            rb.velocity = currentVelocity;
            
            iHorizontalDirection = 0;
        }

        #endregion

        #region Vertical Movement (Jump)

        private bool iJump;
        /// <summary>
        /// Check if jump input occured this frame and if on the 'ground'. If both are true, preform the jump action;
        /// </summary>
        private void PreformJump()
        {
            if (!iJump) return;
            
            grounded = false;
            iJump = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        #endregion
        
        #region Ducking

        private bool ducking;
        private void PreformDuck()
        {
            if (!ducking) return;

            
            
            ducking = false;
        }
        
        #endregion
        
        #region Ground Check
        
        private Collider2D[] otherColliders;
        private bool grounded;
        /// <summary>
        /// Cast an overlap collider to the ground check position and report
        /// if making contact with any colliders on the Terrain layer.
        /// </summary>
        private void GroundCheck()
        {
            otherColliders = Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius, grouncLayer);
            grounded = false;
            
            foreach (var otherCollider in otherColliders)
                if (otherCollider.gameObject != this.gameObject)
                    grounded = true;
        }
        
        #endregion
        
        #region Flip Sprite
        
        private Vector3 theScale;
        private bool facingForward;
        /// <summary>
        /// Flip the sprite (localScale.x * -1)
        /// </summary>
        private void Flip()
        {
            facingForward = !facingForward;

            theScale = tf.localScale;
            theScale.x *= -1;
            tf.localScale = theScale;
        }

        #endregion
        
        #region Update Animation Properties

        private bool playDuckAnimation;
        /// <summary>
        /// Update animator properties.
        /// </summary>
        private void UpdateAnimationProperties()
        {
            animator.SetFloat(HorizontalVelocity, Mathf.Abs(rb.velocity.x));
            animator.SetFloat(VerticalVelocity, rb.velocity.y);
            animator.SetBool(Grounded, grounded);
            animator.SetBool(Ducking, playDuckAnimation);

            playDuckAnimation = false;
        }
        
        #endregion
    }
}
