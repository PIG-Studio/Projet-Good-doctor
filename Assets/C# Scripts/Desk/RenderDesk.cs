using GameCore;
using Inventories;
using UnityEngine;
using UI_Prefab;

/// <summary>
/// script rendering the inventory of the desk
/// </summary>
public class RenderInventory : MonoBehaviour
{
    private Desk DesktoRender { get; set; }
    private Inventory InventorytoRender { get; set; }

    public void Start()
    {
        GameObject inventoryRender = UI_Prefabs.INV_Inventory(Resources.Load<Sprite>("inventory"), "Inventory", 0, 0, 500, 50);
        DesktoRender = Desk.SceneDeskDict[Variables.SceneName_Current];
        InventorytoRender = DesktoRender.Inventory;
        uint i = 0;
        GameObject slotRender;
        foreach (Slot vSlot in InventorytoRender.Slots)
        {
            if (vSlot.Amount == 0)
            {
                slotRender = UI_Prefabs.INV_Slot(vSlot.Image, i, true);
            }
            else
            {
                slotRender = UI_Prefabs.INV_Slot(vSlot.Image, i);
            }
            slotRender.transform.SetParent(transform);
            i++;
        }
    }
}