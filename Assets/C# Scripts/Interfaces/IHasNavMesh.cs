using UnityEngine.AI;

namespace Interfaces
{
    public interface IHasNavMesh
    {
        NavMeshAgent Agent { get; }
    }
}