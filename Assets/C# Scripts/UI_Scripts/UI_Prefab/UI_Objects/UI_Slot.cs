using UI_Base;
using UnityEngine;
using static GameCore.Constantes;

namespace UI_Prefab.UI_Objects
{
    public class UI_Slot : IUI_Create
    {
        public static GameObject Create(Sprite sprite, uint index, bool empty)
        {
            GameObject slot = UI_BaseObject.Create("SLOT_" + index, Invetory_Slot_Pos.X + Invetory_Slot_Size*index, Invetory_Slot_Pos.Y+ Invetory_Slot_Size*index,
                Invetory_Slot_Width, Invetory_Slot_Width);
            if (empty)
            {
                slot.AddComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
            else
            {
                slot.AddComponent<SpriteRenderer>().sprite = sprite;
            }
            slot.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        
            return slot;
        }
    }
}