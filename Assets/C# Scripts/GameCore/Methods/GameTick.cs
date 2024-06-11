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
            Debug.Log(_patient); // Affichage du GameObject représentant le patient (pour débogage)
            // Vérification si l'instance actuelle n'est pas l'hôte dans le réseau
            if (!NetworkManager.Singleton.IsHost) return;
            // Vérification si la scène actuelle n'est pas un bureau ou la carte
            if (!Variable.SceneNameCurrent.IsDesk() && Variable.SceneNameCurrent != Scenes.Map) return;
            if (!Input.GetKeyDown(KeyCode.P)) return;
            
            var guillaume = Instantiate(_patient);
            //Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
            //          guillaume.Adn);
            
            // Affichage d'un message pour signaler l'arrivée du patient à l'entrée de l'hôpital (pour débogage)
            Debug.Log("Patient a l'entrée de l'hôpital !");
        }
    }
}