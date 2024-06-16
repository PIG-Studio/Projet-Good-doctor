using Super.Interfaces.Inventory;
using UnityEngine;

namespace Inventories.Player
{
    public class PlayerSlotHolder : MonoBehaviour, ISlotHolder
    {
        public uint Col
        {
            get => 5;
        }
        public GameObject PrefabSlot { get; set; }
        public IInventory Inventory { get; set; }
        [SerializeField] public GameObject inventoryTemp;
        
        public void Start()
        {
            PrefabSlot = Resources.Load<GameObject>("Prefabs/Inventory/SlotItem");
            Inventory = inventoryTemp.
                GetComponent<IInventory>();
            Debug.Log($"start slot holder {Inventory}");
            UpdateSlot();
        }
        
        public void UpdateSlot()
        {
            Debug.Log("update slor holder");
            if (transform.childCount > 0) // si contient des enfants
            {
                for (int i = transform.childCount - 1 ; i >= 0; i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }

            uint n = Inventory.MaxLenght;
            for (uint i = 0; i < n ; i++) //initialise l'inventaire
            {
                GameObject slot = Instantiate(PrefabSlot, transform, true);
                PlayerSlot slotItem = slot.GetComponent<PlayerSlot>();
                slotItem.Inventory = Inventory;
                slotItem.Index = i;
            }
        }
    }
}