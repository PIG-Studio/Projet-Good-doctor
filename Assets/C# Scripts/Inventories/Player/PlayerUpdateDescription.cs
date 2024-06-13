using Super.Interfaces.Inventory;
using TMPro;
using UnityEngine.UI;

namespace Inventories.Player
{
    public class PlayerUpdateDescription //:MonoBehaviour , IUpdateDesc
    {
        //[SerializeField] public GameObject InventoryTemp;
        
        public IInventory Inventory { get; set; }
        public TextMeshProUGUI desc { get; set; }
        public Image Icon { get; set; }
        public TextMeshProUGUI Title { get; set; }
        public TextMeshProUGUI Amount { get; set; }
        
        // Start is called before the first frame update
        /*public void Start()
        {
            desc = transform.Find("Description").GetComponent<TextMeshProUGUI>();
            Icon = transform.Find("Image").GetComponent<Image>();
            Title = transform.Find("NameObject").GetComponent<TextMeshProUGUI>();
            Amount = transform.Find("AmountToUse").GetComponent<TextMeshProUGUI>();
            Inventory = Joueur.Base.JoueurFundamentals.Inventory;
        }

        // Update is called once per frame
        public void Update()
        { 
            Debug.Log("update description");
            desc.text = Inventory.DescActuelle ?? "";
            Icon.sprite = Inventory.ImageActuel ?? Resources.Load<Sprite>("UI/SquareGD");
            Title.text = Inventory.NomActuel ?? "";
            Amount.text = Inventory.QuantiteAUtiliser.ToString() + " / " + Inventory.QuantiteAct.ToString();
        }*/
    }
}
