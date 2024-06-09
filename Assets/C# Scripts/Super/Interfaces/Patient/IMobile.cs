using UnityEngine.AI;

namespace Super.Interfaces.Patient
{
    public interface IMobile
    {
        NavMeshAgent Navigation { get; }
    }
}