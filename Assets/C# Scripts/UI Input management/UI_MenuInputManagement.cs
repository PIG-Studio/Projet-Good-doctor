using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class UI_MenuInputManagement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(PARAM_Values.EscapeKey))
            CustomSceneManager.ChangeScene("Parameters");
    }
}
