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
    public class Pnj : APnj
    {
        protected NavMeshAgent AgentComp { get; set; }
        protected Animator AnimatorComp { get; set; }
        public IDestination Destination { get; protected set; }
        public ICanGoInDesk Patient { get; protected set; }
        private SpriteRenderer _spriteRenderer;
        
        public void Start()
        {
            AgentComp = gameObject.GetComponent<NavMeshAgent>();
            AnimatorComp = gameObject.GetComponent<Animator>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void Update()
        { 
            if (!IsHost) return;
            
            if (Variable.SceneNameCurrent == Scenes.Map) 
            { _spriteRenderer.enabled = true; AnimatorComp.UpdateAnim(AgentComp.velocity); }
            else 
            { _spriteRenderer.enabled = false; }

            // Moved to patient
            /*if (Patient.EnAttente || AgentComp.remainingDistance > 2f) return;
            
            if (Destination.IsFull)
            {
                Debug.Log("Destination pleine, recherche d'une autre destination");
                Patient.ChooseDestination();
                return;
            }
            
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    deskDestination.Add(Patient);
                    break;
                case INormalDestination normalDestination:
                    normalDestination.Add(Patient);
                    break;
            }*/
        }
    }
}