using GameCore.GameVAR;
using Items.Base;
using UnityEngine;
using static GameCore.GameVAR.Constantes;

namespace Interactible
{
    public class Distributeur : InteractionZone
    {
        public override void OnTriggerEnter(Collider other)
        {
            if (Input.GetKeyDown(InteractKey))
            {
                Variables.DeskBase.Inventory.AddItem(Items.Acces.MADELEINE());
                Debug.Log("Vous venez de récupérer un délicieux paquet de madeleine.");
            }
            else
            {
                Debug.Log("Voulez-vous des madeleines ?");
            }

        }
    }
}
