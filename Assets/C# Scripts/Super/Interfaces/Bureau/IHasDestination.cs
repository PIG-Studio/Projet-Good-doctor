using JetBrains.Annotations;
using Super.Interfaces.Destination;

namespace Super.Interfaces.Bureau
{
    public interface IHasDestination
    {
        [NotNull] IDeskDestination AssociatedDestination { get; }
    }
}