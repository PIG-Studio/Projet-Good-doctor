using UI_Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI_Objects
{
    public class UI_Button : IUI_Create
    {
        /// <summary>
        /// <value>Working as expected</value>
        /// uses base methods to instantiate a new button
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="onClickActon"></param>
        /// <param name="resourcePath"></param>
        /// <returns></returns>
        public static GameObject Create(string id, string text, float posX, float posY, float width, float height, UnityAction onClickActon, string resourcePath = "")
        {
            GameObject button;
            if (resourcePath != "")
                button = UI_BaseObject.Create("BTN_" + id, posX, posY, width, height, resourcePath); 
            else 
                button = UI_BaseObject.Create("BTN_" + id, posX, posY, width, height);
            // On instancie un nouvel objet qui sera notre bouton
            // avec les parametres donnes
        
            GameObject label = UI_TextComponent.Create(text);
            label.transform.SetParent(button.transform, false);
            // On ajoute un texte a l'objet
        
            button.AddComponent<Button>().onClick.AddListener(onClickActon);
            // On ajoute une action a faire a l'objet
        
            return button;
            // On retourne le bouton
        }
    }
}