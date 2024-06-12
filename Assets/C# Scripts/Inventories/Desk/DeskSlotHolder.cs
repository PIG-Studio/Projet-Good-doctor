using Inventories.Player;
using Super.Interfaces.Inventory;
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
            PrefabSlot = Resources.Load<GameObject>("Prefabs/Inventory/DeskInventory");
            Inventory = Desks.Desk.Inventory;
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

            int n = Inventory.Inventaire.Length;
            for (uint i = 0; i < n; i++) //initialise l'inventaire
            {
                GameObject _slot = Instantiate(PrefabSlot);
                DeskSlot slotItem = _slot.GetComponent<DeskSlot>();
                _slot.transform.SetParent(transform);
                slotItem.Inventory = Inventory;
                slotItem.index = i;
            }
        }
    }
}