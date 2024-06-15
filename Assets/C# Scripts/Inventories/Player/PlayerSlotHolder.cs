using Super.Interfaces.Inventory;
using UnityEngine;
using PlayerController.Base;
using TMPro;
using UnityEngine.UI;

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
        [SerializeField] public GameObject Inventorytemp;
        
        public void Start()
        {
            PrefabSlot = Resources.Load<GameObject>("Prefabs/Inventory/SlotItem");
            Inventory = Inventorytemp.GetComponent<IInventory>();
        }
        
        public void Update()
        {
            if (transform.childCount > 0) // si contient des enfants
            {
                for (int i = transform.childCount - 1 ; i >= 0; i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }

            int n = Inventory.Inventaire.Length;
            for (uint i = 0; i < n ; i++) //initialise l'inventaire
            {
                GameObject _slot = Instantiate(PrefabSlot, transform, true);
                PlayerSlot slotItem = _slot.GetComponent<PlayerSlot>();
                slotItem.Inventory = Inventory;
                slotItem.index = i;
            }
        }
    }
}