using System;
using Interfaces;
using UnityEngine;

namespace Personnel
{
    public class Janine : IPnj , ISpawn
    {
        public Sprite Skin { get; set; }
        public string Name { get; set; }
        public Vector2 Position { get; set; }

        public Janine()
        {
            //Skin = Skin de janine
            // First Name = Janine
            // Surname = son nom de famille
            // Position = Derriere son bureau
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
            throw new NotImplementedException();
        }

        public void Despawn()
        {
            throw new NotImplementedException();
        }
    }
}