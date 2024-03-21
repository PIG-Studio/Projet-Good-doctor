using System.Collections.Generic;
using UI_Prefab;
using UnityEngine;

/// <summary>
/// A utiliser pour afficher les boutons et ui des parametres
/// </summary>
public class UI_Parameters : MonoBehaviour
{
    // Start est appele des l'arrivee sur la scene
    void Start()
    {
        Dictionary<string, GameObject> dicoRender =
            new Dictionary<string, GameObject>
                () { };
        // Initialisation du dictionnaire
        dicoRender["Retour"] = UI_Prefabs.BTN_ChangeScene("Retour", GameVariables.SceneName_Last, -500f, 300f, 150f, 50f, GameVariables.SceneName_Last);
        dicoRender["Resolution"] = UI_Prefabs.DDW_Default<PARAM_Resolutions>("DDW_Resolutions", "Resolutions", -300, 100, 175, 80);
        dicoRender["Windowed"] = UI_Prefabs.DDW_Default<PARAM_WindowMode>("DDW_Windowed", "Windowed", 0, 100, 175, 80);
        dicoRender["Hz"] = UI_Prefabs.DDW_Default<PARAM_HzRate>("DDW_HZ", "HZ", 300, 100, 175, 80);
        // Ajout des elements a afficher
        
        UI_Prefabs.Render("UI_ParamCanvas", dicoRender);
        // Affichage des elements
    }
}
