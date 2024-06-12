using System;
using CustomScenes;
using GameCore.Variables;
using Super.Abstract;
using Super.Interfaces.GameObjects;
using UnityEngine;
using TypeExpand.Animator;
using TypeExpand.Int;
using Unity.Collections;
using Unity.Netcode;

namespace PNJ.Base
{
    public class Pnj : APnj, IConditionAffichage
    {
        /// <summary>
        /// Le nom du Pnj
        /// </summary>
        public override NetworkVariable<FixedString64Bytes> Name { get; protected set; } = new(writePerm: NetworkVariableWritePermission.Server);
        
        /// <summary>
        /// Les phrases de Pnj (ce qu'il disent)
        /// </summary>
        public override string Phrase { get; protected set; }
        
        /// <summary>
        /// La position du Pnj
        /// </summary>
        protected override NetworkVariable<Vector2> Position { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        /// <summary>
        /// La dernière position du Pnj
        /// </summary>
        private Vector2 LastPosition { get; set; }
        /// <summary>
        /// La vitesse du Pnj
        /// </summary>
        private Vector2 Velocity { get; set; }
        
        
        protected override uint _skin { get; set; }

        protected override uint Skin
        {
            get => _skin;
            set
            {
                _skin = value;
                Anims.runtimeAnimatorController = Variable.PnjSkin[_skin];
            } 
        }
        
        /// <summary>
        /// Les animations de Pnj
        /// </summary>
        protected override Animator Anims { get; set; }
        /// <summary>
        /// Sprite en 2d 
        /// </summary>
        protected override SpriteRenderer Sprite { get; set; }

        public Func<bool> ConditionAffichage { get; protected set; }
        
        
        public void Start()
        {
            ConditionAffichage = () => Variable.SceneNameCurrent == Scenes.Map;
            Anims = gameObject.GetComponent<Animator>();
            Sprite = gameObject.GetComponent<SpriteRenderer>();
            Rb = gameObject.GetComponent<Rigidbody2D>();
            
            
            // Si cette instance n'est pas l'hôte return sinon Spawn
            if (!NetworkManager.Singleton.IsHost) return;
            
            Skin = (uint)Variable.PnjSkin.Length.RandomInt();
            // Enregistrer la position actuelle de l'objet
            Position.Value = transform.position;
            LastPosition = Position.Value; // Enregistrer la dernière position
            NetworkObject instanceNetworkObject = gameObject.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }

        /// <summary>
        /// Vérifier si le nom de la scène actuelle est "Map"
        /// Sinon désactiver l'affichage du sprite si la scène n'est pas "Map"
        /// </summary>
        public void Update()
        { 
            if (ConditionAffichage())
            {
                Sprite.enabled = true; // Activer l'affichage du sprite
                
                 // Mettre à jour la position actuelle
                
                // Calculer la vélocité en soustrayant la dernière position de la position actuelle
                Velocity = (Vector2)(transform.position) - LastPosition;
                
                LastPosition = Position.Value; // Enregistrer la dernière position
                if (IsOwner)
                    // Mettre à jour la position actuelle
                    Position.Value = transform.position;
                else 
                    transform.position = Position.Value;
                
                Anims.UpdateAnim(Velocity); //Mettre à jour l'animation en fonction de la vélocité
            }
            else 
                Sprite.enabled = false;
        }
    }
}