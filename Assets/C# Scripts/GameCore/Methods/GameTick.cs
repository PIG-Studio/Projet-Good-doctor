using System;
using CustomScenes;
using GameCore.Variables;
using Patient;
using TypeExpand.String;
using UnityEngine;
using Patient.Base;
using Unity.Netcode;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace GameCore.Methods
{
    
    public class GameTick : MonoBehaviour
    {
        private GameObject _patient { get; set; }
        
        private float _tempsEcoulee { get; set; }
        
        private float _tempsDernierPatient { get; set; }

        public void Start()
        {

            _patient = Resources.Load<GameObject>("Prefabs/Patient");
            _tempsEcoulee = 0f;
            Variable.WaitTime = new Random().Next(15,30);
            Variable.WaitTime = 3;
            Debug.Log(Variable.WaitTime);

        }

        public void Update()
        {


            if (!NetworkManager.Singleton.IsHost) return;
            if (!(Variable.SceneNameCurrent == Scenes.Map)) return;
            _tempsEcoulee = Time.time;
            if (Variable.NbOfPatients < Constantes.Constante.MaxPatient)
            {
                var patient = Instantiate(_patient);
                _tempsDernierPatient = _tempsEcoulee;
                Variable.NbOfPatients++;

            }
            //if (!Input.GetKeyDown(KeyCode.P)) return;
            //var guillaume = Instantiate(_patient);
            //Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
            //          guillaume.Adn);
        }
    }
}   