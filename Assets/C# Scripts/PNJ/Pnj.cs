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
            AnimatorComp.UpdateAnim(AgentComp.velocity);
            if (Patient.EnAttente || AgentComp.remainingDistance > 2f) return;
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    if (deskDestination.IsFull)
                    {
                        Debug.Log("Destination pleine, recherche d'une autre destination");
                        Patient.ChooseDestination();
                        return;
                    }
                    deskDestination.Add(Patient);
                    break;
                case INormalDestination normalDestination:
                    if (normalDestination.IsFull)
                    {
                        Debug.Log("Destination pleine, recherche d'une autre destination");
                        Patient.ChooseDestination();
                        return;
                    }
                    normalDestination.Add(Patient);
                    break;
            }
        }
    }
}