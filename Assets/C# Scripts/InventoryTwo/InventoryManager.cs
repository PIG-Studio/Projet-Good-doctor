using System.Collections.Generic;
using ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace InventoryTwo
{
    public class InventoryManager : MonoBehaviour
    {
        public List<ItemsSo> inventory; //liste d'item avec qui on peut interagir
        public int inventoryLenght = 15;
        public GameObject inventoryPanel, hodlerSlot; // pour l'UI
        private GameObject slot;
        public GameObject prefabs;
        public GameObject holderDescription;
        public static InventoryManager Instance; // acceder partout
        public TextMeshProUGUI title, descriptionObject;
        public Image iconDescription;
        private void Awake()
        {
            Instance = this;
        }
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.I) && !inventoryPanel.activeInHierarchy) //quand i est pressé et que l'UI n'est pas activé 
            {
                inventoryPanel.SetActive(true); // ouvre UI
                if (hodlerSlot.transform.childCount > 0) // si contient des enfants
                {
                    foreach (Transform item in hodlerSlot.transform)
                    {
                        Destroy(item.gameObject);
                    }
                }

                for (int i = 0; i < inventoryLenght; i++) //initialise l'inventaire
                {
                    if (i <= inventory.Count)
                    {
                        slot = Instantiate(prefabs, transform.position, transform.rotation);
                        slot.transform.SetParent(hodlerSlot.transform);
                        TextMeshProUGUI amount = slot.transform.Find("amount").GetComponent<TextMeshProUGUI>();
                        Image img = slot.transform.Find("icon").GetComponent<Image>();
                        slot.GetComponent<SlotItem>().itemSlot = i;
                        
                        amount.text = inventory[i].amount.ToString(); //remplace la quantité dans le prefab par la quantité du slot actuel
                    }
                    else if (i > inventory.Count - 1)
                    {
                        slot = Instantiate(prefabs, transform.position, transform.rotation);
                        slot.transform.SetParent(hodlerSlot.transform);
                        slot.GetComponent<SlotItem>().itemSlot = i;
                        TextMeshProUGUI amount = slot.transform.Find("amount").GetComponent<TextMeshProUGUI>();
                        amount.gameObject.SetActive(false);
                        Image img = slot.transform.Find("icon").GetComponent<Image>();

                    }
                        
                }
            }
            else if (Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(false);
            }
        }
        public void ChargeItem(int i)
        {
            holderDescription.SetActive(true);
            title.text = inventory[i].title;
            descriptionObject.text = inventory[i].description;
            iconDescription.sprite = inventory[i].icon;
            
        }
    }
}
