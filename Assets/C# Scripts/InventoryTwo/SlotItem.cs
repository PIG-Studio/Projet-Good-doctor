using System.Collections;
using System.Collections.Generic;
using InventoryTwo;
using UnityEngine;

public class SlotItem : MonoBehaviour
{
    public int itemSlot;

    public void ChargeItem()
    {
        InventoryManager.instance.ChargeItem(itemSlot);
    }
}