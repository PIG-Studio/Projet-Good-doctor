using GameCore.GameVAR;
using Parameters;
using UnityEngine;

namespace UI_Scripts.UI_Input_management
{
    public class UIDeskInputManagement : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(Values.EscapeKey))
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