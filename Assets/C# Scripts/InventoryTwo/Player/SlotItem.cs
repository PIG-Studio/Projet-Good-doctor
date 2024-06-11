using InventoryTwo.Player;
using UnityEngine;

public class SlotItem : MonoBehaviour // va dans dans un componenet de prefab de slotItem
{
    public int itemSlot;// l'indice du slot dans l'inventaire

    public void ChargeItem()
    {
        InventoryManager.Instance.ChargeItem(itemSlot);
    }
}