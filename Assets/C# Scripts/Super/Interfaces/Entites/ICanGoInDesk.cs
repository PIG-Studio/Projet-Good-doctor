using JetBrains.Annotations;
using Unity.Netcode;
using UnityEngine;

namespace Interfaces.Entites
{
    public interface ICanGoInDesk : ICanGoInDestination
    {
        /// <summary>
        /// Indique si l'entité est actuellement dans un bureau.
        /// </summary>
        NetworkVariable<bool> DansBureau { get; set; }
        /// <summary>
        /// Sprite
        /// </summary>
        [CanBeNull] Sprite AltSprite { get; set; }
        
        [ServerRpc]
        void EnterBureauServerRpc();
        [ClientRpc]
        void EnterBureauClientRpc();
        
        [ServerRpc]
        void SortirBureauServerRpc(bool chercherNouvDest = true);
        [ClientRpc]
        void SortirBureauClientRpc();
    }
}