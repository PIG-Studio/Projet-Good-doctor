using System.Collections.Generic;
using GameCore.Variables;
using Super.Interfaces.Destination;
using Super.Interfaces.Entites;
using Inventories.Desk;
using ScriptableObject;
using Super.Interfaces.Bureau;
using Super.Interfaces.Joueur;
using TypeExpand.EDesk;
using Unity.Netcode;
using UnityEngine;

namespace Desks
{
    /// <summary>
    /// Classe représentant un bureau qui peut recevoir des patients et a une destination associée
    /// </summary>
    public class Desk : IHasDestination, ICanReceivePatients, IHasResponsable
    {
        public string SceneName { get; }
       // public Inventory Inventory { get; set; }
        public static Dictionary<string, Desk> SceneDeskDict { get; set; }
        public ICanGoInDesk CurrentPatient { get; private set; }
        public IDeskDestination AssociatedDestination { get; }
        public IJoueur Responsable { get; set; }
        
        public ItemsSo[] Inventaire { get; set; }
        
        public DeskInventory Inventory { get; set; }
        public uint MaxLenght { get => 24 ; }
        
        public Desk(string sceneName)
        {
            Inventaire = new ItemsSo[MaxLenght];
            
            SceneName = sceneName;
            CurrentPatient = null;
            AssociatedDestination = this.ToDeskDestination()!;
            //Inventory = new Inventory();
            Debug.Log("ADDED " + sceneName + " DESK"); // Affiche un message de débogage indiquant l'ajout du bureau
            SceneDeskDict.Add(sceneName, this); // Ajoute ce bureau au dict
            Variable.AllDesks[Variable.DesksNb] = this; // Ajoute ce bureau à la liste des bureaux
        }
        
        [ServerRpc(RequireOwnership = false)]
        public void NextPatientServerRpc() // Méthode pour passer au patient suivant
        {
            if (!(CurrentPatient is null))
            {
                CurrentPatient.SortirBureauServerRpc();
                Debug.Log("Le patient precedent sort du bureau");
            }
            

            // Récupère le prochain patient de la destination associée
            
            CurrentPatient = AssociatedDestination.Pop();
            if (!(CurrentPatient is null))
            {
                Debug.Log("Le patient suivant entre dans le bureau");
                CurrentPatient!.EndWaitingServerRpc();
                CurrentPatient.EnterBureauServerRpc();
            }
            
        }

    }
}