using static CustomScenes.Manager;
using UnityEngine;

namespace PlayerController
{
    public class PlayerController_Solo : MonoBehaviour // TODO : heritage de classes
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

            _playerController.UpdateBase();
        }
    }
}