using System;
using Cinemachine;
using UnityEngine;using Unity.Netcode;
using PlayerController_Base;

public class soloPlayerController : MonoBehaviour// TODO : heritage de classes
{
    public GameObject vcam;
    private PlayerController _playerController = new ();
   
    void Start()
    {
        _playerController.StartBase(vcam, gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CustomSceneManager.ChangeScene("Menu");
            gameObject.SetActive(false);
        }
        _playerController.UpdateBase();
    }
}
