using System.Collections.Generic;
using UnityEngine;
using UI_Prefab;

/// <summary>
/// A utiliser pour afficher les boutons et ui du menu
/// </summary>
public class UI_Menu : MonoBehaviour
{
    // Start est appele des l'arrivee sur la scene
    void Start()
    {
        Dictionary<string, GameObject> dicoRender =
            new Dictionary<string, GameObject>
                () { };
        // Initialisation du dictionnaire
        
        dicoRender["Parametres"] = UI_Prefabs.BTN_ChangeScene("Parameters", "", -500f, 300f, 100f, 100f, "Parameters", "Button/prettyButton/Gear-Default");
        dicoRender["Quit"] = UI_Prefabs.BTN_Quit("Quit", "Quit", -300f, -100f, 150f, 50f);
        dicoRender["InputGameName"] = UI_Prefabs.INSTR_Default("input", 300f, -100f, 150f, 50f);
        dicoRender["NewGame"] = UI_Prefabs.BTN_NewGame("NewGame", "New Game", 300f, 100f, 150f, 50f);
        dicoRender["LoadGame"] = UI_Prefabs.DDW_Default<LastSave>("LoadGame", "Load Game", 300f, 0f, 150f, 50f);
        // Ajout des elements a afficher
        
        UI_Prefabs.Render("UI_MenuCanvas", dicoRender);
        // Affichage des elements
    }

}
