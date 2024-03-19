using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Parameters : UI_Prefab
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, GameObject> dicoRender =
            new Dictionary<string, GameObject>
                () { };
        dicoRender["Retour"] = ButtonChangeScene("Retour", GameVariables.SceneName_Last, -500f, 300f, 150f, 50f, GameVariables.SceneName_Last);
        dicoRender["Resolution"] = NewDropdown<PARAM_Resolutions>("DDW_Resolutions", "Resolutions", -300, 100, 175, 80);
        dicoRender["Windowed"] = NewDropdown<PARAM_WindowMode>("DDW_Windowed", "Windowed", 0, 100, 175, 80, heightOption:40f);
        dicoRender["Hz"] = NewDropdown<PARAM_HzRate>("DDW_HZ", "HZ", 300, 100, 175, 80);
        Instancier("UI_ParamCanvas", dicoRender); 
    }
}
