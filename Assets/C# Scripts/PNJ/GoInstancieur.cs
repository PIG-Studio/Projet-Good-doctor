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
            GameObject go = Object.Instantiate(Resources.Load<GameObject>(chemin));
            var sync = go.GetComponent<NetworkObject>();
            sync.Spawn();
            go.name = id;
            return go;
        }
        
        public static void Instancier(this ISpawnableGo inputGo)
        {
            inputGo.InstantiatedObject = Object.Instantiate(inputGo.Prefab);
            //TODO : handle null
            var sync = inputGo.InstantiatedObject!.GetComponent<NetworkObject>();
            sync.Spawn();
            inputGo.InstantiatedObject!.name = inputGo.Id;
        }
        
        public static void Despawn(this ISpawnableGo inputGo)
        {
            Object.Destroy(inputGo.InstantiatedObject);
        }
        
        public static void AddNavMeshAgent(this ISpawnableGo inputGo)
        {
            NavMeshAgent component = inputGo.InstantiatedObject!.AddComponent<NavMeshAgent>();
            component.angularSpeed = 0;
            component.updateRotation = false;
            component.SetDestination(new Vector3(-10, -11, 0));
            component.areaMask = 1;
            component.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
        }
    }
}