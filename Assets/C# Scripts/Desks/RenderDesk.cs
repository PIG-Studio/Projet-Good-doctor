using GameCore.Variables;
using Inventories;
//using Inventories.Slots;
using TypeExpand.String;
using UnityEngine;
using UI_Scripts.UI_Prefab;

namespace Desks
{

    /// <summary>
    /// script rendering the inventory of the desk, A N UTILISER QUE DANS DES BUREAUX AVEC UN INVENTAIRE
    /// </summary>
    public class RenderInventory : MonoBehaviour
    {
        // <summary>
        // Field pour savoir quel objet manipuler
        // </summary>
        //[NotNull]
        //private Desk DeskToRender { get; set; }

        /// <summary>
        /// L inventaire lie au bureau
        /// </summary>
      // private Inventory InventoryToRender { get; set; }


        public void Start()
        {
            GameObject inventoryRender =
                UIPrefabs.INV_Inventory(Resources.Load<Sprite>("inventory"), "Inventory", 0, 0, 500, 50);

            // On récupere le bureau et l'inventaire à afficher, NULL REFERENCE si script pas dans un bureau
            /*InventoryToRender = Variable.SceneNameCurrent.ToDesk()!.Inventory;

            uint i = 0;
            foreach (Slot vSlot in InventoryToRender.Slots)
            {
                if (vSlot.Amount == 0)
                {
                    vSlot.Object = UIPrefabs.INV_Slot(vSlot.Image, i, true);
                }
                else
                {
                    vSlot.Object = UIPrefabs.INV_Slot(vSlot.Image, i);
                }

                vSlot.Object!.transform.SetParent(inventoryRender.transform);
                i++;
            }*/
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Variable.DeskBase.Inventory.AddItem(Medicaments.Acces.Cyamure(1));
                Debug.Log("Added CYAMURE to desk inventory");
            }

            /*if (InventoryToRender.HasChanged)
            {
                Debug.Log("Inventory has changed, rendering new inventory...");
                foreach (Slot vSlot in InventoryToRender.Slots)
                {
                    if (vSlot.HasChanged && vSlot.Amount != 0)
                    {
                        // On recup le composant SpriteRenderer du slot
                        SpriteRenderer comp = vSlot.Object!.GetComponent<SpriteRenderer>();

                        // On actualise l'image du slot
                        comp.sprite = vSlot.Amount != 0 ? vSlot.Image : null;

                        // Pour ne pas parse le slot a l'infini
                        vSlot.HasChanged = false;
                    }
                }

                InventoryToRender.HasChanged = false;
                Debug.Log("Inventory rendered");
            }*/
        }
    }
}