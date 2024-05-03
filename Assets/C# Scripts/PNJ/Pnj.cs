using Interfaces.Destination;
using Interfaces.Entites;
using UnityEngine;
using UnityEngine.AI;
using TypeExpand.Animator;

namespace PNJ
{
    public class Pnj : MonoBehaviour
    {
        public NavMeshAgent AgentComp { get; private set; }

        public Animator AnimatorComp { get; private set; }
        public IDeskDestination Destination { get; set; }
        public ICanGoInDesk Patient { get; set; }
        
        public void Start()
        {
            AgentComp = gameObject.GetComponent<NavMeshAgent>();
            AnimatorComp = gameObject.GetComponent<Animator>();
        }

        public void Update()
        { 
            AnimatorComp.UpdateAnim(AgentComp.velocity);
            if (!Patient.EnAttente && AgentComp.remainingDistance < 2f)
            {
                Destination.Add(Patient);
            }
        }
    }
}