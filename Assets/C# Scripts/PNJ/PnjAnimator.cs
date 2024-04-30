using System;
using Interfaces;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace PNJ
{
    public static class PnjAnimator
    {
        public static void LinkAnimator(this ISpawnableGo input)
        {
            Animator anims = input.InstantiatedObject.GetComponent<Animator>();
            input.AnimatorComponent = anims;
        }
        
        public static void UpdateAnimator(this ISpawnableGo input)
        {
            NavMeshAgent navMeshAgent = input.Agent;
            Animator _anims = input.AnimatorComponent;
            float verticalInput = navMeshAgent.nextPosition.y - navMeshAgent.transform.position.y;
            float horizontalInput = navMeshAgent.nextPosition.x - navMeshAgent.transform.position.x;
            if (verticalInput < 0)
            {
                _anims.SetBool("MovingUp", false);
                _anims.SetBool("MovingDown", true);
            }
            else if (verticalInput > 0)
            {
                _anims.SetBool("MovingUp", true);
                _anims.SetBool("MovingDown", false);
            }
            else
            {
                _anims.SetBool("MovingUp", false);
                _anims.SetBool("MovingDown", false);
            }

            if (horizontalInput > 0)
            {
                _anims.SetBool("MovingRight", true);
                _anims.SetBool("MovingLeft", false);
            }
            else if (horizontalInput < 0)
            {
                _anims.SetBool("MovingRight", false);
                _anims.SetBool("MovingLeft", true);
            }
            else
            {
                _anims.SetBool("MovingRight", false);
                _anims.SetBool("MovingLeft", false);
            }
            Debug.Log("UpdateAnimator");    
        }
    }
}