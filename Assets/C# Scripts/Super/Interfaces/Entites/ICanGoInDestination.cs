using Interfaces.Destination;

namespace Interfaces.Entites
{
    public interface ICanGoInDestination
    {
        IDestination Destination { get; }
        bool EnAttente { get; }
        uint Siege { get; set; }
        
        void ChooseDestinationServerRpc();
        void StartWaitingServerRpc();
        void StartWaitingClientRpc();
        
        void EndWaitingServerRpc();
        void EndWaitingClientRpc();
    }
}