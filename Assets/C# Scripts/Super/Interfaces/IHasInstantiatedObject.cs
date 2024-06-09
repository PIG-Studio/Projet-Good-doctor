using JetBrains.Annotations;
using UnityEngine;

namespace Interfaces
{
    public interface IHasInstantiatedObject
    {
        [CanBeNull] GameObject InstantiatedObject { get; set; }
    }
}