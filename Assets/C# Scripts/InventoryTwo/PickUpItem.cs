using ScriptableObject;
using UnityEngine;

namespace InventoryTwo
{
    public class PickUpItem : MonoBehaviour
    {
        public ItemsSo item;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            for (int i = 0; i < InventoryManager.Instance.inventory.Count; i++)
            {
                if (item.title == InventoryManager.Instance.inventory[i].title && item.isStackable &&
                    InventoryManager.Instance.inventory.Count > 0)
                {
                    item.amount += InventoryManager.Instance.inventory[i].amount;
                    InventoryManager.Instance.inventory.Remove(InventoryManager.Instance.inventory[i]);
                }
            }
            InventoryManager.Instance.inventory.Add(item);
            Destroy(gameObject);
        }
    }
}
    
