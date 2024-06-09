using JetBrains.Annotations;
using UnityEngine;

namespace Interfaces
{
    public interface IHasPrefabObject
    {
        [NotNull] GameObject Prefab { get; }
    }
}