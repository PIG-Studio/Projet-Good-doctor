using Interfaces.Destination;
using JetBrains.Annotations;

namespace Interfaces.Bureau
{
    public interface IHasDestination
    {
        [NotNull] IDeskDestination AssociatedDestination { get; }
    }
}