using System;
using Interfaces;
using UnityEngine;

namespace Personnel
{
    public class ChefGiovanni : IPnj , ISpawn
    {
        public Sprite Skin { get; set; }
        public string Name { get; set; }
        public Vector2 Position { get; set; }

        public ChefGiovanni()
        {
            //Skin = Skin de Gio
            // First Name = Giovanni
            // Surname = Pas de nom
            // Position = Dans la cafet
        }

        /// <summary>
        /// renvoie un potin sur le joueur en fonction de sa reput
        /// </summary>
        public void Potin(){}
        
        
        /// <summary>
        /// >Renvoie une phrase random du chef
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void talk()
        {
            throw new NotImplementedException();
        }

        
        /// <summary>
        /// Spawn le chef en debut de partie a la cafet
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