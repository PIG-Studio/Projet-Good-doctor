using UnityEngine.AI;

namespace Super.Interfaces
{
    public interface IHasNavMesh
    {
        NavMeshAgent Agent { get; }
    }
}