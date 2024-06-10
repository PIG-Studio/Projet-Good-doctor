using Interaction.Base;
using UnityEngine;
using static GameCore.Constantes.Constante;


namespace Interaction.Implementation
{
    public class Distributeur : ObjectInteraction
    {    
        public void Interagir()
        {
            if (Input.GetKeyDown(Parameters.Keys.UseKey))
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

