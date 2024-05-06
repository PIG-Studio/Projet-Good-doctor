using Interaction.Base;
using UnityEngine;
using GameCore.Constantes;


namespace Interaction.Implementation
{
    public class Distributeur : ObjectInteraction
    {    
        public void Interagir()
        {
            if (Input.GetKeyDown(Constante.InteractKey)) // TODO : CHANGE TO A PARAM VALUE
            {
                Instantiate(Resources.Load<GameObject>("Sprites/Items/sachet-madeleinespng"));
                Debug.Log("Vous venez de récupérer un délicieux paquet de madeleine.");
            }
            else
            {
                Debug.Log("Voulez-vous des madeleines ?");
            }
        }
    }
}

