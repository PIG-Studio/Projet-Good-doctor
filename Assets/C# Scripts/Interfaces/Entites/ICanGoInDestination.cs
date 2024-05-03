using Interfaces.Destination;

namespace Interfaces.Entites
{
    public interface ICanGoInDestination
    {
        IDeskDestination Destination { get; set; }
        bool EnAttente { get; set; }
        uint Siege { get; set; }
        
        void ChooseDestination();
        void StartWaiting();
        
        void EndWaiting();
    }
}