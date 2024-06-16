using CustomScenes;
using GameCore.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Inventories.Player
{
    public class PlayerUpdateDescription : MonoBehaviour
    {
        //[SerializeField] public GameObject InventoryTemp;
        
        public PlayerInventory Inventory { get; set; }
        [FormerlySerializedAs("Inventorytemp")] [SerializeField] public GameObject inventoryTemp;
        public TextMeshProUGUI Desc { get; set; }
        public Image Icon { get; set; }
        public TextMeshProUGUI Title { get; set; }
        public TextMeshProUGUI Amount { get; set; }
        public TextMeshProUGUI Price { get; set; }

        private Button _button;
        
        // Start is called before the first frame update
        public void Start()
        {
            Desc = transform.Find("Description").GetComponent<TextMeshProUGUI>();
            Icon = transform.Find("Image").GetComponent<Image>();
            Title = transform.Find("NameObject").GetComponent<TextMeshProUGUI>();
            Amount = transform.Find("AmountToUse").GetComponent<TextMeshProUGUI>();
            Price = transform.Find("Price").GetComponent<TextMeshProUGUI>();
            Inventory = inventoryTemp.GetComponent<PlayerInventory>();
            _button = transform.Find("AddDesk").GetComponent<Button>();
        }

        // Update is called once per frame
        public void Update()
        { 
            Debug.Log("update description");
            Desc.text = Inventory.DescActuelle ;//?? "";
            Icon.sprite = Inventory.ImageActuel ;//? Inventory.ImageActuel : Resources.Load<Sprite>("UI/SquareGD");
            Title.text = Inventory.NomActuel;// ?? "";
            Amount.text = Inventory.QuantiteAUtiliser.ToString() + " / " + Inventory.QuantiteAct.ToString();
            Price.text = Inventory.PrixActuel.ToString();
            _button.enabled = Variable.SceneNameCurrent == Scenes.DBase;
        }
        
    }
}
