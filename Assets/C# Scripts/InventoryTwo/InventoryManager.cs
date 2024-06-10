using System.Collections.Generic;
using ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Parameters;

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
        public GameObject holderDescription;
        public static InventoryManager Instance; // acceder partout
        public TextMeshProUGUI title, descriptionObject;
        public Image iconDescription;
        
        /// <summary>
        /// Méthode appelée lors du démarrage de l'objet
        /// </summary>
        private void Awake()
        {
            Instance = this;
        }
        private void Update()
        {
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
        /// <summary>
        /// Méthode pour charger les détails d'un item sélectionné
        /// </summary>
        /// <param name="i"></param>
        public void ChargeItem(int i)
        {
            holderDescription.SetActive(true);
            title.text = inventory[i].title;
            descriptionObject.text = inventory[i].description;
            iconDescription.sprite = inventory[i].icon;
            
        }
    }
}
