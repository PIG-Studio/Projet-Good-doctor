using Super.Interfaces.Inventory;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Inventories.Player
{
    public class PlayerSlot : MonoBehaviour, ISlot
    {
        public IInventory Inventory { get; set; }
        public uint Amount { get; set; }
        public Sprite Image { get; set; }
        public TextMeshProUGUI TextAmount { get; set; }
        public uint index { get; set; }

        public void SetDescriptionValues()
        {
            Inventory.PrintDescription(index); 
        }

        private void Start()
        {
            Debug.Log("startSlot");
            TextAmount = transform.Find("amount").gameObject.GetComponent<TextMeshProUGUI>();
            Image = transform.Find("icon").gameObject.GetComponent<Image>().sprite;
        }

        void Update()
        {
            if (Inventory.Inventaire[index] is null)
            {
                Amount = 0;
                Image = Resources.Load<Sprite>("UI/whiteSquare");
                TextAmount.text = " ";
            }
            else
            {
                Amount = Inventory.Inventaire[index].amount;
                Image = Inventory.Inventaire[index].icon;
                TextAmount.text = Inventory.Inventaire[index].amount.ToString();
            }
        }
    }
}