using UnityEngine;

public class UI_ParamInputManagement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(PARAM_Values.EscapeKey) && !PARAM_Values.TextInput)
            CustomSceneManager.ChangeScene(GameVariables.SceneName_Last);
    }
}
