using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UI_Scripts.UI_Prefab;
using CustomScenes;
using GameCore.Variables;
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
            Variable.SceneNameCurrent = Scenes.Menu;
            
            // Initialisation du dictionnaire des elements a afficher
            Dictionary<string, GameObject> dicoRender =
                new Dictionary<string, GameObject>
                    () ;

            // Ajout des elements a afficher
            dicoRender["Parametres"] = UIPrefabs.BTN_ChangeScene("Parameters", "", -700f, 400f, 100f, 80f,
                Scenes.Param, "Button/prettyButton/Gear-Default");
            dicoRender["Quit"] = UIPrefabs.BTN_Quit("Quit", "Quit", 0f, -350f, 225f, 75f);
            dicoRender["InputGameName"] = UIPrefabs.INSTR_Default("input", 0f, -150f, 225f, 75f);
            dicoRender["NewGame"] = UIPrefabs.BTN_NewGame("NewGame", "New Game", 0f, -50f, 225f, 75f);
            dicoRender["LoadGame"] = UIPrefabs.DDW_Default<LastSave>("LoadGame", "Load Game", 0f, -250f, 225f, 75f);
            
            // Affichage des elements
            UIPrefabs.Render("UI_MenuCanvas", dicoRender);
        }

    }
}