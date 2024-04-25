using UIBase;
using UnityEngine;
using UnityEngine.UI;
using static GameCore.Constantes;

namespace UIPrefab.UIObjects
{
    public class UIInventory : IUI_Create
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