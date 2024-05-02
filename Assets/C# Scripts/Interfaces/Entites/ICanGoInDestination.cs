using Interfaces.Destination;

namespace Interfaces.Entites
{
    public interface ICanGoInDestination
    {
        IDestination Destination { get; set; }
        bool EnAttente { get; set; }
        void StartWaiting();
        
        void EndWaiting();
    }
}