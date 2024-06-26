using TypeExpand.Float;
using UnityEngine;

namespace TypeExpand.Animator
{
    public static class EAnimator
    {

        private static readonly int MovingDown = UnityEngine.Animator.StringToHash("MovingDown");
        private static readonly int MovingRight = UnityEngine.Animator.StringToHash("MovingRight");
        private static readonly int MovingLeft = UnityEngine.Animator.StringToHash("MovingLeft");
        private static readonly int MovingUp = UnityEngine.Animator.StringToHash("MovingUp");
        

        /// <summary>
        /// Met à jour les paramètres d'animation en fonction des entrées de déplacement
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="inputs"></param>
        public static void UpdateAnim(this UnityEngine.Animator animator, Vector2? inputs = null)
        {
            // Si les entrées sont nulles ou zéro, désactive toutes les animations de déplacement
            if (inputs is null || inputs == Vector2.zero)
            {
                animator.SetBool(MovingUp, false);
                animator.SetBool(MovingDown, false);
                animator.SetBool(MovingRight, false);
                animator.SetBool(MovingLeft, false);
                return;
            }
            
            float horizontalInput = inputs.Value.x;
            float verticalInput = inputs.Value.y;

            if (horizontalInput.Abs() < verticalInput.Abs())
            {
                animator.SetBool(MovingRight, false);
                animator.SetBool(MovingLeft, false);
                animator.SetBool(MovingUp, verticalInput > 0);
                animator.SetBool(MovingDown, verticalInput < 0);
            return;
            }
            
            animator.SetBool(MovingRight, horizontalInput > 0);
            animator.SetBool(MovingLeft, horizontalInput < 0);
            animator.SetBool(MovingUp, false);
            animator.SetBool(MovingDown, false);
        }
        
    }
}