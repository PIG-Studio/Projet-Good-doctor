using GameCore;
using Inventories;
using Unity.Netcode;
using UnityEngine;

[GenerateSerializationForType(typeof(Inventory))]
public class NetworkVariables : NetworkBehaviour
{
    private readonly NetworkVariable<int> score1 = new(writePerm: NetworkVariableWritePermission.Server);

    void Update()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            score1.Value = Variables.ScoreJ1;
        }
        
        else if (NetworkManager.Singleton.IsClient)
        {
            Variables.ScoreJ1 = score1.Value;
        }
    }
}
