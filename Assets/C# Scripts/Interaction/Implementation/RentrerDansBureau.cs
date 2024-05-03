using System;
using GameCore.GameVAR;
using CustomScenes;
using UnityEngine;

namespace Interaction.Implementation
{
    public class RentrerDansBureau : MonoBehaviour
    {
        public void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKeyDown(KeyCode.E)){Debug.Log("E key was pressed");}
            if (other.CompareTag("Player")){Debug.Log("Player touched");}
            if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player"))
            {
                Manager.ChangeScene(Variables.Desk.SceneName);
            }
        }
    }
}