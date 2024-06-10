using System.Collections.Generic;
using Network.Sync.Variables;
using ScriptableObject;
using TMPro;
using UnityEngine;
using Parameters;
using UnityEngine.UIElements;
using static GameCore.Constantes.Constante;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;

namespace InventoryTwo
{
    public class InventoryManager : MonoBehaviour
    {
        public List<ItemsSo> inventory; //liste d'item avec qui on peut interagir
        public int inventoryLenght = 15;
        public GameObject inventoryPanel, hodlerSlot; // pour l'UI
        private GameObject _slot;
        public GameObject prefabs;
        
        public static InventoryManager Instance; // acceder partout
        public TextMeshProUGUI title, descriptionObject;
        public Image iconDescription;
        
        [Header("Description")]
        public GameObject holderDescription;
        private int _amountToUse;
        [SerializeField] private TextMeshProUGUI valuesToUse;

        [SerializeField] private Button _plusButton, _minusButton;
        [SerializeField] private GameObject useButton;
        [SerializeField] private GameObject removeButton;
        [SerializeField] private GameObject amountToRemove;
        
        private void Awake()
        {
            Instance = this;
        }
        private void Update()
        {
            if (Input.GetKeyDown(Keys.InventoryKey) && !inventoryPanel.activeInHierarchy) //quand i est pressé et que l'UI n'est pas activé 
            {
                inventoryPanel.SetActive(true); // ouvre UI
                RefreshInventory();
            }
            else if (Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(false);
            }
        }

        private void RefreshInventory()
        {
            if (hodlerSlot.transform.childCount > 0) // si contient des enfants
            {
                foreach (Transform item in hodlerSlot.transform)
                {
                    Destroy(item.gameObject);
                }
            }

            for (int i = 0; i < inventoryLenght; i++) //initialise l'inventaire
            {
                if (i < inventory.Count )
                {
                    var transform1 = transform;
                    _slot = Instantiate(prefabs, transform1.position, transform1.rotation);
                    _slot.transform.SetParent(hodlerSlot.transform);

                    TextMeshProUGUI amount = _slot.transform.Find("amount").GetComponent<TextMeshProUGUI>();
                    Image img = _slot.transform.Find("icon").GetComponent<Image>(); // met le l'icon de l'objet dans inventaire
                    _slot.GetComponent<SlotItem>().itemSlot = i;

                    amount.text = inventory[i].amount.ToString();
                    img.sprite = inventory[i].icon; //remplace la quantité dans le prefab par la quantité du slot actuel
                }
                else // creer des slots vide dans l'inventaire
                {
                    var transform1 = transform;
                    _slot = Instantiate(prefabs, transform1.position, transform1.rotation);
                    _slot.transform.SetParent(hodlerSlot.transform);
                    _slot.GetComponent<SlotItem>().itemSlot = i;
                    TextMeshProUGUI amount = _slot.transform.Find("amount").GetComponent<TextMeshProUGUI>();
                    Button butt = _slot.transform.Find("icon").GetComponent<Button>();
                    butt.enabled = false;
                    amount.gameObject.SetActive(false);
                    _slot.transform.Find("icon").GetComponent<Sprite>();
                }
            }
        }

        public void ChargeItem(int i)
        {
            _amountToUse = 0;
            valuesToUse.text = _amountToUse + "/" + inventory[i].amount;
            if (inventory[i].type == ItemsSo.Type.Nourriture || inventory[i].type == ItemsSo.Type.Medicament )
            {
                useButton.SetActive(true);
                removeButton.SetActive(true);
                amountToRemove.SetActive(true);
            }
            if (inventory[i].type == ItemsSo.Type.Quete)
            {
                useButton.SetActive(false);
                removeButton.SetActive(true);
                amountToRemove.SetActive(true);
            }
            
            holderDescription.SetActive(true);
            title.text = inventory[i].title;
            descriptionObject.text = inventory[i].description;
            iconDescription.sprite = inventory[i].icon;

            _plusButton.GetComponent<Button>().onClick.RemoveAllListeners();
            _plusButton.GetComponent<Button>().onClick.AddListener(delegate { PlusButton(i); });
            
            _minusButton.GetComponent<Button>().onClick.RemoveAllListeners();
            _minusButton.GetComponent<Button>().onClick.AddListener(delegate { MinusButton(i);});
            
            useButton.GetComponent<Button>().onClick.RemoveAllListeners();
            useButton.GetComponent<Button>().onClick.AddListener(delegate { UseItem(i); });
            
            removeButton.GetComponent<Button>().onClick.RemoveAllListeners();
            removeButton.GetComponent<Button>().onClick.AddListener(delegate { RemoveButton(i); });
            
        }

        public void UseItem(int i) //i l'endroit dans l'inventaire
        {
            for (int j = 0; j < _amountToUse; j++)
            {
                //action sur le joueur par l'utilisation de inventory[i].attribut;

                if (inventory[i].amount == 1)
                {
                    inventory.Remove(inventory[i]);
                    holderDescription.SetActive(false);

                    break;
                }
                else
                {
                    inventory[i].amount--;
                }
            }
            
            RefreshInventory();
            valuesToUse.text = _amountToUse + "/" + inventory[i].amount;
        }
        public void RemoveButton(int i)
        {
            for (int j = 0; j < _amountToUse; j++)
            {
                if (inventory[i].amount <= 1)
                {
                    inventory.Remove(inventory[i]);
                    holderDescription.SetActive(false);
                    _amountToUse = 0;
                    break;
                }
                else
                {
                    inventory[i].amount--;
                }
            }

            ItemsSo droped = inventory[i];
            droped.amount = _amountToUse;
            
            Resources.Load<GameObject>("Assets/UI pack/Prefabs/Inventory/SlotItem1.prefab");
            Instantiate(droped, );
            
            RefreshInventory();
            valuesToUse.text = _amountToUse + "/" + inventory[i].amount;
        }

        public void PlusButton(int i)
        {
            if (_amountToUse <= inventory[i].amount - 1)
                _amountToUse++;
            valuesToUse.text = _amountToUse + "/" + inventory[i].amount;
        }
        
        public void MinusButton(int i)
        {
            if (_amountToUse > inventory[i].amount - 1)
                _amountToUse--;
            valuesToUse.text = _amountToUse + "/" + inventory[i].amount;
        }
    }
}
