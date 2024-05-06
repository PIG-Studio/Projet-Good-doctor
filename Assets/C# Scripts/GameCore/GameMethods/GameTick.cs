using CustomScenes;
using GameCore.Variables;
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
            if (!Variable.SceneNameCurrent.IsDesk() && Variable.SceneNameCurrent != Scenes.Map) return;
            if (!Input.GetKeyDown(KeyCode.P)) return;
            PatientBase guillaume = Patients.GenPatient();
            if (guillaume is null) return;
            Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
                      guillaume.Adn);
            Debug.Log("Patient a l'entrée de l'hôpital !");
        }
    }
}