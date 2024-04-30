using UnityEngine;
using UnityEngine.AI;

namespace PNJ
{
    public class Pnj : MonoBehaviour
    {
        public NavMeshAgent AgentComp { get; private set; }

        public Animator AnimatorComp { get; private set; }
        
        public void Start()
        {
            AgentComp = gameObject.GetComponent<NavMeshAgent>();
            AnimatorComp = gameObject.GetComponent<Animator>();
        }

        public void Update()
        {
            Vector3 velocity = AgentComp.desiredVelocity;
            
            if (velocity == Vector3.zero)
            {
                AnimatorComp.SetBool("MovingUp", false);
                AnimatorComp.SetBool("MovingDown", false);
                AnimatorComp.SetBool("MovingRight", false);
                AnimatorComp.SetBool("MovingLeft", false); 
                return;   
            }
            
            float verticalInput = velocity.y;
            Debug.Log(verticalInput);
            float horizontalInput = velocity.x;
            switch (verticalInput)
            {
                case < 0:
                    AnimatorComp.SetBool("MovingUp", false);
                    AnimatorComp.SetBool("MovingDown", true);
                    break;
                case > 0:
                    AnimatorComp.SetBool("MovingUp", true);
                    AnimatorComp.SetBool("MovingDown", false);
                    break;
                default:
                    AnimatorComp.SetBool("MovingUp", false);
                    AnimatorComp.SetBool("MovingDown", false);
                    break;
            }

            switch (horizontalInput)
            {
                case > 0:
                    AnimatorComp.SetBool("MovingRight", true);
                    AnimatorComp.SetBool("MovingLeft", false);
                    break;
                case < 0:
                    AnimatorComp.SetBool("MovingRight", false);
                    AnimatorComp.SetBool("MovingLeft", true);
                    break;
                default:
                    AnimatorComp.SetBool("MovingRight", false);
                    AnimatorComp.SetBool("MovingLeft", false);
                    break;
            }
        }
    }
}