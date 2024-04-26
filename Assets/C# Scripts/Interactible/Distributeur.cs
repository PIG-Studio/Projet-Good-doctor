using GameCore.GameVAR;
using Interfaces;

namespace Interactible
{
    public class Distributeur : IInteractible
    {
        public void Interact() // ???????????????
        {
            Variables.DeskBase.Inventory.AddItem(Items.Acces.MADELEINE());
        }
    }
}