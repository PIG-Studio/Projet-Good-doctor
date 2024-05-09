using UnityEngine;

namespace InventoryTwo
{
    public class SlotItem : MonoBehaviour
    {
        public int itemSlot;

        public void ChargeItem()
        {
            InventoryManager.Instance.ChargeItem(itemSlot);
        }
    }
}