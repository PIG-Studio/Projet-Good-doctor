using Unity.Netcode;
using UnityEngine;
using static GameCore.Variables;

namespace PlayerController
{
    public class PlayerController_Multi : NetworkBehaviour
    {
        public GameObject vcam;
        private PlayerController_Base _playerController = new();

        void Start()
        {
            gameObject.SetActive(true);
            _playerController.StartBase(vcam, gameObject);
        }

        private void Update()
        {
            if (IsOwner && SceneNameCurrent == "MapHospital")
            {
                _playerController.vcam.SetActive(true);
                _playerController.UpdateBase();
            }
            else
            {
                _playerController.vcam.SetActive(false);
            }
        }
    }
}
