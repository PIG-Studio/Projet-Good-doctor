using Interfaces.UI_Input_management;
using TMPro;
using UnityEngine;

// Les methodes les + basiques pour creer des elements de l'UI
namespace UIBase
{
    public class UITextComponent : IUiCreate
    {
        /// <summary>
        ///  <value>Working as expected</value>
        ///  Methode creant un "text component", un objet pour pouvoir
        /// mettre du texte sur des button, input fields, ...
        ///  </summary>
        /// 
        /// <param name="textShown">string - Le texte a afficher par l'objet</param>
        /// <param name="name">string - id du composant a cree</param>
        /// <returns>GameObject - retourne le composant cree</returns>
        public static GameObject Create(string textShown, string name = "Text")
        {
            /* Prend un objet parent et lui cree et ajoute un component affichant du texte */

            Canvas.ForceUpdateCanvases();
            // TODO : utilite douteuse, a verifier
            
            GameObject text = new GameObject(name);
            // On cree un nouvel objet avec son nom
            
            text.AddComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            text.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            text.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
            text.AddComponent<CanvasRenderer>();
            text.AddComponent<TextMeshProUGUI>().text = textShown;
            text.GetComponent<TextMeshProUGUI>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
            text.GetComponent<TextMeshProUGUI>().horizontalAlignment = HorizontalAlignmentOptions.Center;
            text.GetComponent<TextMeshProUGUI>().verticalAlignment = VerticalAlignmentOptions.Middle;
            text.GetComponent<TextMeshProUGUI>().fontSize = 23;
            text.GetComponent<TextMeshProUGUI>().enableAutoSizing = false;

            return text;
        }
    }
}