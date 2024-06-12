using Super.Interfaces.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inventories
{
    public class UpdateDescription : MonoBehaviour
    {
        [FormerlySerializedAs("InventoryTemp")] [SerializeField] public GameObject inventoryTemp;
        private IInventory Inventory { get; set; }
        private TextMeshProUGUI _desc;
        // Start is called before the first frame update
        void Start()
        {
            _desc = GetComponent<TextMeshProUGUI>();
            Inventory = inventoryTemp.GetComponent<IInventory>();
        }

        // Update is called once per frame
        void Update()
        {
            _desc.text = Inventory.DescActuelle??"";
        }
    }
}
