using GameCore.GameVAR;
using Medicaments;
using UnityEngine;

namespace Interfaces.UI_Input_management
{
    public class UIDeskInputManagement : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(PARAMValues.EscapeKey))
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(!child.gameObject.activeSelf);
                }
            if (Input.GetKeyDown(KeyCode.E))
            {   
                Variables.DeskBase.Inventory.AddItem(Medicaments.Acces.CYAMURE(1));
            }
        }
    }
}