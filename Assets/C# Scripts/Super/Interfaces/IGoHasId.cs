using JetBrains.Annotations;

namespace Interfaces
{
    public interface IGoHasId
    {
        [NotNull] string Id { get; }
    }
}