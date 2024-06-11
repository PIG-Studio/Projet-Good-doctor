using System.Collections.Generic;
using CustomScenes;
using GameCore.Variables;
using InventoryTwo.Player;
using Parameters;
using ScriptableObject;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;

namespace InventoryTwo.Desk
{
    public class DeskInventoryManager : MonoBehaviour
    {
        /// <summary>
        /// Liste d'item avec qui on peut interagir
        /// </summary>
        public List<ItemsSo> deskInventory;
        /// <summary>
        /// Longueur maximale de l'inventaire
        /// </summary>
        public int inventoryLenght = 24;
        /// <summary>
        /// pour l'UI
        /// </summary>
        public GameObject inventoryPanel, hodlerSlot;
        private GameObject _slot;
        public GameObject prefabs;

        public static InventoryManager instancePlayer;
        public static DeskInventoryManager InstanceDIM; // acceder partout
        public TextMeshProUGUI title;
        
        [Header("Option")]
        private int _amountToUse;
        [SerializeField] private TextMeshProUGUI valuesToUse;
        [SerializeField] private Button _plusButton, _minusButton;
        [SerializeField] private GameObject giveButton;
        [SerializeField] private GameObject trashButton;
        [SerializeField] private GameObject addInventoryButton;
        [SerializeField] private GameObject amountToRemove;
            
        /// <summary>
        /// Méthode appelée lors du démarrage de l'objet
        /// </summary>
        private void Awake()
        {
            InstanceDIM = this;
            instancePlayer = InventoryManager.Instance;
        }
        private void Update()
        {
            if (Variable.SceneNameCurrent == Scenes.DBase) //quand dans bureau
            {
                inventoryPanel.SetActive(true); // ouvre UI
                RefreshInventory();
            }
            else
            // Sinon pas actif
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
                    Destroy(item.gameObject); // on detruit tout pour mieux reconstruire
                }
            }

            for (int i = 0; i < inventoryLenght; i++) //initialise l'inventaire
            {
                if (i < deskInventory.Count )
                {
                    var transform1 = transform;
                    _slot = Instantiate(prefabs, transform1.position, transform1.rotation);
                    _slot.transform.SetParent(hodlerSlot.transform);

                    TextMeshProUGUI amount = _slot.transform.Find("amount").GetComponent<TextMeshProUGUI>();
                    Image img = _slot.transform.Find("icon").GetComponent<Image>(); // met le l'icon de l'objet dans inventaire
                    _slot.GetComponent<SlotItem>().itemSlot = i; 

                    amount.text = deskInventory[i].amount.ToString();
                    img.sprite = deskInventory[i].icon; //remplace la quantité dans le prefab par la quantité du slot actuel
                    
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
            valuesToUse.text = _amountToUse + "/" + deskInventory[i].amount;
            
            trashButton.SetActive(true);
            giveButton.SetActive(true);
            addInventoryButton.SetActive(true);
            amountToRemove.SetActive(true);
            
            
            title.text = deskInventory[i].title;

            _plusButton.GetComponent<Button>().onClick.RemoveAllListeners();
            _plusButton.GetComponent<Button>().onClick.AddListener(delegate { PlusButton(i); });
            
            _minusButton.GetComponent<Button>().onClick.RemoveAllListeners();
            _minusButton.GetComponent<Button>().onClick.AddListener(delegate { MinusButton(i);});
            
            giveButton.GetComponent<Button>().onClick.RemoveAllListeners();
            giveButton.GetComponent<Button>().onClick.AddListener(delegate { GiveItem(i); });
            
            trashButton.GetComponent<Button>().onClick.RemoveAllListeners();
            trashButton.GetComponent<Button>().onClick.AddListener(delegate { TrashButton(i); });
            
            addInventoryButton.GetComponent<Button>().onClick.RemoveAllListeners();
            addInventoryButton.GetComponent<Button>().onClick.AddListener(delegate { AddInventoryButton(i); });
        }
        
        /// <summary>
        /// Donner un objet au patient
        /// </summary>
        /// <param name="i"></param>
        public void GiveItem(int i) //i l'endroit dans l'inventaire
        {
            for (int j = 0; j < _amountToUse; j++)
            {
                //action sur le patient.temp ,.card etc...
                //Variable.Desk.CurrentPatient.Use(deskInventory[i])
                
                if (deskInventory[i].amount == 1)
                {
                    deskInventory.Remove(deskInventory[i]);
                    break;
                }
                else
                {
                    deskInventory[i].amount--;
                }
            }
            
            RefreshInventory();
            valuesToUse.text = _amountToUse + "/" + deskInventory[i].amount;
        }
        
        /// <summary>
        /// Ajouter un objet a l'autre inventaire
        /// </summary>
        /// <param name="i"></param>
        public void AddInventoryButton(int i) //i l'endroit dans l'inventaire
        {
            ItemsSo newItem = new ItemsSo(deskInventory[i].title, deskInventory[i].description, deskInventory[i].icon, _amountToUse, deskInventory[i].isStackable,
                         deskInventory[i].type);
            
            for (int j = 0; j < _amountToUse; j++)
            {
                //action sur le joueur par l'utilisation de inventory[i].attribut;

                if (deskInventory[i].amount == 1)
                {
                    deskInventory.Remove(deskInventory[i]);
                    break;
                }
                else
                {
                    deskInventory[i].amount--;
                }
            }
            
            for (int j = 0; j < InventoryManager.Instance.inventory.Count; j++)
            {
                if (deskInventory[i].title == InventoryManager.Instance.inventory[i].title && deskInventory[i].isStackable &&
                    InventoryManager.Instance.inventory.Count > 0)
                {
                    newItem.amount += InventoryManager.Instance.inventory[j].amount;
                    InventoryManager.Instance.inventory.Remove(InventoryManager.Instance.inventory[j]);
                }
            }
            InventoryManager.Instance.inventory.Add(newItem);
            InventoryManager.Instance.RefreshInventory();
            RefreshInventory();
            valuesToUse.text = _amountToUse + "/" + deskInventory[i].amount;
        }
        
        /// <summary>
        /// detruire/jeter des objets
        /// </summary>
        /// <param name="i"></param>
        public void TrashButton(int i)
        {
            if (_amountToUse > 0)
            {
                for (int j = 0; j < _amountToUse; j++)
                {
                    if (deskInventory[i].amount <= 1)
                    {
                        deskInventory.Remove(deskInventory[i]);
                        _amountToUse = 0;
                        break;
                    }
                    else
                    {
                        deskInventory[i].amount--;
                    }
                }
                RefreshInventory();
                valuesToUse.text = _amountToUse + "/" + deskInventory[i].amount;
            }
        }
    

        public void PlusButton(int i)
        {
            if (_amountToUse <= deskInventory[i].amount - 1)
                _amountToUse++;
            valuesToUse.text = _amountToUse + "/" + deskInventory[i].amount;
        }
        
        public void MinusButton(int i)
        {
            if (_amountToUse > deskInventory[i].amount - 1)
                _amountToUse--;
            valuesToUse.text = _amountToUse + "/" + deskInventory[i].amount;
        }
    }
}
