using GameCore;
using Unity.Netcode;

[GenerateSerializationForType(typeof(Inventory))]
public class NetworkVariables : NetworkBehaviour
{
    private readonly NetworkVariable<int> Score1 = new(writePerm: NetworkVariableWritePermission.Server);


    void Update()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            Score1.Value = Variables.ScoreJ1;

        }
        
        else if (NetworkManager.Singleton.IsClient)
        {
            Variables.ScoreJ1 = Score1.Value;

        }
    }
}
