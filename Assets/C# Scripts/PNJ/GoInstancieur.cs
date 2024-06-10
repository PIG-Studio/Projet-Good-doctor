using Interfaces;
using JetBrains.Annotations;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

namespace PNJ
{
    public static class GoInstancieur
    {
        [CanBeNull]
        public static GameObject Spawn(string chemin, string id)
        {
            // Charger go depuis le dossier Resources
            GameObject go = Object.Instantiate(Resources.Load<GameObject>(chemin));
            var sync = go.GetComponent<NetworkObject>(); // Récupérer le composant NetworkObject
            sync.Spawn(); // faire apparaitre l'objet 
            go.name = id; // renommer l'objet 
            return go; 
        }
        
        public static void Instancier(this ISpawnableGo inputGo)
        {
            inputGo.InstantiatedObject = Object.Instantiate(inputGo.Prefab);// Instancier l'objet à partir du prefab
            //TODO : handle null
            var sync = inputGo.InstantiatedObject!.GetComponent<NetworkObject>(); // Récupérer le composant NetworkObject
            sync.Spawn(); // Faire apparaître l'objet
            inputGo.InstantiatedObject!.name = inputGo.Id; // Renommer l'objet instancié
        }
        
        public static void Despawn(this ISpawnableGo inputGo)
        {
            Object.Destroy(inputGo.InstantiatedObject); //Détruire l'objet instantié
        }
        
        public static void AddNavMeshAgent(this ISpawnableGo inputGo)
        {
            // Ajouter le composant NavMeshAgent
            NavMeshAgent component = inputGo.InstantiatedObject!.AddComponent<NavMeshAgent>();
            // Configurer les propriétés du NavMeshAgent
            component.angularSpeed = 0;
            component.updateRotation = false;
            component.SetDestination(new Vector3(-10, -11, 0));
            component.areaMask = 1;
            component.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
        }
    }
}