using System.Collections.Generic;
using UnityEngine;
using UI_Scripts.UI_Prefab;
using CustomScenes;
using Menu;

namespace UI_Scripts.UI_Scenes
{
    /// <summary>
    /// A utiliser pour afficher les boutons et ui du menu
    /// </summary>
    public class UIMenu : MonoBehaviour
    {
        // Start est appele des l'arrivee sur la scene
        void Start()
        {
            // Initialisation du dictionnaire des elements a afficher
            Dictionary<string, GameObject> dicoRender =
                new Dictionary<string, GameObject>
                    () ;

            // Ajout des elements a afficher
            dicoRender["Parametres"] = UIPrefabs.BTN_ChangeScene("Parameters", "", -500f, 300f, 100f, 100f,
                Scenes.PARAM, "Button/prettyButton/Gear-Default");
            dicoRender["Quit"] = UIPrefabs.BTN_Quit("Quit", "Quit", -300f, -100f, 150f, 50f);
            dicoRender["InputGameName"] = UIPrefabs.INSTR_Default("input", 300f, -100f, 150f, 50f);
            dicoRender["NewGame"] = UIPrefabs.BTN_NewGame("NewGame", "New Game", 300f, 100f, 150f, 50f);
            dicoRender["LoadGame"] = UIPrefabs.DDW_Default<LastSave>("LoadGame", "Load Game", 300f, 0f, 150f, 50f);

            // Affichage des elements
            UIPrefabs.Render("UI_MenuCanvas", dicoRender);
        }

    }
}