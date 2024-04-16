using UI_Base;
using UnityEngine;
using UnityEngine.UI;
using static GameCore.Constantes;

namespace UI_Prefab.UI_Objects
{
    public class UI_Inventory : IUI_Create
    {
        public static GameObject Create(float posX, float posY, float width, float height, Sprite sprite, string id)
        {
            GameObject inv = UI_BaseWithoutImage.Create("INV_" + id, posX, posY, width, height);

            inv.AddComponent<SpriteRenderer>().sprite = sprite;
            inv.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        
            return inv;
        }
    }
}