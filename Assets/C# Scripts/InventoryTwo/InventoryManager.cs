using System.Collections.Generic;
using CustomScenes;
using GameCore.Variables;
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
    /// <summary>
    /// Classe responsable de la gestion de l'inventaire
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        /// <summary>
        /// Liste d'item avec qui on peut interagir
        /// </summary>
        public List<ItemsSo> inventory;
        /// <summary>
        /// Longueur maximale de l'inventaire
        /// </summary>
        public int inventoryLenght = 15;
        /// <summary>
        /// pour l'UI
        /// </summary>
        public GameObject inventoryPanel, hodlerSlot;
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
            
        /// <summary>
        /// Méthode appelée lors du démarrage de l'objet
        /// </summary>
        private void Awake()
        {
            Instance = this;
        }
        private void Update()
        {
            if (Input.GetKeyDown(Keys.InventoryKey) && !inventoryPanel.activeInHierarchy && Variable.SceneNameCurrent == Scenes.Map) //quand i est pressé et que l'UI n'est pas activé 
            {
                inventoryPanel.SetActive(true); // ouvre UI
                RefreshInventory();
            }
            else if (Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy && Variable.SceneNameCurrent == Scenes.Map)
            // Si la touche pour ouvrir l'inventaire est enfoncée et que le panneau d'inventaire n'est pas déjà ouvert
            if (Input.GetKeyDown(Keys.InventoryKey) && !inventoryPanel.activeInHierarchy) //quand i est pressé et que l'UI n'est pas activé 
            {
                inventoryPanel.SetActive(true); // ouvre UI
                if (hodlerSlot.transform.childCount > 0) // si contient des enfants
                {
                    // Supprime tous les enfants
                    foreach (Transform item in hodlerSlot.transform)
                    {
                        Destroy(item.gameObject);
                    }
                }

                for (int i = 0; i < inventoryLenght; i++) //initialise l'inventaire
                {
                    if (i < inventory.Count)
                    {
                        var transform1 = transform;
                        _slot = Instantiate(prefabs, transform1.position, transform1.rotation);
                        _slot.transform.SetParent(hodlerSlot.transform);
                        
                        TextMeshProUGUI amount = _slot.transform.Find("amount").GetComponent<TextMeshProUGUI>(); 
                        _slot.transform.Find("icon").GetComponent<Image>(); // met le l'icon de l'objet dans inventaire
                        _slot.GetComponent<SlotItem>().itemSlot = i; 
                        
                        amount.text = inventory[i].amount.ToString(); //remplace la quantité dans le prefab par la quantité du slot actuel
                    }
                    else if (i >= inventory.Count) // creer des slots vide dans l'inventaire
                    {
                        var transform1 = transform;
                        _slot = Instantiate(prefabs, transform1.position, transform1.rotation);
                        _slot.transform.SetParent(hodlerSlot.transform);
                        _slot.GetComponent<SlotItem>().itemSlot = i;
                        TextMeshProUGUI amount = _slot.transform.Find("amount").GetComponent<TextMeshProUGUI>();
                        amount.gameObject.SetActive(false);
                        _slot.transform.Find("icon").GetComponent<Image>();
                    }
                        
                }
            }
            // Si la touche pour fermer l'inventaire est enfoncée et que le panneau d'inventaire est ouvert
            else if (Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(false); // Ferme le panneau d'inventaire
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
        
        /// <summary>
        /// Méthode pour charger les détails d'un item sélectionné
        /// </summary>
        /// <param name="i"></param>
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
            if (_amountToUse > 0)
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

                Resources.Load<GameObject>("Prefabs/Inventory/Item.prefab");
                Instantiate(droped);

                RefreshInventory();
                valuesToUse.text = _amountToUse + "/" + inventory[i].amount;
            }
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
