using UnityEngine;

namespace GameObjectScripts.Unique_Objects_Scripts
{
    public class UniqueGameTick : MonoBehaviour
    {
        private static bool _created; // Variable statique pour indiquer si l'objet a été créé

        /// <summary>
        /// Méthode appelée au démarrage
        /// </summary>
        private void Start()
        {
            // Si l'objet a déjà été créé, détruit cette instance et arrête la méthode
            if (_created)
            {
                Destroy(gameObject);
                return;
            }

            _created = true;
        }
    }
}