using System.Net.Mime;
using CustomScenes;
using GameCore.Variables;
using Parameters;
using ScriptableObject;
using Super.Interfaces.Inventory;
using TMPro;
using TypeExpand.String;
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
        public uint IndexActuel { get; set; }
        public uint PrixActuel { get; set; }

        public PlayerSlotHolder PSH { get; set; }
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
            IndexActuel = 0;
            PrixActuel = 0;
            
            PSH = transform.Find("Canvas").Find("Inventory").Find("HolderSlot").GetComponent<PlayerSlotHolder>();
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
            Debug.Log("update valeur description");
            if (Inventaire[i] is null)
            {
                NomActuel = "";
                ImageActuel = Resources.Load<Sprite>("UI/whiteSquare");
                DescActuelle = "";
                QuantiteAUtiliser = 0;
                QuantiteAct = 0;
                IndexActuel = i;
                PrixActuel = 0;
            }
            else
            {
                NomActuel = Inventaire[i].title;
                ImageActuel = Inventaire[i].icon;
                DescActuelle = Inventaire[i].description;
                QuantiteAct = Inventaire[i].amount;
                IndexActuel = i;
                PrixActuel = Inventaire[i].Price;
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
            PSH.UpdateSlot();
        }

        public void RemoveItem()
        {
            if (QuantiteAUtiliser > 0)
            {
                //Debug.Log("RemoveItem inventory");
                if (QuantiteAUtiliser == QuantiteAct)
                {
                    Inventaire[IndexActuel] = null;
                }
                else
                {
                    ItemsSo newItem = Inventaire[IndexActuel].CopyItem();
                    newItem.amount = QuantiteAct - QuantiteAUtiliser;

                    Inventaire[IndexActuel] = newItem;
                }

                UpdateDescription(IndexActuel);
            }
            PSH.UpdateSlot();
        }

        public void SwitchInventory()
        { 
            if (QuantiteAUtiliser > 0)
            {
                ItemsSo newItem = Inventaire[IndexActuel].CopyItem();
                newItem.amount = QuantiteAUtiliser;
                
                RemoveItem();
                Variable.SceneNameCurrent.ToDesk().Inventory.AddItem(newItem);
            }
            PSH.UpdateSlot();
        }

        public void UseItem()
        {
            if (QuantiteAUtiliser > 0)
            {
                if (Variable.SceneNameCurrent == Scenes.DBase)
                {
                    //utiliser objet dur patient.
                    Variable.CurrentlyRenderedDesk.Responsable.Money += QuantiteAUtiliser * Inventaire[IndexActuel].Price;
                }
                else
                {
                    //utiliser objet sur joueur.
                }

                RemoveItem();
            }
            PSH.UpdateSlot();
        }

        public void minusB()
        {
            if (QuantiteAUtiliser != 0)
                QuantiteAUtiliser--;
        }

        public void plusB()
        {
            if (QuantiteAUtiliser < QuantiteAct )
                QuantiteAUtiliser++;
        }
    }
}