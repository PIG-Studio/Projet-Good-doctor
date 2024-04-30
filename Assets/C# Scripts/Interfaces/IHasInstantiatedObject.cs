using JetBrains.Annotations;
using UnityEngine;

namespace Interfaces
{
    public interface IHasInstantiatedObject
    {
        [NotNull] GameObject InstantiatedObject { get; set; }
    }
}