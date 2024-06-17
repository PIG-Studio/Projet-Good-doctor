using GameCore.Variables;
using Super.Interfaces.Inventory;
using TypeExpand.String;
using UnityEngine;

namespace Inventories.Desk
{
    public class DeskSlotHolder : MonoBehaviour, ISlotHolder
    {
        public uint Col { get; }
        public GameObject PrefabSlot { get; set; }
        public IInventory Inventory { get; set; }
        //[SerializeField] public GameObject Inventorytemp;
        public void Start()
        {
            PrefabSlot = Resources.Load<GameObject>("Prefabs/Inventory/DeskSlotItem");
            Inventory =  Variable.SceneNameCurrent.ToDesk()!.Inventory;
            UpdateSlot();
        }

        public void UpdateSlot()
        {
            if (transform.childCount > 0) // si contient des enfants
            {
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }

            int n = Inventory.Inventaire.Length;
            for (uint i = 0; i < n; i++) //initialise l'inventaire
            {
                GameObject slot = Instantiate(PrefabSlot, transform, true);
                DeskSlot slotItem = slot.GetComponent<DeskSlot>();
                slotItem.Inventory = Inventory;
                slotItem.Index = i;
            }
        }
    }
}