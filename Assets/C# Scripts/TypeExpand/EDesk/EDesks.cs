using Desks;
using Exceptions;
using JetBrains.Annotations;
using Unity.Netcode;
using UnityEngine;

namespace TypeExpand.EDesk
{
    public static class EDesks
    {
        [CanBeNull]
        public static Desk TrouverBureauLibre(this Desk[] desks)
        {
            foreach (var bureau in desks)
            {
                if (bureau.Responsable == null)
                {
                    return bureau;
                }
            }

            return null;
        }
        
        [ServerRpc]
        public static uint TrouverBureauLibreServerRpc(this Desk[] desks)
        {
            
            for (uint i = 0; i < desks.Length; i++)
            {
                Debug.Log(i);
                if (desks[i].Responsable == null)
                {
                    return i;
                }
            }

            throw new LogicException("Aucun bureau n'a été trouvé.");
        }
        
    }
}