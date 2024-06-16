using Inventories.Player;
using ScriptableObject;
using UnityEngine;

namespace Inventories
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
            ItemsSo newItem = item.CopyItem();
            
            other.transform.Find("InventoryManager").GetComponent<PlayerInventory>().AddItem(newItem);

            Destroy(gameObject); // Détruit l'objet ramassé
        }
    }
}
    
