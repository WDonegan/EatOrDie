using System;
using UnityEngine;

namespace EatOrDie
{
    [DefaultExecutionOrder(-100)]
    public class CharacterController2D : MonoBehaviour
    {
        private static readonly int HorizontalVelocity = Animator.StringToHash("HorizontalVelocity");
        private static readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
        private static readonly int Grounded = Animator.StringToHash("Grounded");
                
        [SerializeField] private float jumpForce = 400f;
        [SerializeField, Range(0f, 0.3f)] private float movementSmoothing = 0.05f;
        [SerializeField] private bool airControl;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundCheck;

        private const float GroundedRadius = 0.2f;
        
        private bool grounded;
        private bool facingRight;
        
        private float horizontalVelocity = 0;
        private bool readyToClear;
        private float iHorizontal;
        
        private Rigidbody2D rigidBody2D;
        private Animator animator;
        private InputMaster controls;
        
        
        private void Awake()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            controls = new InputMaster();
        }
        private void OnEnable() => controls.Enable();
        private void OnDisable() => controls.Disable();
        private void Start()
        {
            controls.Play.Movement.performed += ctx => iHorizontal = ctx.ReadValue<float>() * 5f;
            
            controls.Play.Jump.performed += ctx => rigidBody2D.AddForce(new Vector2(0, jumpForce));
            
            controls.Play.LongJump.performed += ctx => rigidBody2D.AddForce(new Vector2(0, jumpForce * 0.3f));

            controls.Play.ExitGame.performed += ctx => Application.Quit();
        }

        private void FixedUpdate()
        {
            bool wasGrounded = grounded;
            grounded = false;

            var colliders = Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius,  groundLayer);
            foreach(var cdr in colliders)
                if (cdr.gameObject != gameObject)
                    grounded = true;

            var currentVelocity = rigidBody2D.velocity;
            currentVelocity.x = Mathf.SmoothDamp(currentVelocity.x, iHorizontal, ref horizontalVelocity, movementSmoothing);
            rigidBody2D.velocity = currentVelocity;

            animator.SetFloat(HorizontalVelocity, Mathf.Abs(rigidBody2D.velocity.x));
            animator.SetFloat(VerticalVelocity, rigidBody2D.velocity.y);
            animator.SetBool(Grounded, grounded);
            
            ClearInput();
        }
        
        private void Flip()
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        
        private void ClearInput()
        {
            if (!readyToClear) return;
            
            iHorizontal = 0f;
            
            readyToClear = false;
        }
        
    }
}