using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI_Scripts.UI_Prefab.UI_Objects;
using GameCore.Methods;
using GameCore.Variables;
using static CustomScenes.Manager;
using Interfaces;
using SaveScripts;
using UI_Scripts.UI_Prefab.UI_Objects.UI_Dropdown;

namespace UI_Scripts.UI_Prefab
{
    public class UIPrefabs : MonoBehaviour
    {
        /// <summary>
        /// <value>FINI</value>
        /// Cree un nouveau canvas et y ajoute les objects du dico.
        /// </summary>
        /// <param name="canvasName">Nom a donner au canvas</param>
        /// <param name="dicoUiComponents">Dictionnaire des objets a afficher</param>
        public static GameObject Render(string canvasName, Dictionary<string, GameObject> dicoUiComponents)
        {
            GameObject canvas = new GameObject(canvasName);
            canvas.AddComponent<RectTransform>();
            canvas.transform.position = new Vector3(0, 0);
            canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);
            canvas.AddComponent<GraphicRaycaster>();

            foreach (var cle in dicoUiComponents.Keys)
            {
                GameObject temp = dicoUiComponents[cle];
                temp.transform.SetParent(canvas.transform, false);
            }

            return canvas;
        }

        /// <summary>
        /// <value>FINI</value>
        /// Cree un bouton qui change de scene.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="newScene"></param>
        /// <param name="resourcePath"></param>
        /// <returns></returns>
        public static GameObject BTN_ChangeScene(string id, string text, float posX, float posY, float width,
            float height, string newScene, string resourcePath = "")
        {
            /* Renvoie un nouveau bouton changent de scene vers le param newScene */
            return UIButton.Create(id, text, posX, posY, width, height,
                () => ChangeScene(newScene),
                resourcePath);
        }

        /// <summary>
        /// <value>FINI</value>
        /// Cree un bouton qui quitte le jeu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static GameObject BTN_Quit(string id, string text, float posX, float posY, float width,
            float height)
        {
            return UIButton.Create(id, text, posX, posY, width, height, () => Quit());
        }


        /// <summary>
        /// <value>FINI</value>
        /// Cree un champ de texte.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static GameObject INSTR_Default(string id, float posX, float posY, float width, float height)
        {
            return UIInputField.Create(id, posX, posY, width, height);
        }

        /// <summary>
        /// <value>FINI</value>
        /// Cree un bouton qui lance une nouvelle partie.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="resourcePath"></param>
        /// <returns></returns>
        public static GameObject BTN_NewGame(string id, string text, float posX, float posY, float width,
            float height, string resourcePath = "")
        {
            return UIButton.Create(id, text, posX, posY, width, height,
                () => Method.NewGame(Variable.SaveName), resourcePath); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
        }

        /// <summary>
        /// <value>FINI</value>
        /// Cree un bouton qui sauvegarde la partie.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static GameObject BTN_Save(string id, string text, float posX, float posY, float width,
            float height)
        {
            return UIButton.Create(id, text, posX, posY, width, height,
                () => SaveData.SaveGame()); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
        }

        /// <summary>
        /// <value>FINI</value>
        /// Cree une liste deroulante avec les parametres donnes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        ///  <returns>La liste deroulante cree</returns>
        public static GameObject DDW_Default<T>(string id, string text, float posX, float posY, float width,
            float height) where T : MonoBehaviour, IDropdownable
        {
            return UIDropdown.Create<T>(id, text, posX, posY, width, height); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
        }
        
        /// <summary>
        /// <value>WIP</value>
        /// Cree un bouton qui charge une sauvegarde specifique.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static GameObject BTN_Load(string id,string text, float posX, float posY, float width, float height)
        {
            //return UI_Button.Create(id, text, posX, posY,width, height, () => SaveLoadMethods.LoadSpecSave()); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
            //onclick saveloadMethods.loadspecSave(SavedeMenuesValues) + custome scene manager change scene
            return new GameObject();// TODO : A DEGAGER QUAND FINI
        }
        
        
        /// <summary>
        /// <value>WIP</value>
        /// Cree un slot d'inventaire.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="index"></param>
        /// <param name="empty"></param>
        /// <returns></returns>
        public static GameObject INV_Slot(Sprite sprite, uint index, bool empty = false)
        {
            return UISlot.Create(sprite, index, empty);
        }
        
        /// <summary>
        /// <value>WIP</value>
        /// Cree un slot d'inventaire.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="id"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static GameObject INV_Inventory(Sprite sprite, string id, float posX, float posY, float width, float height)
        {
            return UIInventory.Create(posX, posY, width, height, sprite, id);
        }

        
        /// <summary>
        /// <value>WIP</value>
        /// Cree un bouton qui charge une sauvegarde specifique.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static GameObject BTN_NextPatient(string id,string text, float posX, float posY, float width, float height)
        {
            return UIButton.Create(id, text, posX, posY, width, height, () =>
            {
                if (Variable.DeskBase != null)
                {
                    Debug.Log(Variable.DeskBase+ " HEYYYYYYYYYYYYYYYYYY");Variable.DeskBase.NextPatient();
                    
                }
            });
        }
        
        
        /// <summary>
        /// test method, kinda useless
        /// </summary>
        public static void Test()
        {
            Dictionary<string, GameObject> dicoBtn =
                new Dictionary<string, GameObject>();
            dicoBtn["testBTN"] = BTN_Quit("Quit", "Quit", -300f, -300f, 150f, 75f);
            Render("testCanv", dicoBtn);
        }

    }
}