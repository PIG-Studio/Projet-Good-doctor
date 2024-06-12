using Inventories.Player;
using Image = UnityEngine.UI.Image;
using TMPro;
using UnityEngine;

namespace Super.Interfaces.Inventory
{
    public interface ISlot
    {
        IInventory Inventory { get; set; }
        uint Amount { get; set; }
        Sprite Image { get; set; }
        TextMeshPro TextAmount { get; set; }
        uint index { get; set; }
        void SetDescriptionValues();
    }
}