using UnityEngine;

namespace Super.Interfaces
{
    public interface ISyncOnConnectRpc
    {
        void SyncOnConnectServerRpc();
        void SyncOnConnectClientRpc(string phrase, Animator skin);
    }
}