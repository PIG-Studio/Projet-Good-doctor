using GameCore.Variables;
using CustomScenes;
using UnityEngine;
using Parameters;

namespace Interaction.Implementation
{
    public class RentrerDansBureau : MonoBehaviour
    {
        public void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKeyDown(Keys.UseKey)){Debug.Log("E key was pressed");}
            if (other.CompareTag("Player")){Debug.Log("Player touched");}
            if (Input.GetKeyDown(Keys.UseKey) && other.CompareTag("Player"))
            {
                Manager.ChangeScene(Variable.Desk.SceneName);
            }
        }
    }
}