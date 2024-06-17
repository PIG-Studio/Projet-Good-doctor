using Super.Interfaces.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventories.Desk
{
    public class DeskSlot : MonoBehaviour, ISlot
    {
        public IInventory Inventory { get; set; }
        public uint Amount { get; set; }
        public Image Image { get; set; }
        public TextMeshProUGUI TextAmount { get; set; }
        public uint Index { get; set; }

        public void Start()
        {
            TextAmount = transform.Find("amount").gameObject.GetComponent<TextMeshProUGUI>();
            Image = transform.Find("icon").gameObject.GetComponent<Image>();
        }

        public void Update()
        {
            if (Inventory.Inventaire[Index] is null)
            {
                Amount = 0;
                Image.sprite = Resources.Load<Sprite>("UI/SquareGD");
                TextAmount.text = " ";
            }
            else
            {
                Amount = Inventory.Inventaire[Index].amount;
                Image.sprite = Inventory.Inventaire[Index].icon;
                TextAmount.text = Inventory.Inventaire[Index].amount.ToString();
            }
        }

        public void SetDescriptionValues()
        {
            Inventory.UpdateDescription(Index);         
        }
    }
}