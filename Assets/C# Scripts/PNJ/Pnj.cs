using CustomScenes;
using GameCore.Variables;
using Interfaces;
using Interfaces.Destination;
using Interfaces.Entites;
using UnityEngine;
using UnityEngine.AI;
using TypeExpand.Animator;
using Unity.Netcode;

namespace PNJ
{
    public class Pnj : NetworkBehaviour
    {
        public NavMeshAgent AgentComp { get; private set; }

        public Animator AnimatorComp { get; private set; }
        public IDestination Destination { get; set; }
        public ICanGoInDesk Patient { get; set; }
        private SpriteRenderer _spriteRenderer;
        
        public void Start()
        {
            AgentComp = gameObject.GetComponent<NavMeshAgent>();
            AnimatorComp = gameObject.GetComponent<Animator>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void Update()
        { 
            if (Variable.SceneNameCurrent == Scenes.Map) 
            { _spriteRenderer.enabled = true; AnimatorComp.UpdateAnim(AgentComp.velocity); }
            else { _spriteRenderer.enabled = false; }

            if (Patient.EnAttente || AgentComp.remainingDistance > 2f) return;
            
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    if (deskDestination.IsFull)
                    {
                        Debug.Log("Destination pleine, recherche d'une autre destination");
                        Patient.ChooseDestination();
                        break;
                    }
                    deskDestination.Add(Patient);
                    break;
                case INormalDestination normalDestination:
                    if (normalDestination.IsFull)
                    {
                        Debug.Log("Destination pleine, recherche d'une autre destination");
                        Patient.ChooseDestination();
                        break;
                    }
                    normalDestination.Add(Patient);
                    break;
            }
        }
    }
}