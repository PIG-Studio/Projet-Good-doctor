using System;
using CustomScenes;
using GameCore.Variables;
using Patient;
using TypeExpand.String;
using UnityEngine;
using Patient.Base;
using Unity.Netcode;

namespace GameCore.Methods
{
    
    public class GameTick : MonoBehaviour
    {
        private GameObject _patient { get; set; }

        public void Start()
        {
            _patient = Resources.Load<GameObject>("Prefabs/Patient");
        }

        public void Update()
        {
            Debug.Log(_patient);
            if (!NetworkManager.Singleton.IsHost) return;
            if (!Variable.SceneNameCurrent.IsDesk() && Variable.SceneNameCurrent != Scenes.Map) return;
            if (!Input.GetKeyDown(KeyCode.P)) return;
            
            var guillaume = Instantiate(_patient);
            //Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
            //          guillaume.Adn);
            Debug.Log("Patient a l'entrée de l'hôpital !");
        }
    }
}