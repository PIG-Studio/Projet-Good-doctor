using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Input = UnityEngine.Windows.Input;

namespace InventoryTwo
{
    public class InventoryManager : MonoBehaviour
    {
        public List<ItemsSo> inventory;
        public int inventoryLenght = 15;
        public GameObject inventoryPanel, hodlerSlot;
        private GameObject slot;
        public GameObject prefabs;

        public static InventoryManager instance;

        private void Awake()
        {
            instance = this;
        }
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.I) && !inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(true);
                if (hodlerSlot.transform.childCount > 0)
                {
                    foreach (Transform item in hodlerSlot.transform)
                    {
                        Destroy(item.gameObject);
                    }
                }

                for (int i = 0; i < inventory.Count; i++)
                {
                    slot = Instantiate(prefabs, transform.position, transform.rotation);
                    slot.transform.SetParent(hodlerSlot.transform);
                    if (inventory[i] != null)
                    {
                        TextMeshProUGUI amount = slot.transform.Find("amount").GetComponent<TextMeshProUGUI>();
                        UnityEngine.UI.Image img = slot.transform.Find("icon").GetComponent<Image>();

                        amount.text = inventory[i].amount.ToString();
                        img.sprite = inventory[i].icon;
                    }
                }
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive((false));
            }
        }
    }
}