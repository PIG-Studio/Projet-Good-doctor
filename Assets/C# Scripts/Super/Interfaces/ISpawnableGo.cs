namespace Super.Interfaces
{
    public interface ISpawnableGo : IGoHasId, IHasPrefabObject, IHasInstantiatedObject, IHasAnimator, IHasNavMesh
    {
        void Spawn();
    }
}