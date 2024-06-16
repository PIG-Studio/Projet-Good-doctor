using System;
using Super.Interfaces;
using PNJ;
using UnityEngine;
using UnityEngine.AI;

namespace Personnel
{
    /// <summary>
    /// Représente le pnj Jeanine, un membre du personnel immobilisé.
    /// </summary>
    public class Jeanine : PNJ.Immobile.Personnel, ISpawnableGo  
    {
        public GameObject Prefab { get; }
        public GameObject InstantiatedObject { get; set; }
        public Animator AnimatorComponent { get; set; }
        public NavMeshAgent Agent { get; private set; }
        
        /// <summary>
        /// Identifiant unique de Janine
        /// </summary>
        public string Id { get; } 
        
        /// <summary>
        /// Phrase de salutation de Janine
        /// </summary>
        private string _catchprase; 

        public Jeanine()
        {
             // Initialisation des propriétés de Janine
            Prefab = Resources.Load<GameObject>("Prefabs/Personnel");
            Skin = 0;
            Name.Value = "Janine";
            Position.Value = new Vector2(-6.890f, 5.7358f);
            _catchprase = "Bonjour docteur ! Comment allez-vous ?";

            Id = Name.Value.ToString();// Appel de la méthode Spawn pour l'instanciation de Janine
            Spawn();
        }

        /// <summary>
        /// Fonction qui renvoie une phrase indiquant le reput du joueur
        /// </summary>
        public void Reputation(){}
        
        /// <summary>
        /// renvoie une phrase random de Janine
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Talk()
        {
            throw new NotImplementedException();
        }

        
        /// <summary>
        /// Fonction appeler au debut de la partie qui instantie Janine 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Spawn()
        {
            this.Instancier();
            AnimatorComponent = InstantiatedObject.GetComponent<Animator>();
            this.LinkAnimator();
        }

        /// <summary>
        /// Méthode pour désinstancier Janine
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Despawn()
        {
            throw new NotImplementedException();
        }
    }
}