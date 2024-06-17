using System.Collections.Generic;
using CustomScenes;
using UI_Scripts.UI_Prefab;
using UnityEngine;
using UnityEngine.UI;

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
                UIPrefabs.BTN_ChangeScene("Parameters", "Parametres", -200f, -400f, 150f, 150f, Scenes.Param);
            dicoRender["Parametres"].GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/prettyButton/Blue-Square-Default");
            dicoRender["Menu"] = UIPrefabs.BTN_ChangeScene("Menu", "Menu", -200f, -225f, 150f, 150f, Scenes.Menu);
            dicoRender["Menu"].GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/prettyButton/Blue-Square-Default");
            dicoRender["Map"] = UIPrefabs.BTN_ChangeScene("Map", "Map", 825f, 300f, 200f, 100f, Scenes.Map);
            dicoRender["Map"].GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/prettyButton/Blue-Square-Default");
            dicoRender["NextPatient"] = UIPrefabs.BTN_NextPatient("NextPat", "Patient suivant", 825f, 150f, 200f, 100f);
            dicoRender["NextPatient"].GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/prettyButton/Blue-Square-Default");
            dicoRender["RenvoyerPatient"] = UIPrefabs.BTN_RenvoyerPatientMaison("returnPat", "Renvoyer a la maison", 825f, 0f, 200f, 100f);
            dicoRender["RenvoyerPatient"].GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/prettyButton/Blue-Square-Default");
            
            // Affichage des elements
            UIPrefabs.Render("UI_DESK_BaseCanvas", dicoRender);

        }

    }
}