using GameCore;
using Unity.Netcode;
using UnityEngine;

[GenerateSerializationForType(typeof(Desk))]
public class NetworkVariables : NetworkBehaviour
{
    private readonly NetworkVariable<Desk> inv = new(writePerm:NetworkVariableWritePermission.Owner);

    void Update()
    {
        if (!NetworkManager.Singleton.IsClient)
        {
            inv.Value = Variables.Desk_Base;
        }
        else
        {
            Variables.Desk_Base = inv.Value;
        }
        Debug.Log(Variables.Desk_Base.Inventory.Slots[0].Amount);
    }


}
