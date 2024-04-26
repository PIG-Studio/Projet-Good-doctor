using Interfaces.UI_Input_management;
using UIBase;
using UnityEngine;
using static GameCore.GameVAR.Constantes;

namespace UI_Scripts.UI_Prefab.UI_Objects
{
    public class UISlot : IUiCreate
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