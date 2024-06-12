using ScriptableObject;
using UnityEngine;

namespace InventoryTwo.Player
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
            ItemsSo newItem = UnityEngine.ScriptableObject.CreateInstance<ItemsSo>();
            newItem.title = item.title;
            newItem.description = item.description;
            newItem.amount = item.amount;
            newItem.icon = item.icon;
            newItem.isStackable = item.isStackable;
            newItem.type = item.type;
            
            

            Destroy(gameObject); // Détruit l'objet ramassé
        }
    }
}
    
