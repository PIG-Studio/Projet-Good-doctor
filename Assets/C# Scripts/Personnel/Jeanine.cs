using System;
using Interfaces;
using PNJ;
using PNJ.Immobile;
using UnityEngine;
using UnityEngine.AI;

namespace Personnel
{
    public class Jeanine : PNJ.Immobile.Personnel
       , ISpawnableGo  
    {
        public GameObject Prefab { get; }
        public GameObject InstantiatedObject { get; set; }
        public Animator AnimatorComponent { get; set; }
        public NavMeshAgent Agent { get; private set; }
        
        public string Id { get; }
        
        private string _catchprase;

        public Jeanine()
        {
            Prefab = Resources.Load<GameObject>("Prefabs/Personnel");
            Skin = Resources.Load <Sprite> ("Sprites/Player/DinoSprites - vita");
            Name = "Janine";
            Position = new Vector2(-6.890f, 5.7358f);
            _catchprase = "Bonjour docteur ! Comment allez-vous ?";
            Id = Name;
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

        public void Despawn()
        {
            throw new NotImplementedException();
        }
    }
}