using C__Scripts.Patient;
using C__Scripts.PNJ;
using GameCore.TypeExpand;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GameCore
{
    public class GameTick : MonoBehaviour
    {
        public void Update()
        { 
            if ((Variables.SceneName_Current.IsDesk() || Variables.SceneName_Current == Scenes.MAP) && Input.GetKeyDown(KeyCode.P))
            {
                Patients.GenPat();
                Debug.Log("Patient a l'entrée de l'hôpital !");
            }
            
        }
    }
}