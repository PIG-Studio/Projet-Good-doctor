using System.Collections.Generic;
using UI_Prefab;
using UnityEngine;

/// <summary>
/// A utiliser pour afficher les boutons et ui du bureau de base
/// </summary>
public class UI_DESK_Base : MonoBehaviour
{
    // Start est appele des l'arrivee sur la scene
    private void Start()
    {
        Dictionary<string, GameObject> dicoRender =
            new Dictionary<string, GameObject>
                () { };
        // Initialisation du dictionnaire
        
        dicoRender["Parametres"] = UI_Prefabs.BTN_ChangeScene("Parameters", "Parametres", -300f, 100f, 150f, 50f, "Parameters");
        dicoRender["Menu"] = UI_Prefabs.BTN_ChangeScene("Menu", "Menu", -300f, -100f, 150f, 50f, "Menu");
        dicoRender["SaveGame"] = UI_Prefabs.BTN_Save("SaveGame", "Save Game", 300f, 100f, 150f, 50f);
        dicoRender["Map"] = UI_Prefabs.BTN_ChangeScene("Map", "Map", 300f, -100f, 150f, 50f, "MapHospital");
        // Ajout des elements a afficher
        
        GameObject canv = UI_Prefabs.Render("UI_DESK_BaseCanvas", dicoRender);
        // Affichage des elements
    }
}