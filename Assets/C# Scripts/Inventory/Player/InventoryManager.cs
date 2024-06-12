using System.Collections.Generic;
using CustomScenes;
using GameCore.Variables;
using InventoryTwo.Desk;
using Network.Sync.Variables;
using Parameters;
using ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;

namespace InventoryTwo.Player
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
        public GameObject inventoryPanel;

        /// <summary>
        /// pour l'UI
        /// </summary>
        private GameObject _holderSlot;
        private GameObject _slot;
        public GameObject prefabs;
        
        public static DeskInventoryManager InstanceDesk; // acceder partout
        public TextMeshProUGUI title, descriptionObject;
        public Image iconDescription;
        
        [Header("Description")]
        public GameObject holderDescription;
        private int _amountToUse;
        [SerializeField] private TextMeshProUGUI valuesToUse;

        [SerializeField] private Button _plusButton, _minusButton;
        [SerializeField] private GameObject useButton;
        [SerializeField] private GameObject removeButton;
        [SerializeField] private GameObject addInventoryButton;
        [SerializeField] private GameObject amountToRemove;

        public Transform holderTransform;
        
        /// <summary>
        /// Méthode appelée lors du démarrage de l'objet
        /// </summary>
        private void Awake()
        {
            Instance = this;
            InstanceDesk = DeskInventoryManager.InstanceDIM;
            holderTransform = _holderSlot.transform;
        }
        private void Update()
        {
            if (Input.GetKeyDown(Keys.InventoryKey) && !inventoryPanel.activeInHierarchy) //quand i est pressé et que l'UI n'est pas activé 
            {
                inventoryPanel.SetActive(true); // ouvre UI
                RefreshInventory();
            }
            else if (Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy)
            // Si la touche pour fermer l'inventaire est enfoncée et que le panneau d'inventaire est ouvert
            {
                inventoryPanel.SetActive(false); // Ferme le panneau d'inventaire
            }
        }

        public void RefreshInventory()
        {
            
            if (holderTransform.childCount > 0) // si contient des enfants
            {
                for (int i = holderTransform.childCount; i > 0; i--)
                {
                    Destroy(holderTransform.GetChild(i).gameObject);
                }
            }

            for (int i = 0; i < inventoryLenght; i++) //initialise l'inventaire
            {
                _slot = Instantiate(prefabs, holderTransform.position, holderTransform.rotation);
                SlotItem slotItem = _slot.GetComponent<SlotItem>();
                _slot.transform.SetParent(_holderSlot.transform);
                TextMeshProUGUI amountText = slotItem.amount.GetComponent<TextMeshProUGUI>();
                slotItem.itemSlot = i;
                slotItem.instance = this;
                
                if (i < inventory.Count )
                {
                    Image img = _slot.transform.Find("icon").GetComponent<Image>(); // met le l'icon de l'objet dans inventaire
                    amountText.text = inventory[i].amount.ToString();
                    img.sprite = inventory[i].icon; //remplace la quantité dans le prefab par la quantité du slot actuel
                }
                else // creer des slots vide dans l'inventaire
                {
                    Button butt = _slot.transform.Find("icon").GetComponent<Button>();
                    butt.enabled = false;
                    amountText.gameObject.SetActive(false);
                    _slot.transform.Find("icon").GetComponent<Sprite>();
                }
            }
        }
        
        /// <summary>
        /// Méthode pour charger les détails d'un item sélectionné
        /// et les bons boutons
        /// </summary>
        /// <param name="i"></param>
        public void AfficherDesc(int i) 
        {
            _amountToUse = 0;
            valuesToUse.text = _amountToUse + "/" + inventory[i].amount;
            if (inventory[i].type == ItemsSo.Type.Nourriture || inventory[i].type == ItemsSo.Type.Medicament )
            {
                useButton.SetActive(true);
                removeButton.SetActive(true);
                amountToRemove.SetActive(true);
            }
            else if (inventory[i].type == ItemsSo.Type.Quete)
            {
                useButton.SetActive(false);
                removeButton.SetActive(true);
                amountToRemove.SetActive(true);
            }

            addInventoryButton.SetActive(Variable.SceneNameCurrent == Scenes.DBase);

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
            
            addInventoryButton.GetComponent<Button>().onClick.RemoveAllListeners();
            addInventoryButton.GetComponent<Button>().onClick.AddListener(delegate { AddInventoryButton(i); });
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
                ItemsSo newItem = UnityEngine.ScriptableObject.CreateInstance<ItemsSo>();
                newItem.title = inventory[i].title;
                newItem.description = inventory[i].description;
                newItem.amount = _amountToUse;
                newItem.icon = inventory[i].icon;
                newItem.isStackable = inventory[i].isStackable;
                newItem.type = inventory[i].type;
                
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

                ItemsSo droped = newItem; // ca marche pas mais c'est pour drop sur la map

                Resources.Load<GameObject>("Prefabs/Inventory/Item.prefab");
                Instantiate(droped);

                RefreshInventory();
                valuesToUse.text = _amountToUse + "/" + inventory[i].amount;
            }
        }
    
        /// <summary>
        /// Ajouter un objet a l'autre inventaire
        /// </summary>
        /// <param name="i"></param>
        public void AddInventoryButton(int i) //i l'endroit dans l'inventaire
        {
            if (_amountToUse > 0)
            {
                ItemsSo newItem = UnityEngine.ScriptableObject.CreateInstance<ItemsSo>();
                newItem.title = inventory[i].title;
                newItem.description = inventory[i].description;
                newItem.amount = _amountToUse;
                newItem.icon = inventory[i].icon;
                newItem.isStackable = inventory[i].isStackable;
                newItem.type = inventory[i].type;

                for (int j = 0; j < _amountToUse; j++)
                {
                    //action sur le joueur par l'utilisation de inventory[i].attribut;

                    if (inventory[i].amount == 1)
                    {
                        inventory.Remove(inventory[i]);
                        break;
                    }
                    else
                    {
                        inventory[i].amount--;
                    }
                }

                InstanceDesk.deskInventory.Add(newItem);
                InstanceDesk.RefreshInventory();
            }

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
