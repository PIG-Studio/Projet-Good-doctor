using static CustomScenes.Manager;
using UnityEngine;
using static GameCore.GameVAR.Variables;

public class UI_ParamInputManagement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(PARAMValues.EscapeKey) && !PARAMValues.TextInput)
            ChangeScene(SceneNameLast);
    }
}
