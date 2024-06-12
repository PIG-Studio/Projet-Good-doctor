using Super.Interfaces.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Inventories.Player
{
    public class PlayerSlot : MonoBehaviour, ISlot
    {
        public IInventory Inventory { get; set; }
        public uint Amount { get; set; }
        public Sprite Image { get; set; }
        public TextMeshPro TextAmount { get; set; }
        private uint _index;
        public uint index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                if (Inventory.Inventaire[value] is null)
                {
                    Amount = 0;
                    Image = Resources.Load<Sprite>("UI/whiteSquare");
                    TextAmount.text = "";
                }
                else
                {
                    Amount = Inventory.Inventaire[value].amount;
                    Image = Inventory.Inventaire[value].icon;
                    TextAmount.text = Inventory.Inventaire[value].amount.ToString();
                }
            }
        }

        public void SetDescriptionValues()
        {
            Inventory.PrintDescription(index); 
        }
    }
}