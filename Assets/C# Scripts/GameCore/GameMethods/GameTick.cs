using CustomScenes;
using GameCore.GameVAR;
using GameCore.TypeExpand;
using Patient;
using UnityEngine;
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