using CustomScenes;
using GameCore.Variables;
using ScriptableObject;
using Super.Interfaces.Inventory;
using TypeExpand.String;
using UnityEngine;

namespace Inventories.Desk
{
    public class DeskInventory : MonoBehaviour, IInventory
    {
        
        public string NomActuel { get; set; }
        public Sprite ImageActuel { get; set; }
        public string DescActuelle { get; set; }
        public uint QuantiteAUtiliser { get; set; }
        public uint QuantiteAct { get; set; }
        
        public ItemsSo[] Inventaire { get; set; }
        
        public uint MaxLenght
        {
            get => 24;
        }
        
        public void Start()
        {
            Inventaire = Variable.SceneNameCurrent.ToDesk()!.Inventaire;
            Variable.SceneNameCurrent.ToDesk()!.Inventory = this;
            NomActuel = null;
            ImageActuel = null;
            DescActuelle = null;
            QuantiteAct = 0;
            QuantiteAUtiliser = 0;
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void Update()
        {
            /*if (Variable.SceneNameCurrent == Scenes.DBase) //quand dans desk
            {
                transform.GetChild(0).gameObject.SetActive(true);

            }
            else
                // Si pas dans desk, fermer l'inventaire
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }*/ // Desk_inv est dans un desk, le update n est donc appele uniquement lorsqu on est dans desk
        }

        public void UpdateDescription(uint i)
        {
            if (Inventaire[i] is null)
            {
                NomActuel = "";
                ImageActuel = null;
                QuantiteAct = 0;
            }
            else
            {
                NomActuel = Inventaire[i].title;
                ImageActuel = Inventaire[i].icon;
                QuantiteAct = Inventaire[i].amount;
            }
        }

        public void AddItem(ItemsSo item)
        {
            Debug.Log("addItem Desk Inventory");
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

        public void RemoveItem(uint index)
        {
            //Debug.Log("RemoveItem Desk");
            if (QuantiteAUtiliser == QuantiteAct)
            {
                Inventaire[index] = null;
            }
            else
            {
                ItemsSo newItem = UnityEngine.ScriptableObject.CreateInstance<ItemsSo>();
                newItem.title = Inventaire[index].title;
                newItem.description = Inventaire[index].description;
                newItem.amount = QuantiteAct - QuantiteAUtiliser;
                newItem.icon = Inventaire[index].icon;
                newItem.isStackable = Inventaire[index].isStackable;
                newItem.type = Inventaire[index].type;
                
                Inventaire[index] = newItem;
            }
            UpdateDescription(index);
        }

        public void GiveItem(uint index, IInventory inventory)
        {
            ItemsSo newItem = UnityEngine.ScriptableObject.CreateInstance<ItemsSo>();
            newItem.title = Inventaire[index].title;
            newItem.description = Inventaire[index].description;
            newItem.amount = QuantiteAUtiliser;
            newItem.icon = Inventaire[index].icon;
            newItem.isStackable = Inventaire[index].isStackable;
            newItem.type = Inventaire[index].type;
            
            RemoveItem(index);
            inventory.AddItem(newItem);
        }
    }
}