using Image = UnityEngine.UI.Image;
using TMPro;

namespace Super.Interfaces.Inventory
{
    public interface ISlot
    {
        IInventory Inventory { get; set; }
        uint Amount { get; set; }
        Image Image { get; set; }
        TextMeshProUGUI TextAmount { get; set; }
        uint Index { get; set; }
        void Start();
        void Update();
        void SetDescriptionValues();
    }
}