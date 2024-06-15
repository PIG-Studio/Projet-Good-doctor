using CustomScenes;
using GameCore.Variables;
using Inventories.Player;
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
        }

        public void Update()
        {
            if (transform.childCount > 0) // si contient des enfants
            {
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }

            uint n = Inventory.MaxLenght;
            for (uint i = 0; i < n; i++) //initialise l'inventaire
            {
                GameObject slot = Instantiate(PrefabSlot);
                DeskSlot slotItem = slot.GetComponent<DeskSlot>();
                slot.transform.SetParent(transform);
                slotItem.Inventory = Inventory;
                slotItem.index = i;
            }
        }
    }
}