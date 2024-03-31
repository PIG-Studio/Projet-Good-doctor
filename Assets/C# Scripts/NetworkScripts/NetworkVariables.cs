using GameCore;
using Unity.Netcode;
using UnityEngine;

namespace Network
{
    [GenerateSerializationForGenericParameter(0)]
    public class Variables<T> : NetworkBehaviour where T : Desk
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
}