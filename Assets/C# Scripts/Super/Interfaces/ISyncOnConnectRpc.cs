namespace Super.Interfaces
{
    public interface ISyncOnConnectRpc
    {
        void SyncOnConnectServerRpc();
        void SyncOnConnectClientRpc(string phrase, uint skin, bool collisionsEnabled, uint temperature, uint depression);
    }
}