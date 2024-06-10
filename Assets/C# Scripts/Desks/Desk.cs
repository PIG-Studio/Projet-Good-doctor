using System.Collections.Generic;
using Interfaces.Bureau;
using Interfaces.Destination;
using Interfaces.Entites;
using Inventories;
using TypeExpand.EDesk;
using UnityEngine;

namespace Desks
{
    /// <summary>
    /// Classe représentant un bureau qui peut recevoir des patients et a une destination associée
    /// </summary>
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
            Debug.Log("ADDED " + sceneName + " DESK"); // Affiche un message de débogage indiquant l'ajout du bureau
            SceneDeskDict.Add(sceneName, this); // Ajoute ce bureau au dict
            HasChanged = true;
        }
        
        public void NextPatient() // Méthode pour passer au patient suivant
        {
            // Récupère le prochain patient de la destination associée
            CurrentPatient = AssociatedDestination.Pop();
        }

    }
}