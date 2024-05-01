using TypeExpand.Float;
using UnityEngine;

namespace TypeExpand.Animator
{
    public static class EAnimator
    {   
        public static void UpdateAnim(this UnityEngine.Animator animator, Vector2 inputs)
        {
            if (inputs == Vector2.zero)
            {
                animator.SetBool("MovingUp", false);
                animator.SetBool("MovingDown", false);
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", false); 
                return;   
            }
            
            float horizontalInput = inputs.x;
            float verticalInput = inputs.y;
            
            switch (verticalInput)
            {
                case < 0:
                    animator.SetBool("MovingUp", false);
                    animator.SetBool("MovingDown", true);
                    break;
                case > 0:
                    animator.SetBool("MovingUp", true);
                    animator.SetBool("MovingDown", false);
                    break;
                default:
                    animator.SetBool("MovingUp", false);
                    animator.SetBool("MovingDown", false);
                    break;
            }

            if (horizontalInput.Abs() < verticalInput.Abs())
            {
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", false);
                return;
            }

            switch (horizontalInput)
            {
                case > 0:
                    animator.SetBool("MovingRight", true);
                    animator.SetBool("MovingLeft", false);
                    break;
                case < 0:
                    animator.SetBool("MovingRight", false);
                    animator.SetBool("MovingLeft", true);
                    break;
                default:
                    animator.SetBool("MovingRight", false);
                    animator.SetBool("MovingLeft", false);
                    break;
            }
        }
    }
}