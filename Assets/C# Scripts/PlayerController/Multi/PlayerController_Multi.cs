using CustomScenes;
using Unity.Netcode;
using UnityEngine;
using GameCore.Variables;

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
            if (IsOwner && Variable.SceneNameCurrent == Scenes.Menu)
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
