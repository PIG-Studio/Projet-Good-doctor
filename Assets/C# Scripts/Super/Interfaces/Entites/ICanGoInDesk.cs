using JetBrains.Annotations;
using UnityEngine;

namespace Interfaces.Entites
{
    public interface ICanGoInDesk : ICanGoInDestination
    {
        /// <summary>
        /// Indique si l'entité est actuellement dans un bureau.
        /// </summary>
        bool DansBureau { get; set; }
        
        /// <summary>
        /// Sprite
        /// </summary>
        [CanBeNull] Sprite AltSprite { get; set; }
        
        /// <summary>
        /// Action à effectuer lorsque l'entité entre dans un bureau.
        /// </summary>
        void GoInDesk();
        
        /// <summary>
        /// Action à effectuer lorsque l'entité sort du bureau.
        /// </summary>
        void SortirBureau();
    }
}