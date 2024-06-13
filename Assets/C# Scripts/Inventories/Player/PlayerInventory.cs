using System.Net.Mime;
using Parameters;
using ScriptableObject;
using Super.Interfaces.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Inventories.Player
{
    public class PlayerInventory : MonoBehaviour, IInventory
    {
        public ItemsSo[] Inventaire { get; set; }
        public string NomActuel { get; set; }
        public Sprite ImageActuel { get; set; }
        public string DescActuelle { get; set; }
        public uint QuantiteAUtiliser { get; set; }
        public uint QuantiteAct { get; set; }

        public uint MaxLenght
        {
            get => 15;
        }
        
        public void Start()
        {
            Inventaire = new ItemsSo[MaxLenght];
            
            NomActuel = null;
            ImageActuel = null;
            DescActuelle = null;
            QuantiteAUtiliser = 0;
            QuantiteAct = 0;
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(Keys.InventoryKey) && !transform.GetChild(0).gameObject.activeInHierarchy ) //quand i est pressé et que l'UI n'est pas activé 
            {
               transform.GetChild(0).gameObject.SetActive(true);
               
            }
            else if (Input.GetKeyDown(KeyCode.I) && transform.GetChild(0).gameObject.activeInHierarchy )
                // Si la touche pour fermer l'inventaire est enfoncée et que le panneau d'inventaire est ouvert
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        public void UpdateDescription(uint i)
        {
            if (Inventaire[i] is null)
            {
                NomActuel = "";
                ImageActuel = Resources.Load<Sprite>("UI/whiteSquare");
                DescActuelle = "";
                QuantiteAUtiliser = 0;
                QuantiteAct = 0;
            }
            else
            {
                NomActuel = Inventaire[i].title;
                ImageActuel = Inventaire[i].icon;
                DescActuelle = Inventaire[i].description;
                QuantiteAct = Inventaire[i].amount;
            }
        }

        public void AddItem(ItemsSo item)
        {
            Debug.Log("addItem Inventory");
            for (uint i = 0; i < Inventaire.Length; i++)
            {
                if (Inventaire[i] is not null)
                {
                    if (Inventaire[i].title == item.title && Inventaire[i].isStackable)
                    {
                        item.amount += Inventaire[i].amount;
                        Inventaire[i] = null;
                    }
                }
            }
            for (uint i = 0; i < Inventaire.Length; i++)
            {
                if (Inventaire[i] is null)
                {
                    Inventaire[i] = item;
                    break;
                }
            }
        }

        public void RemoveItem(ItemsSo item)
        {
            throw new System.NotImplementedException();
        }

        public void GiveItem(ItemsSo item, IInventory inventory)
        {
            throw new System.NotImplementedException();
        }
    }
}