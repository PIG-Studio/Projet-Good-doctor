using CustomScenes;
using GameCore.Variables;
using Parameters;
using ScriptableObject;
using Super.Interfaces.Inventory;
using TypeExpand.String;
using UnityEngine;

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

        public PlayerSlotHolder Psh { get; set; }
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
            
            Psh = transform.Find("Canvas").Find("Inventory").Find("HolderSlot").GetComponent<PlayerSlotHolder>();
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
                ImageActuel = Resources.Load<Sprite>("UI/SquareGD");
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
                PrixActuel = Inventaire[i].price;
                IndexActuel = i;
                
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
            Psh.UpdateSlot();
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
            Psh.UpdateSlot();
        }

        public void SwitchInventory()
        { 
            if (QuantiteAUtiliser > 0)
            {
                ItemsSo newItem = Inventaire[IndexActuel].CopyItem();
                newItem.amount = QuantiteAUtiliser;
                
                RemoveItem();
                Variable.SceneNameCurrent.ToDesk()!.Inventory.AddItem(newItem);
            }
            Psh.UpdateSlot();
        }

        public void UseItem()
        {
            if (QuantiteAUtiliser > 0)
            {
                if (Variable.SceneNameCurrent == Scenes.DBase)
                {
                    //utiliser objet dur patient.
                    Variable.CurrentlyRenderedDesk.Responsable.Money += QuantiteAUtiliser * Inventaire[IndexActuel].price;
                    if (Inventaire[IndexActuel].deadly && Variable.CurrentlyRenderedDesk.Responsable.Reputation > 0)
                        Variable.CurrentlyRenderedDesk.Responsable.Reputation -= 20;
                }
                else
                {
                    //utiliser objet sur joueur.
                    //si medicament est mortel dire que c'est la fin du jeu.
                }

                RemoveItem();
            }
            Psh.UpdateSlot();
        }

        public void MinusB()
        {
            if (QuantiteAUtiliser != 0)
                QuantiteAUtiliser--;
        }

        public void PlusB()
        {
            if (QuantiteAUtiliser < QuantiteAct )
                QuantiteAUtiliser++;
        }
    }
}