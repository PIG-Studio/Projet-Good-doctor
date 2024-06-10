using CustomScenes;
using GameCore.Variables;
using Super.Abstract;
using UnityEngine;
using TypeExpand.Animator;
using Unity.Netcode;

namespace PNJ.Base
{
    public class Pnj : APnj
    {
        /// <summary>
        /// Le nom du Pnj
        /// </summary>
        public override string Name { get; protected set; }
        /// <summary>
        /// Les phrases de Pnj (ce qu'il disent)
        /// </summary>
        public override string Phrase { get; protected set; }
        /// <summary>
        /// Le sprite du Pnj
        /// </summary>
        protected override Sprite Skin { get; set; }
        /// <summary>
        /// La position du Pnj
        /// </summary>
        protected override Vector2 Position { get; set; }
        /// <summary>
        /// La dernière position du Pnj
        /// </summary>
        private Vector2 LastPosition { get; set; }
        /// <summary>
        /// La vitesse du Pnj
        /// </summary>
        private Vector2 Velocity { get; set; }
        
        /// <summary>
        /// Les animations de Pnj
        /// </summary>
        protected override Animator Anims { get; set; }
        /// <summary>
        /// Sprite en 2d 
        /// </summary>
        protected override SpriteRenderer Sprite { get; set; }
        
        
        public void Start()
        {
            Anims = gameObject.GetComponent<Animator>();
            Sprite = gameObject.GetComponent<SpriteRenderer>();
            // Enregistrer la position actuelle de l'objet
            Position = transform.position;
            
            // Si cette instance n'est pas l'hôte return sinon Spawn
            if (!NetworkManager.Singleton.IsHost) return;
            NetworkObject instanceNetworkObject = gameObject.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }

        /// <summary>
        /// Vérifier si le nom de la scène actuelle est "Map"
        /// Sinon désactiver l'affichage du sprite si la scène n'est pas "Map"
        /// </summary>
        public void Update()
        { 
            // Vérifier si le nom de la scène actuelle est "Map"
            if (Variable.SceneNameCurrent == Scenes.Map)
            {
                Sprite.enabled = true; // Activer l'affichage du sprite
                LastPosition = Position; // Enregistrer la dernière position
                Position = transform.position; // Mettre à jour la position actuelle
                // Calculer la vélocité en soustrayant la dernière position de la position actuelle
                Velocity = Position - LastPosition;
                Anims.UpdateAnim(Velocity); //Mettre à jour l'animation en fonction de la vélocité
            }
            else 
            { Sprite.enabled = false; }

            // Moved to patient
            /*if (Patient.EnAttente || AgentComp.remainingDistance > 2f) return;
            
            if (Destination.IsFull)
            {
                Debug.Log("Destination pleine, recherche d'une autre destination");
                Patient.ChooseDestination();
                return;
            }
            
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    deskDestination.Add(Patient);
                    break;
                case INormalDestination normalDestination:
                    normalDestination.Add(Patient);
                    break;
            }*/
        }
    }
}