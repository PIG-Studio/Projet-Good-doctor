using System.Collections.Generic;
using CustomScenes;
using UI_Scripts.UI_Prefab;
using UnityEngine;

namespace UI_Scripts.UI_Scenes
{
    public class Map : MonoBehaviour
    {
        private GameObject _overlayCanvas;
        // Start est appele des l'arrivee sur la scene
        public void Start()
        {
            // Initialisation du dictionnaire des elements a afficher
            Dictionary<string, GameObject> dicoRender =
                new Dictionary<string, GameObject>
                    ();

            // Ajout des elements a afficher
            dicoRender["Parametres"] =
                UIPrefabs.BTN_ChangeScene("Parameters", "Parametres", -300f, 100f, 150f, 50f, Scenes.Param);
            dicoRender["Menu"] = UIPrefabs.BTN_ChangeScene("Menu", "Menu", -300f, -100f, 150f, 50f, Scenes.Menu);
            dicoRender["SaveGame"] = UIPrefabs.BTN_Save("SaveGame", "Save Game", 300f, 100f, 150f, 50f);

            // Affichage des elements, qui commencent caches
            _overlayCanvas = UIPrefabs.Render("UI_Overlay", dicoRender);
            _overlayCanvas.SetActive(false);
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _overlayCanvas.SetActive(!_overlayCanvas.activeSelf);
            }
        }
    }
}