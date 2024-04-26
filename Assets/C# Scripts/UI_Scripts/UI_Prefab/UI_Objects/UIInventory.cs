using Interfaces.UI_Input_management;
using UIBase;
using UnityEngine;

namespace UI_Scripts.UI_Prefab.UI_Objects
{
    public class UIInventory : IUiCreate
    {
        public static GameObject Create(float posX, float posY, float width, float height, Sprite sprite, string id)
        {
            GameObject inv = UIBaseWithoutImage.Create("INV_" + id, posX, posY, width, height);

            inv.AddComponent<SpriteRenderer>().sprite = sprite;
            inv.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        
            return inv;
        }
    }
}