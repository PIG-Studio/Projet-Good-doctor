using System.Collections.Generic;
using UI_Prefab;
using UnityEngine;
using static GameCore.Variables;
/// <summary>
/// A utiliser pour afficher les boutons et ui des parametres
/// </summary>
public class UIParameters : MonoBehaviour
{
    // Start est appele des l'arrivee sur la scene
    void Start()
    {
        // Initialisation du dictionnaire
        Dictionary<string, GameObject> dicoRender =
            new Dictionary<string, GameObject>
                () { };
        
        // Ajout des elements a afficher
        dicoRender["Retour"] = UI_Prefabs.BTN_ChangeScene("Retour", "Retour", -500f, 300f, 150f, 50f, SceneNameLast);
        dicoRender["Resolution"] = UI_Prefabs.DDW_Default<PARAMResolutions>("DDW_Resolutions", "Resolutions", -300, 100, 175, 80);
        dicoRender["Windowed"] = UI_Prefabs.DDW_Default<PARAMWindowMode>("DDW_Windowed", "Windowed", 0, 100, 175, 80);
        dicoRender["Hz"] = UI_Prefabs.DDW_Default<PARAMHzRate>("DDW_HZ", "HZ", 300, 100, 175, 80);
        
        // Affichage des elements
        UI_Prefabs.Render("UI_ParamCanvas", dicoRender);
    }
}
