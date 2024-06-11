using System;
using CustomScenes;
using GameCore.Variables;
using Medicaments;
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
            Debug.Log(Variable.WaitTime);

        }

        public void Update()
        {
            if (!NetworkManager.Singleton.IsHost) return;
            if (!(Variable.SceneNameCurrent == Scenes.Map)) return;
            _tempsEcoulee = Time.time;
            Debug.Log("I m updating");
            if (_tempsEcoulee - _tempsDernierPatient > Variable.WaitTime &&  
                Variable.NbOfPatients < Constantes.Constante.MaxPatient)
            {
                Debug.Log("I m creating a patient");
                var patient = Instantiate(_patient);
                _tempsDernierPatient = _tempsEcoulee;
            }
            //if (!Input.GetKeyDown(KeyCode.P)) return;
            //var guillaume = Instantiate(_patient);
            //Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
            //          guillaume.Adn);
            Debug.Log(_patient); // Affichage du GameObject représentant le patient (pour débogage)
            // Vérification si l'instance actuelle n'est pas l'hôte dans le réseau
            if (!NetworkManager.Singleton.IsHost) return;
            
            // Vérification si la scène actuelle n'est pas un bureau ou la carte
            if (!Variable.SceneNameCurrent.IsDesk() && Variable.SceneNameCurrent != Scenes.Map) return;
            if (!Input.GetKeyDown(KeyCode.P)) return;
        }
    }
}       