using static CustomScenes.Manager;
using UnityEngine;
using GameCore.GameVAR;
using Interaction.Base;
using Medicaments;

namespace PlayerController.SoloScripts
{
    public class PlayerControllerSolo : MonoBehaviour // TODO : heritage de classes
    {
        public GameObject vcam;
        private PlayerController_Base _playerController = new();

        void Start()
        {
            _playerController.StartBase(vcam, gameObject);
        }

        private void Update()
        {
            // TODO : Move this to UI INPUT MANAGEMENT
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ChangeScene("Menu");
                gameObject.SetActive(false);
            }
            

            _playerController.UpdateBase();
            
        }
    }
}