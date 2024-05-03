using CustomScenes;
using GameCore.GameVAR;
using Patient;
using TypeExpand.String;
using UnityEngine;
using Patient.Base;

namespace GameCore.GameMethods
{
    public class GameTick : MonoBehaviour
    {
        public void Update()
        {
            if (Variables.SceneNameCurrent.IsDesk() || Variables.SceneNameCurrent == Scenes.MAP)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    PatientBase guillaume = Patients.GenPatient();
                    if (guillaume is not null)
                        Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
                                  guillaume.Adn);
                    Debug.Log("Patient a l'entrée de l'hôpital !");
                }
            }
        }
    }
}