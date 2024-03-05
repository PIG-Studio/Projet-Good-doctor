using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEditor;
using UnityEngine;

public class UI_DESK_Base : UI_Prefab
{
    private void Start()
    {
        Dictionary<string, GameObject> dicoRender =
            new Dictionary<string, GameObject>
                () { };
        dicoRender["Parametres"] = ButtonChangeScene("Parameters", "Parametres", -300f, 100f, 150f, 50f, "Parameters");
        dicoRender["Menu"] = ButtonChangeScene("Menu", "Menu", -300f, -100f, 150f, 50f, "Menu");
        dicoRender["SaveGame"] = ButtonSave("SaveGame", "Save Game", 300f, 100f, 150f, 50f);
        dicoRender["Map"] = ButtonChangeScene("Map", "Map", 300f, -100f, 150f, 50f, "MapHospital");
        
        GameObject canv = Instancier("UI_DESK_BaseCanvas", dicoRender);
        
    }
}