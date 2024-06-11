using System.Collections.Generic;
using Desks;
using Interfaces.Entites;

namespace Interfaces.Destination
{
    public interface IDeskDestination : IDestination
    {
        /// <summary>
        /// Bureau associé à la destination.
        /// </summary>
        public Desk Bureau { get; }
        
        /// <summary>
        /// File d'attente des entités pouvant entrer dans le bureau.
        /// </summary>
        public Queue<ICanGoInDesk> DeskQueue { get; set; }

        /// <summary>
        /// Ajoute une entité à la file d'attente.
        /// </summary>
        /// <param name="patient"></param>
        public void Add(ICanGoInDesk patient);
        
        /// <summary>
        /// Retire et renvoie l'entité en tête de file.
        /// </summary>
        /// <returns></returns>
        public ICanGoInDesk Pop();

    }
}