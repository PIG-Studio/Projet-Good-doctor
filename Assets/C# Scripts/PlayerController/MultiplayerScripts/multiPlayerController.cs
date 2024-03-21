using System;
using PlayerController_Base;
using Unity.Netcode;
using UnityEngine;

public class multiPlayerController : NetworkBehaviour
{
    public GameObject vcam;
    private PlayerController _playerController = new ();
    void Start()
    {
        gameObject.SetActive(true);
        _playerController.StartBase(vcam, gameObject);
    }

    private void Update()
    {
        if (IsOwner && GameVariables.SceneName_Current == "MapHospital")
        {
            _playerController.vcam.SetActive(true);
            _playerController.UpdateBase();
        }
        else {_playerController.vcam.SetActive(false);}
    }
}
