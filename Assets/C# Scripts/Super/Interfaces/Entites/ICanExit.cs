using Unity.Netcode;

namespace Super.Interfaces.Entites
{
    public interface ICanExit
    {
        [ServerRpc]
        public void RenvoyerMaisonServerRpc();
        
        [ClientRpc]
        public void RenvoyerMaisonClientRpc();
        
    }
}