using System.Collections.Generic;
using ScriptableObject;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace InventoryTwo
{
    public class InventoryManager : MonoBehaviour
    {
        public List<ItemsSo> inventory;
        public int inventoryLenght = 15;
        public GameObject inventoryPanel, hodlerSlot;
        private GameObject _slot;
        public GameObject prefabs;

        public static InventoryManager Instance;

        private void Awake()
        {
            Instance = this;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I) && !inventoryPanel.activeInHierarchy)
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
                    _slot = Instantiate(prefabs, transform.position, transform.rotation);
                    _slot.transform.SetParent(hodlerSlot.transform);
                    if (inventory[i] is not null)
                    {
                        TextMeshProUGUI amount = _slot.transform.Find("amount").GetComponent<TextMeshProUGUI>();
                        Image img = _slot.transform.Find("icon").GetComponent<Image>();

                        amount.text = inventory[i].amount.ToString();
                        img.sprite = inventory[i].icon;
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
