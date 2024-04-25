using System;
using GameCore;
using GameCore.TypeExpand;
using Inventories;
using JetBrains.Annotations;
using UnityEngine;
using UI_Prefab;

/// <summary>
/// script rendering the inventory of the desk, A N UTILISER QUE DANS DES BUREAUX AVEC UN INVENTAIRE
/// </summary>
public class RenderInventory : MonoBehaviour
{
    /// <summary>
    /// Field pour savoir quel objet manipuler
    /// </summary>
    [NotNull]
    private Desk DesktoRender { get; set; }
    
    /// <summary>
    /// L inventaire lie au bureau
    /// </summary>
    private Inventory InventorytoRender { get; set; }


    public void Start()
    {
        //
        GameObject inventoryRender = UI_Prefabs.INV_Inventory(Resources.Load<Sprite>("inventory"), "Inventory", 0, 0, 500, 50);
        
        // On recupere le bureau et l inventaire a afficher, NULL REFERENCE si script pas dans un bureau
        DesktoRender = Variables.SceneName_Current.ToDesk();
        InventorytoRender = DesktoRender.Inventory;
        
        uint i = 0;
        foreach (Slot vSlot in InventorytoRender.Slots)
        {
            if (vSlot.Amount == 0)
            {
                vSlot.Object = UI_Prefabs.INV_Slot(vSlot.Image, i, true);
            }
            else
            {
                vSlot.Object = UI_Prefabs.INV_Slot(vSlot.Image, i);
            }
            vSlot.Object.transform.SetParent(inventoryRender.transform);
            i++;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            Variables.Desk_Base.Inventory.AddItem(Medicaments.CYAMURE(1));
            Debug.Log("Added CYAMURE to desk inventory");
        }
        if (InventorytoRender.HasChanged)
        {
            Debug.Log("Inventory has changed, rendering new inventory...");
            uint i = 0;
            foreach (Slot vSlot in InventorytoRender.Slots)
            {
                if (vSlot.HasChanged && vSlot.Amount != 0)
                {
                    // On recup le composant SpriteRenderer du slot
                    SpriteRenderer comp = vSlot.Object.GetComponent<SpriteRenderer>();
                    
                    // On actualise l'image du slot
                    comp.sprite = vSlot.Amount != 0 ? vSlot.Image : null;
                    
                    // Pour ne pas parse le slot a l'infini
                    vSlot.HasChanged = false;
                }
                i++;
            }
            InventorytoRender.HasChanged = false;
            Debug.Log("Inventory rendered");
        }
    }
}