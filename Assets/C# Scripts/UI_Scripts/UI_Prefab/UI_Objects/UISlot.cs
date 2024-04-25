using UIBase;
using UnityEngine;
using static GameCore.Constantes;

namespace UIPrefab.UIObjects
{
    public class UISlot : IUI_Create
    {
        public static GameObject Create(Sprite sprite, uint index, bool empty)
        {
            GameObject slot = UIBaseWithoutImage.Create("SLOT_" + index, InventorySlotPos.X + InventorySlotSize*index, InventorySlotPos.Y,
                InventorySlotWidth, InventorySlotWidth);
            slot.AddComponent<SpriteRenderer>().sprite = empty ? null : sprite;
            slot.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        
            return slot;
        }
    }
}