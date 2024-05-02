using CustomScenes;
using Unity.Netcode;
using UnityEngine;
using static GameCore.GameVAR.Variables;

namespace PlayerController.Multi
{
    public class Multi : NetworkBehaviour
    {
        public GameObject vcam;
        private Base.Base _playerController = new();

        void Start()
        {
            _playerController.StartBase(vcam, gameObject);
        }

        private void Update()
        {
            if (IsOwner && SceneNameCurrent == Scenes.MENU)
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
