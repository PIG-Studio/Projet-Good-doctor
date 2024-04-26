using static CustomScenes.Manager;
using UnityEngine;
using static GameCore.GameVAR.Variables;

namespace UI_Scripts.UI_Input_Management
{
    public class UIParamInputManagement : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(PARAMValues.EscapeKey) && !PARAMValues.TextInput)
                ChangeScene(SceneNameLast);
        }
    }
}