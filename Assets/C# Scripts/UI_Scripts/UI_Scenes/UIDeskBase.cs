using System.Collections.Generic;
using CustomScenes;
using GameCore.Constantes;
using GameCore.Variables;
using UI_Scripts.UI_Prefab;
using UnityEngine;

namespace UI_Scripts.UI_Scenes
{


    /// <summary>
    /// A utiliser pour afficher les boutons et ui du bureau de base
    /// </summary>
    public class UIDeskBase : MonoBehaviour
    {
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
            dicoRender["Map"] = UIPrefabs.BTN_ChangeScene("Map", "Map", 300f, -100f, 150f, 50f, Scenes.Map);
            dicoRender["NextPatient"] = UIPrefabs.BTN_Generic("NextPat", "Patient suivant, 300f, -100f, 150f, 50f, Variable.DeskBase.NextPatient());
            
            // Affichage des elements
            UIPrefabs.Render("UI_DESK_BaseCanvas", dicoRender);

        }

    }
}