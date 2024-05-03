using System;
using CustomScenes;
using GameCore.GameVAR;
using Patient;
using Personnel;
using TypeExpand.String;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
namespace GameCore.GameMethods
{
    public class GameTick : MonoBehaviour
    {
        public void Start()
        {
                Janine janine = new Janine();
            
        }

        public void Update()
        {
            if (Variables.SceneNameCurrent.IsDesk() || Variables.SceneNameCurrent == Scenes.Map)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Patient.Patient guillaume = Patients.GenPatient();
                    if (guillaume != null)
                        Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
                                  guillaume.Adn);
                    Debug.Log("Patient a l'entrée de l'hôpital !");
                }
            }
        }
    }
}