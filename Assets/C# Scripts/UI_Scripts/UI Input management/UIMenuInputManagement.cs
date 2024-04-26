using Parameters;
using UnityEngine;
using static CustomScenes.Manager;

namespace Interfaces.UI_Input_management
{
    public class UIMenuInputManagement : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(Values.EscapeKey))
                ChangeScene("Parameters");
        }
    }
}