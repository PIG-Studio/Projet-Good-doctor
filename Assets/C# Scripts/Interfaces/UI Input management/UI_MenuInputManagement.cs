using UnityEngine;
using static CustomScenes.Manager;

public class UI_MenuInputManagement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PARAMValues.EscapeKey))
            ChangeScene("Parameters");
    }
}
