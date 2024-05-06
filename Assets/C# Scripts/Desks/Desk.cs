using System.Collections.Generic;
using Interfaces.Bureau;
using Interfaces.Destination;
using Interfaces.Entites;
using Inventories;
using TypeExpand.EDesk;
using UnityEngine;

namespace Desks
{
    public class Desk : IHasDestination, ICanReceivePatients
    {
        public string SceneName { get; }
        public Inventory Inventory { get; set; }
        public static Dictionary<string, Desk> SceneDeskDict { get; set; }
        public bool HasChanged { get; set; }
        public ICanGoInDesk CurrentPatient { get; private set; }
        public IDeskDestination AssociatedDestination { get; }

        public Desk(string sceneName)
        {
            SceneName = sceneName;
            CurrentPatient = null;
            AssociatedDestination = this.ToDeskDestination()!;
            Inventory = new Inventory();
            Debug.LogError("ADDED " + sceneName + " DESK");
            SceneDeskDict.Add(sceneName, this);
            Debug.Log("ADDED 1 DESK");
            HasChanged = true;
        }
        
        public void NextPatient()
        {
            CurrentPatient = AssociatedDestination.Pop();
        }

    }
}