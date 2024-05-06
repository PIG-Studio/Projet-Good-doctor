using GameCore.Variables;
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
                Variable.DeskBase.Inventory.AddItem(Medicaments.Acces.Cyamure(1));
            }
        }
    }
}