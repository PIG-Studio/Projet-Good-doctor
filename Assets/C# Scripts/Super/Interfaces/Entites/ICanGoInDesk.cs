using JetBrains.Annotations;
using Unity.Netcode;
using UnityEngine;

namespace Interfaces.Entites
{
    public interface ICanGoInDesk : ICanGoInDestination
    {
        NetworkVariable<bool> DansBureau { get; set; }
        [CanBeNull] Sprite AltSprite { get; set; }
        void EnterBureau();
        void SortirBureau();
    }
}