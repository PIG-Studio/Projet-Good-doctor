using GameCore;
using Unity.Netcode;
using UnityEngine;

namespace Network
{
    public class Variables : NetworkBehaviour
    {
        private readonly NetworkVariable<Desk> inv = new(writePerm:NetworkVariableWritePermission.Owner);

        void Update()
        {
            if (IsOwner)
            {
                inv.Value = Desks.Desk_Base;
            }
            else
            {
                Desks.Desk_Base = inv.Value;
            }
            Debug.Log(Desks.Desk_Base.Inventory.Slots.Length);
        }


    }
}