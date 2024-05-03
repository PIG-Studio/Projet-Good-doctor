using ScriptableObject;
using UnityEngine;

namespace InventoryTwo
{
    public class PickUpItem : MonoBehaviour
    {
        public ItemsSo item;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CompareTag("Player"))
            {
                InventoryManager.instance.inventory.Add(item);
                Destroy(gameObject);
            }
        }
    }
}
    
