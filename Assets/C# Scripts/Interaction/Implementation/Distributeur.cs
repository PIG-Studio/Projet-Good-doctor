using Interaction.Base;
using UnityEngine;
using GameCore.Constantes;


namespace Interaction.Implementation
{
    public class Distributeur : ObjectInteraction
    {    
        /// <summary>
        /// Méthode appelée pour interagir avec le distributeur
        /// </summary>
        public void Interagir()
        {
            // Vérifie si la touche définie dans Constante.InteractKey est enfoncée
            if (Input.GetKeyDown(Constante.InteractKey)) // TODO : CHANGE TO A PARAM VALUE
            {
                // Instancie un objet représentant un paquet de madeleines à partir des ressources
                Instantiate(Resources.Load<GameObject>("Sprites/Items/sachet-madeleinespng"));
                // Affiche un message pour indiquer que le joueur a récupéré un paquet de madeleines
                Debug.Log("Vous venez de récupérer un délicieux paquet de madeleine.");
            }
            else
            {
                // Si la touche n'est pas enfoncée, affiche un message pour demander si le joueur veut des madeleines
                Debug.Log("Voulez-vous des madeleines ?");
            }
        }
    }
}

