using GameCore.GameVAR;
using Interaction.Base;
using UnityEngine;
using static GameCore.GameVAR.Constantes;


namespace Interaction.Implementation
{
    public class Distributeur : ObjectInteraction
    {    
        public void Interact()
        {
            if (UnityEngine.Input.GetKeyDown(InteractKey))
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

