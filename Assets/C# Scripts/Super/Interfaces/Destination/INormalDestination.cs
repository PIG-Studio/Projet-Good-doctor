using Interfaces.Entites;

namespace Interfaces.Destination
{
    public interface INormalDestination : IDestination
    {
        /// <summary>
        /// Ajoute une entité à la destination.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public uint Add(ICanGoInDestination entity);
        
        /// <summary>
        ///  Retire une entité de la destination.
        /// </summary>
        /// <param name="siege"></param>
        public void Pop(uint siege);
    }
}