using JetBrains.Annotations;
using UnityEngine;

namespace Interfaces.Entites
{
    public interface ICanGoInDesk : ICanGoInDestination
    {
        bool DansBureau { get; set; }
        [CanBeNull] Sprite AltSprite { get; set; }
        void EnterBureau();
        void SortirBureau();
    }
}