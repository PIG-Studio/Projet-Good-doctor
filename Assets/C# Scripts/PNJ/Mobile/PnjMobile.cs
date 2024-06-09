using PNJ.Base;
using Super.Interfaces.Patient;

namespace PNJ.Mobile
{
    public class PnjMobile : Pnj, IMobile 
    {
        public UnityEngine.AI.NavMeshAgent Navigation { get; protected set; }

        public new void Start()
        {
            base.Start();
            Navigation = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

    }
}