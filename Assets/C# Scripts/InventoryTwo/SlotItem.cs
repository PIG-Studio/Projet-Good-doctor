﻿using InventoryTwo;
using InventoryTwo.Player;
using UnityEngine;

public class SlotItem : MonoBehaviour // va dans dans un componenet de prefab de slotItem
{
    public int itemSlot;

    public void ChargeItem()
    {
        InventoryManager.Instance.ChargeItem(itemSlot);
    }
}