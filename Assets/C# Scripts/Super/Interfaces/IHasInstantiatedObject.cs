using JetBrains.Annotations;
using UnityEngine;

namespace Super.Interfaces
{
    public interface IHasInstantiatedObject
    {
        [CanBeNull] GameObject InstantiatedObject { get; set; }
    }
}