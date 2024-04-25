using System.Collections.Generic;
using GameCore;
using UI_Prefab;
using UnityEngine;

/// <summary>
/// A utiliser pour afficher les boutons et ui du bureau de base
/// </summary>
public class UIDESKBase : MonoBehaviour
{
    // Start est appele des l'arrivee sur la scene
    private void Start()
    {
        // Initialisation du dictionnaire des elements a afficher
        Dictionary<string, GameObject> dicoRender =
            new Dictionary<string, GameObject>
                () { };
        
        // Ajout des elements a afficher
        dicoRender["Parametres"] = UI_Prefabs.BTN_ChangeScene("Parameters", "Parametres", -300f, 100f, 150f, 50f, Scenes.PARAM);
        dicoRender["Menu"] = UI_Prefabs.BTN_ChangeScene("Menu", "Menu", -300f, -100f, 150f, 50f, Scenes.MENU);
        dicoRender["SaveGame"] = UI_Prefabs.BTN_Save("SaveGame", "Save Game", 300f, 100f, 150f, 50f);
        dicoRender["Map"] = UI_Prefabs.BTN_ChangeScene("Map", "Map", 300f, -100f, 150f, 50f, Scenes.MAP);
        
        // Affichage des elements
        UI_Prefabs.Render("UI_DESK_BaseCanvas", dicoRender);
        
    }

}