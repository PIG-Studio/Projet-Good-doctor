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
            ItemsSo newItem = new ItemsSo(item.title, item.description, item.icon, item.amount, item.isStackable,
                item.type);
            for (int i = 0; i < InventoryManager.Instance.inventory.Count; i++)
            {
                if (item.title == InventoryManager.Instance.inventory[i].title && item.isStackable &&
                    InventoryManager.Instance.inventory.Count > 0)
                {
                    newItem.amount += InventoryManager.Instance.inventory[i].amount;
                    InventoryManager.Instance.inventory.Remove(InventoryManager.Instance.inventory[i]);
                }
            }
            InventoryManager.Instance.inventory.Add(newItem);// Ajoute l'objet à l'inventaire

            Destroy(gameObject); // Détruit l'objet ramassé
        }
    }
}
    
