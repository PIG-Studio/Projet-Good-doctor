using Unity.Netcode;

namespace Network.Sync.Variables
{
    public class RandomVariables : NetworkBehaviour
    {
        private readonly NetworkVariable<int> _score1 = new(writePerm: NetworkVariableWritePermission.Server);


        void Update()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                //Score1.Value = Variables.ScoreJ1;

            }

            else if (NetworkManager.Singleton.IsClient)
            {
                //Variables.ScoreJ1 = Score1.Value;

            }
        }
    }
}