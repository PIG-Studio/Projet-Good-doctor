using Interfaces;
using TMPro;
using UnityEngine.UI;

namespace Super.Interfaces.Inventory
{
    public interface IUpdateDesc
    {
        public IInventory Inventory { get; set; }
        public TextMeshProUGUI desc { get; set; }
        public Image Icon { get; set; }
        public TextMeshProUGUI Title { get; set; }
        public TextMeshProUGUI Amount { get; set; }

        void Start();
        void Update();
    }
}