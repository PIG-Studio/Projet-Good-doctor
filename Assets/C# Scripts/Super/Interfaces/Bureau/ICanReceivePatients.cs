using Interfaces.Entites;
using JetBrains.Annotations;

namespace Interfaces.Bureau
{
    public interface ICanReceivePatients
    {
        /// <summary>
        /// Le patient actuellement dans le bureau, s'il y en a un.
        /// </summary>
        [CanBeNull] public ICanGoInDesk CurrentPatient { get;}
        
        /// <summary>
        /// Passe au patient suivant dans la file d'attente.
        /// </summary>
        void NextPatient();
    }
}