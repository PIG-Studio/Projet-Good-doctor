using System;
using InventoryTwo;
using UnityEngine;
using static ItemsSo;

public class PickUpItem : MonoBehaviour
{
    public ItemsSo item;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           InventoryManager.instance.inventory.Add(item);
           Destroy(gameObject);
        }
    }
}
    
