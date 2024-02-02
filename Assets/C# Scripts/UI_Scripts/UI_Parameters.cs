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
        dicoRender["Retour"] = ButtonChangeScene("Retour", GameVariables.SceneName_Last, -300f, 100f, 150f, 50f, GameVariables.SceneName_Last);
        dicoRender["Res"] = NewDropdown("Res", "Resolutions", 100, 100, 100, 100);
        Instancier("UI_ParamCanvas", dicoRender); 
    }
}
