using Interfaces;
using UI_Scripts.UI_Prefab.UI_Base;
using UnityEngine;
using GameCore.Constantes;

namespace UI_Scripts.UI_Prefab.UI_Objects
{
    public class UISlot : IUiCreate
    {
        public static GameObject Create(Sprite sprite, uint index, bool empty)
        {
            GameObject slot = UIBaseWithoutImage.Create("SLOT_" + index, Constante.InventorySlotPos.X + Constante.InventorySlotSize*index, Constante.InventorySlotPos.Y,
                Constante.InventorySlotWidth, Constante.InventorySlotWidth);
            slot.AddComponent<SpriteRenderer>().sprite = empty ? null : sprite;
            slot.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        
            return slot;
        }
    }
}