using UnityEngine;
using System;

namespace AdiSamController
{
    public class PlayerControl : MonoBehaviour
    {
        public event EventHandler<OnBuildEventsArgs> OnBuild;
        public class OnBuildEventsArgs : EventArgs {};

        private float horizontalValue;
        private float verticalValue;
        public float moveSpeed = 1f;
        
        private Vector3 movementInput;

        private float movementSpeed;
        private bool facingRight = false;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            ProcessInputs();
            TurnPlayer();

            if (movementInput != Vector3.zero)
            {
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }

        private void TurnPlayer()
        {
            if (movementInput.x < 0 && !facingRight)
            {
                Flip();
            }
            else if (movementInput.x > 0 && facingRight)
            {
                Flip();
            }
        }
    
        private void Flip()
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }


        void ProcessInputs()
        {
            horizontalValue = Input.GetAxisRaw("Horizontal");
            verticalValue = Input.GetAxisRaw("Vertical");
            movementInput = new Vector3(horizontalValue, verticalValue);

            movementSpeed = Mathf.Clamp(movementInput.magnitude, 0.0f, 1.0f);

            movementInput.Normalize();

            if (movementInput != Vector3.zero)
            {
                transform.position += movementInput * moveSpeed * movementSpeed * Time.fixedDeltaTime;
            }
        }

        private void Building(){}
    }
}
