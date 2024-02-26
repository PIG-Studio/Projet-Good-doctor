using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using Alteruna;
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
        dicoRender["Quit"] = ButtonQuit("Quit", "Quit", -300f, -100f, 150f, 50f);
        dicoRender["SaveGame"] = ButtonSave("SaveGame", "Save Game", 300f, 100f, 150f, 50f);
        
        GameObject canv = Instancier("UI_DESK_BaseCanvas", dicoRender);
        
        GameObject prefabMenuRoom = Resources.Load<GameObject>("Room Menu");
        GameObject menuRoom = Instantiate(prefabMenuRoom);

    }
}