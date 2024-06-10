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
            Debug.Log("ADDED " + sceneName + " DESK");
            SceneDeskDict.Add(sceneName, this);
            HasChanged = true;
        }
        
        public void NextPatient()
        {
            if (!(CurrentPatient is null))
            {
                CurrentPatient.SortirBureau();
            }
            Debug.Log("Le patient precedent sort du bureau");
            CurrentPatient = AssociatedDestination.Pop();
            if (!(CurrentPatient is null))
            {
                Debug.Log("Le patient suivant entre dans le bureau");
                CurrentPatient!.EndWaiting();
                CurrentPatient.EnterBureau();
            }
            
        }

    }
}