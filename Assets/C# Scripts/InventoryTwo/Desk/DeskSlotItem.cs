using InventoryTwo.Desk;
using UnityEngine;

public class DeskSlotItem : MonoBehaviour // va dans dans un componenet de prefab de slotItem
{
    public int itemSlot;// l'indice du slot dans l'inventaire

    public void ChargeItem()
    {
        DeskInventoryManager.InstanceDIM.ChargeItem(itemSlot);
    }
}