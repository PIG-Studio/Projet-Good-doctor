using Interfaces.Entites;

namespace Interfaces.Destination
{
    public interface INormalDestination : IDestination
    {
        public uint Add(ICanGoInDestination entity);
        public void Pop(uint siege);
    }
}