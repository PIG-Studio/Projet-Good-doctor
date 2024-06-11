using Interfaces.Destination;

namespace Interfaces.Entites
{
    public interface ICanGoInDestination
    {
        /// <summary>
        /// Obtient la destination actuelle de l'entité.
        /// </summary>
        IDestination Destination { get; }
        
        /// <summary>
        /// Indique si l'entité est actuellement en attente.
        /// </summary>
        bool EnAttente { get; }
        
        /// <summary>
        /// Obtient ou définit le numéro du siège de l'entité.
        /// </summary>
        uint Siege { get; set; }
        
        void ChooseDestinationServerRpc();
        void StartWaitingServerRpc();
        void StartWaitingClientRpc();
        
        void EndWaitingServerRpc();
        void EndWaitingClientRpc();
    }
}