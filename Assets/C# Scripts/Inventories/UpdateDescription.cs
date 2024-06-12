using System.Collections;
using System.Collections.Generic;
using Inventories.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDescription : MonoBehaviour
{
    //[SerializeField] public GameObject InventoryTemp;
    private IInventory Inventory { get; set; }
    private TextMeshProUGUI desc;
    private Image Icon;
    private TextMeshProUGUI Title;
    // Start is called before the first frame update
    void Start()
    {
        desc = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        Icon = transform.Find("Image").GetComponent<Image>();
        Title = transform.Find("NameObject").GetComponent<TextMeshProUGUI>();
        Inventory = Joueur.Base.JoueurFundamentals.Inventory;
    }

    // Update is called once per frame
    void Update()
    { Debug.Log("update description");
        desc.text = Inventory.DescActuelle??"";
        Icon.sprite = Inventory.ImageActuel ?? Resources.Load<Sprite>("UI/SquareGD");
        Title.text = Inventory.NomActuel;
    }
}
