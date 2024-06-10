using Unity.Netcode.Components;

namespace Network
{
    public class OwnerNetworkAnimator : NetworkAnimator
    {
        /// <summary>
        /// Méthode de base pour déterminer si l'animation est autoritaire côté serveur
        /// </summary>
        /// <returns></returns>
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}