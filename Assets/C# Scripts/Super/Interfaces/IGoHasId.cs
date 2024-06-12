using JetBrains.Annotations;

namespace Super.Interfaces
{
    public interface IGoHasId
    {
        [NotNull] string Id { get; }
    }
}