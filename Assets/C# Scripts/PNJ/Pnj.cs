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
        public IDestination Destination { get; set; }
        public ICanGoInDesk Patient { get; set; }
        
        public void Start()
        {
            AgentComp = gameObject.GetComponent<NavMeshAgent>();
            AnimatorComp = gameObject.GetComponent<Animator>();
        }

        public void Update()
        { 
            if (Patient.EnAttente || !(AgentComp.remainingDistance < 2f)) return;
            AnimatorComp.UpdateAnim(AgentComp.velocity);
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    deskDestination.Add(Patient);
                    break;
                case INormalDestination normalDestination:
                    normalDestination.Add(Patient);
                    break;
            }
        }
    }
}