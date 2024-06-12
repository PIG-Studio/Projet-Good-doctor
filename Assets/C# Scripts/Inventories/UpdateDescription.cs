using System.Collections;
using System.Collections.Generic;
using Inventories.Player;
using TMPro;
using UnityEngine;

public class UpdateDescription : MonoBehaviour
{
    [SerializeField] public GameObject InventoryTemp;
    private IInventory Inventory { get; set; }
    private TextMeshProUGUI desc;
    // Start is called before the first frame update
    void Start()
    {
        desc = GetComponent<TextMeshProUGUI>();
        Inventory = InventoryTemp.GetComponent<IInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        desc.text = Inventory.DescActuelle??"";
    }
}
