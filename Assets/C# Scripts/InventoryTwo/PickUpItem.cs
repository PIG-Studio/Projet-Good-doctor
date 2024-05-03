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
            InventoryManager.Instance.inventory.Add(item);
            Destroy(gameObject);
        }
    }
}
    
