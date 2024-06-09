using Interfaces.Destination;
using Interfaces.Entites;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

namespace Interfaces
{
    public abstract class APnj: NetworkBehaviour, ICanGoInDestination, IHas
    {
        protected abstract Sprite Skin { get; set; }
        public abstract string Name { get; protected set; }
        public abstract Vector2 Position { get; protected set; }
        public abstract IDestination Destination { get; protected set; }
        public abstract bool EnAttente { get; protected set; }
        public abstract uint Siege { get; protected set; }
        protected abstract NavMeshAgent AgentComp { get; set; }
        protected abstract Animator AnimatorComp { get; set; }
        
        public abstract void ChooseDestination();
        public abstract void StartWaiting();
        public abstract void EndWaiting();

    }
}