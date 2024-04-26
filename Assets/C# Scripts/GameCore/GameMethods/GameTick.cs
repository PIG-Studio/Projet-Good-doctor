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
                    Patients.GenPat();
                    Debug.Log("Patient a l'entrée de l'hôpital !");
                }
            }
            
        }
    }
}