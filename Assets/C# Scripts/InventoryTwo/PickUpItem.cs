using InventoryTwo;
using ScriptableObject;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public ItemsSo item;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!CompareTag("Player")) return;
        InventoryManager.instance.inventory.Add(item);
        Destroy(gameObject);
    }
}
    
