using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts.UI_Prefab.UI_Base
{
    public class UIBaseObject : IUiCreate
    {
        /// <summary>
        /// <value>Working as expected</value>
        /// Instantiate a GameObject with common parameters for GameObject, like canvas renderer, rect transform, ...
        /// </summary>
        /// <param name="id">Id de l'objet, non unique</param>
        /// <param name="posX">Position X relative au centre de l'ecran</param>
        /// <param name="posY">Position Y relative au centre de l'ecran</param>
        /// <param name="width">Largeur de l'objet</param>
        /// <param name="height">Hauteur de l'objet</param>
        /// <param name="resourcePath">Chemin de la ressource a charger</param>
        /// <returns></returns>
        public static GameObject Create(string id, float posX, float posY, float width, float height, string resourcePath = "Button/Blue gradient")
        {
            GameObject newObject = new GameObject(id);
            // On instancie un nouvel objet avec son id
        
            newObject.AddComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            newObject.transform.localPosition = new Vector3(posX, posY);
            newObject.AddComponent<CanvasRenderer>();
            newObject.AddComponent<Image>().sprite = Resources.Load<Sprite>(resourcePath);
            newObject.GetComponent<Image>().type = Image.Type.Sliced;
            // On y ajoute des component utile a de nombreux objets
        
            return newObject;
            // On retourne l'objet
        }
    }
}