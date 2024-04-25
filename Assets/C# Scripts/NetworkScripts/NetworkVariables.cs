using GameCore;
using Inventories;
using Unity.Netcode;
using UnityEngine;

[GenerateSerializationForType(typeof(Inventory))]
public class NetworkVariables : NetworkBehaviour
{
<<<<<<< HEAD
    private readonly NetworkVariable<int> Score1 = new(writePerm: NetworkVariableWritePermission.Server);
=======
    private readonly NetworkVariable<int> score1 = new(writePerm: NetworkVariableWritePermission.Server);
>>>>>>> dev_Alex

    void Update()
    {
        if (NetworkManager.Singleton.IsHost)
        {
<<<<<<< HEAD
            Score1.Value = Variables.ScoreJ1;
=======
            score1.Value = Variables.ScoreJ1;
>>>>>>> dev_Alex
        }
        
        else if (NetworkManager.Singleton.IsClient)
        {
<<<<<<< HEAD
            Variables.ScoreJ1 = Score1.Value;
=======
            Variables.ScoreJ1 = score1.Value;
>>>>>>> dev_Alex
        }
    }
}
