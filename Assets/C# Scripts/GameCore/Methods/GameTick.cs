using CustomScenes;
using GameCore.Variables;
using Patient;
using TypeExpand.String;
using UnityEngine;
using Patient.Base;

namespace GameCore.Methods
{
    
    public class GameTick : MonoBehaviour
    {
        GameObject _patient = Resources.Load<GameObject>("Prefabs/Patient");
        public void Update()
        {
            if (!Variable.SceneNameCurrent.IsDesk() && Variable.SceneNameCurrent != Scenes.Map) return;
            if (!Input.GetKeyDown(KeyCode.P)) return;
            
            var guillaume = Instantiate(_patient).GetComponent<PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient>();
            Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
                      guillaume.Adn);
            Debug.Log("Patient a l'entrée de l'hôpital !");
        }
    }
}