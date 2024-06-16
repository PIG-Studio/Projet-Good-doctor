using Super.Interfaces.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventories.Desk
{
    public class DeskUpdateDescription : MonoBehaviour
    {
        //[SerializeField] public GameObject InventoryTemp;
        
        public DeskInventory Inventory { get; set; }
        [SerializeField] public GameObject Inventorytemp;
        public TextMeshProUGUI desc { get; set; }
        public Image Icon { get; set; }
        public TextMeshProUGUI Title { get; set; }
        public TextMeshProUGUI Amount { get; set; }
        public TextMeshProUGUI Price { get; set; }
        // Start is called before the first frame update
        public void Start()
        {
            Icon = transform.Find("Image").GetComponent<Image>();
            Title = transform.Find("NameObject").GetComponent<TextMeshProUGUI>();
            Amount = transform.Find("AmountToUse").GetComponent<TextMeshProUGUI>();
            Price = transform.Find("Price").GetComponent<TextMeshProUGUI>();
            Inventory = Inventorytemp.GetComponent<DeskInventory>();
        }

        // Update is called once per frame
        public void Update()
        { 
            Debug.Log("update desk description");
            Icon.sprite = Inventory.ImageActuel ? Inventory.ImageActuel : Resources.Load<Sprite>("UI/SquareGD");
            Title.text = Inventory.NomActuel ?? "";
            Amount.text = Inventory.QuantiteAUtiliser.ToString() + " / " + Inventory.QuantiteAct.ToString();
            Price.text = Inventory.PrixActuel.ToString();
        }
        
    }
}
