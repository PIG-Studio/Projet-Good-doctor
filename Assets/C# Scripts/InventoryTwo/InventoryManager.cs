using System.Collections.Generic;
using ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace InventoryTwo
{
    public class InventoryManager : MonoBehaviour
    {
        public List<ItemsSo> inventory; //liste d'item avec qui on peut interagir
        public int inventoryLenght = 15;
        public GameObject inventoryPanel, hodlerSlot; // pour l'UI
        private GameObject slot;
        public GameObject prefabs;

        public static InventoryManager instance; // acceder partout

        private void Awake()
        {
            instance = this;
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

                for (int i = 0; i < inventory.Count; i++)//initialise l'inventaire
                {
                    slot = Instantiate(prefabs, transform.position, transform.rotation);
                    slot.transform.SetParent(hodlerSlot.transform);
                    if (inventory[i] != null)
                    {
                        TextMeshProUGUI amount = slot.transform.Find("Amount").GetComponent<TextMeshProUGUI>();
                        Image img = slot.transform.Find("Icon").GetComponent<Image>();

                        amount.text = inventory[i].amount.ToString(); //remplace la quantité dans le prefab par la quantité du slot actuel
                        img.sprite = inventory[i].icon; // sprite du slot
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(false);
            }
        }
    }
}
