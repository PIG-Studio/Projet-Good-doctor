using System.Collections.Generic;
using Parameters;
using UI_Scripts.UI_Prefab;
using UnityEngine;
using static GameCore.GameVAR.Variables;

namespace UI_Scripts.UI_Scenes
{
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
                    ();

            // Ajout des elements a afficher
            dicoRender["Retour"] = UIPrefabs.BTN_ChangeScene("Retour", "Retour", -500f, 300f, 150f, 50f, SceneNameLast);
            dicoRender["Resolution"] =
                UIPrefabs.DDW_Default<Resolutions>("DDW_Resolutions", "Resolutions", -300, 100, 175, 80);
            dicoRender["Windowed"] =
                UIPrefabs.DDW_Default<WindowMode>("DDW_Windowed", "Windowed", 0, 100, 175, 80);
            dicoRender["Hz"] = UIPrefabs.DDW_Default<HzRate>("DDW_HZ", "HZ", 300, 100, 175, 80);

            // Affichage des elements
            UIPrefabs.Render("UI_ParamCanvas", dicoRender);
        }
    }
}