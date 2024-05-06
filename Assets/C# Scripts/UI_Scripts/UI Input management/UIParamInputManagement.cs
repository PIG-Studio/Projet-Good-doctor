using Parameters;
using static CustomScenes.Manager;
using UnityEngine;
using GameCore.Variables;

namespace UI_Scripts.UI_Input_Management
{
    public class UIParamInputManagement : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(Values.EscapeKey) && !Values.TextInput)
                ChangeScene(Variable.SceneNameLast);
        }
    }
}