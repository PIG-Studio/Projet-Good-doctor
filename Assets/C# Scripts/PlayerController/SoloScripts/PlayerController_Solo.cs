using static CustomScenes.Manager;
using UnityEngine;
using GameCore.GameVAR;
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
            // TODO : Move this to a manager or smth
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ChangeScene("Menu");
                gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {   
                Variables.DeskBase.Inventory.AddItem(Acces.CYAMURE(1));
            }

            _playerController.UpdateBase();
        }
    }
}