using UnityEngine.AI;

namespace Super.Interfaces.Patient
{
    public interface IMobile
    {
        /// <summary>
        /// Obtient l'agent de navigation associé à l'objet mobile.
        /// </summary>
        NavMeshAgent Navigation { get; }
    }
}