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
        
        /// <summary>
        /// Permet à l'entité de choisir une destination.
        /// </summary>
        void ChooseDestination();
        
        /// <summary>
        /// Démarre le processus d'attente pour l'entité.
        /// </summary>
        void StartWaiting();
        
        /// <summary>
        /// Termine le processus d'attente pour l'entité.
        /// </summary>
        void EndWaiting();
    }
}