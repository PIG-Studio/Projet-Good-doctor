using JetBrains.Annotations;
using UnityEngine;

namespace Super.Interfaces
{
    public interface IHasPrefabObject
    {
        [NotNull] GameObject Prefab { get; }
    }
}