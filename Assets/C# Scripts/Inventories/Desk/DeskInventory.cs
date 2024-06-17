using CustomScenes;
using GameCore.Variables;
using ScriptableObject;
using Super.Interfaces.Inventory;
using Super.Interfaces.Patient;
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
        public uint IndexActuel { get; set; }
        public uint PrixActuel { get; set; }

        public ItemsSo[] Inventaire { get; set; }
        public DeskSlotHolder Psh { get; set; }
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
            PrixActuel = 0;
            
            Psh = transform.Find("SlotHolder").GetComponent<DeskSlotHolder>();
            Psh.Start();
            Psh.UpdateSlot();
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
                IndexActuel = 0;
                PrixActuel = 0;
            }
            else
            {
                NomActuel = Inventaire[i].title;
                ImageActuel = Inventaire[i].icon;
                QuantiteAct = Inventaire[i].amount;
                IndexActuel = i;
                PrixActuel = Inventaire[i].price;
            }
        }

        public void AddItem(ItemsSo item)
        {
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
            //Debug.Log("RemoveItem Desk");
            if (QuantiteAUtiliser > QuantiteAct)
            {
                QuantiteAUtiliser = 0;
                return;
            }
            if (QuantiteAUtiliser == QuantiteAct && QuantiteAct == 0)
            {
                Inventaire[IndexActuel] = null;
            }
            else if (QuantiteAUtiliser > 0)
            {
                ItemsSo newItem = Inventaire[IndexActuel].CopyItem();
                newItem.amount = QuantiteAct - QuantiteAUtiliser;
                
                Inventaire[IndexActuel] = newItem;
            }
            UpdateDescription(IndexActuel);
            Psh.UpdateSlot();
        }

        public void SwitchInventory()
        {
            if (QuantiteAUtiliser > QuantiteAct)
            {
                QuantiteAUtiliser = 0;
                return;
            }
            if (QuantiteAUtiliser > 0 && Variable.SceneNameCurrent == Scenes.DBase)
            {
                ItemsSo newItem = Inventaire[IndexActuel].CopyItem();
                newItem.amount = QuantiteAUtiliser;
                
                RemoveItem();
                Variable.CurrentlyRenderedDesk.Responsable.Inventory.AddItem(newItem);
                UpdateDescription(IndexActuel);
                
            }
            if (QuantiteAct == 0)
            {
                Inventaire[IndexActuel] = null;
            }
            Psh.UpdateSlot();
        }

        public void UseItem()
        {
            if (QuantiteAUtiliser > QuantiteAct)
            {
                QuantiteAUtiliser = 0;
                return;
            }
            if (QuantiteAUtiliser > 0  && Variable.CurrentlyRenderedDesk.CurrentPatient is not null)
            {
                Inventaire[IndexActuel].ModifyStat((IPatient)Variable.SceneNameCurrent.ToDesk()!.CurrentPatient); 
                Variable.CurrentlyRenderedDesk.Responsable.Money += QuantiteAUtiliser * Inventaire[IndexActuel].price;
                RemoveItem();
                UpdateDescription(IndexActuel);
            }
            if (QuantiteAct == 0)
            {
                Inventaire[IndexActuel] = null;
            }
            Psh.UpdateSlot();
        }

        public void MinusB()
        {
            if (QuantiteAUtiliser > 0)
                QuantiteAUtiliser--;
        }

        public void PlusB()
        {
            if (QuantiteAUtiliser < QuantiteAct)
                QuantiteAUtiliser++;
        }
    }
}