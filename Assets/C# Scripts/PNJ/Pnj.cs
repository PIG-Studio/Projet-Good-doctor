using UnityEngine;
using UnityEngine.AI;
using GameCore.TypeExpand.Animator;

namespace PNJ
{
    public class Pnj : MonoBehaviour
    {
        public NavMeshAgent AgentComp { get; private set; }

        public UnityEngine.Animator AnimatorComp { get; private set; }
        
        public void Start()
        {
            AgentComp = gameObject.GetComponent<NavMeshAgent>();
            AnimatorComp = gameObject.GetComponent<UnityEngine.Animator>();
        }

        public void Update()
        { 
            AnimatorComp.UpdateAnim(AgentComp.desiredVelocity);
        }
    }
}