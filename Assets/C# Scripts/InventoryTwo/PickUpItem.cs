using ScriptableObject;
using UnityEngine;

namespace InventoryTwo
{
    public class PickUpItem : MonoBehaviour
    {
        public ItemsSo item;
        /// <summary>
        /// Méthode appelée lorsque l'objet entre en collision avec un autre
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter2D(Collider2D other)
        {
            // Vérifie si l'objet en collision n'a pas le tag "Player"
            if (!other.CompareTag("Player")) return;
            InventoryManager.Instance.inventory.Add(item); // Ajoute l'objet à l'inventaire
            Destroy(gameObject); // Détruit l'objet ramassé
        }
    }
}
    
