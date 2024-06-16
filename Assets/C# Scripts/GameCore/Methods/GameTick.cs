using CustomScenes;
using GameCore.Variables;
using UnityEngine;
using Unity.Netcode;
using Random = System.Random;

namespace GameCore.Methods
{
    
    public class GameTick : MonoBehaviour
    {
        private GameObject Patient { get; set; }
        
        private float TempsEcoulee { get; set; }
        
        private float TempsDernierPatient { get; set; }

        public void Start()
        {
            Patient = Resources.Load<GameObject>("Prefabs/Patient");
            TempsEcoulee = 0f;
            Variable.WaitTime = new Random().Next(15,30);
            Debug.Log(Variable.WaitTime);

        }

        public void Update()
        {
            if (!NetworkManager.Singleton.IsServer) return;
            if (!(Variable.SceneNameCurrent == Scenes.Map)) return;
            TempsEcoulee = Time.time;
            if (TempsEcoulee - TempsDernierPatient > Variable.WaitTime &&  
                Variable.NbOfPatients < Constantes.Constante.MaxPatient)
            {
                Instantiate(Patient);
                TempsDernierPatient = TempsEcoulee;
            }
            //if (!Input.GetKeyDown(KeyCode.P)) return;
            //var guillaume = Instantiate(_patient);
            //Debug.Log(guillaume.Name + " " + guillaume.Depression + " " + guillaume.Sickness + " " +
            //          guillaume.Adn);
            Debug.Log(Patient); // Affichage du GameObject représentant le patient (pour débogage)
            
            // Vérification si la scène actuelle n'est pas un bureau ou la carte
            /*if (!Variable.SceneNameCurrent.IsDesk() && Variable.SceneNameCurrent != Scenes.Map) return;
            if (!Input.GetKeyDown(KeyCode.P)) return;*/
        }
    }
}       