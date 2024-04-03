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
            inv.Value = Desks.Desk_Base;
        }
        else
        {
            Desks.Desk_Base = inv.Value;
        }
        Debug.Log(Desks.Desk_Base.Inventory.Slots[0].Amount);
    }


}
