using static CustomScenes.Manager;
using UnityEngine;
using static GameCore.Variables;

public class UI_ParamInputManagement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(PARAM_Values.EscapeKey) && !PARAM_Values.TextInput)
            ChangeScene(SceneName_Last);
    }
}
