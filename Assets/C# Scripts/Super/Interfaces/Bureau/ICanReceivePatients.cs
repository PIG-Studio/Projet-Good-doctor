using Interfaces.Entites;
using JetBrains.Annotations;

namespace Interfaces.Bureau
{
    public interface ICanReceivePatients
    {
        [CanBeNull] public ICanGoInDesk CurrentPatient { get;}
        
        void NextPatientServerRpc();
    }
}