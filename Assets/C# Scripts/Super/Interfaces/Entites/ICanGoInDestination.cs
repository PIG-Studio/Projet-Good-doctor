using Interfaces.Destination;

namespace Interfaces.Entites
{
    public interface ICanGoInDestination
    {
        IDestination Destination { get; }
        bool EnAttente { get; }
        uint Siege { get; set; }
        
        void ChooseDestination();
        void StartWaiting();
        
        void EndWaiting();
    }
}