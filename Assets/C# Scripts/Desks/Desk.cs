using System.Collections.Generic;
using Destinations.Implementation;
using GameCore.Variables;
using Interfaces.Bureau;
using Interfaces.Destination;
using Interfaces.Entites;
using Inventories;
using UnityEngine;

namespace Desks
{
    public class Desk : IHasDestination, ICanReceivePatients
    {
        private static uint _compteDeskDestinations;
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
            AssociatedDestination = new DeskDestination(3, Vector2.zero, new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[3], this);
            InitialiserDestination();
            Inventory = new Inventory();
            Debug.LogError("ADDED " + sceneName + " DESK");
            SceneDeskDict.Add(sceneName, this);
            Debug.Log("ADDED 1 DESK");
            HasChanged = true;
        }

        public void InitialiserDestination()
        {
            AssociatedDestination.PtArrivee = new Vector2(-7, -10);
            AssociatedDestination.PtAttente[0].coordonees = new Vector2(-10, -10);
            AssociatedDestination.PtAttente[1].coordonees = new Vector2(-13, -10);
            AssociatedDestination.PtAttente[2].coordonees = new Vector2(-16, -10);

            Variable.AllDestinations.Add(AssociatedDestination);
            Variable.DeskDestinations[_compteDeskDestinations] = AssociatedDestination;
            _compteDeskDestinations++;
        }

        public void NextPatient()
        {
            CurrentPatient = AssociatedDestination.Pop();
        }

    }
}