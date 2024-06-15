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
        public Image Image { get; set; }
        public TextMeshProUGUI TextAmount { get; set; }
        public uint index { get; set; }

        public void Start()
        {
            Debug.Log("startSlot");
            TextAmount = transform.Find("amount").gameObject.GetComponent<TextMeshProUGUI>();
            Image = transform.Find("icon").gameObject.GetComponent<Image>();
            Debug.Log("update slot");
            if (Inventory.Inventaire[index] is null)
            {
                Debug.Log("create empty slot");
                Amount = 0;
                Image.sprite = Resources.Load<Sprite>("UI/SquareGD");
                TextAmount.text = " ";
            }
            else
            {
                Debug.Log("create item slot");
                Amount = Inventory.Inventaire[index].amount;
                Image.sprite = Inventory.Inventaire[index].icon;
                TextAmount.text = Inventory.Inventaire[index].amount.ToString();
            }
        }

        /*public void Update()
        {
            Debug.Log("update slot");
            if (Inventory.Inventaire[index] is null)
            {
                Debug.Log("create empty slot");
                Amount = 0;
                Image.sprite = Resources.Load<Sprite>("UI/SquareGD");
                TextAmount.text = " ";
            }
            else
            {
                Debug.Log("create item slot");
                Amount = Inventory.Inventaire[index].amount;
                Image.sprite = Inventory.Inventaire[index].icon;
                TextAmount.text = Inventory.Inventaire[index].amount.ToString();
            }
        }*/
        
        public void SetDescriptionValues()
        {
            Debug.Log("click on button to print description");
            Inventory.UpdateDescription(index); 
        }
    }
}