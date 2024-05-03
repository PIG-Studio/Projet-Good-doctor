using static CustomScenes.Manager;
using UnityEngine;

namespace PlayerController.Solo
{
    public class Solo : MonoBehaviour // TODO : heritage de classes
    {
        public GameObject vcam;
        private Base.Base _playerController = new();

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