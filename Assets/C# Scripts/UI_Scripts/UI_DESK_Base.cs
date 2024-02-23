using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.IO;
using System.Net;
>>>>>>> main
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
        Instancier("UI_DESK_BaseCanvas", dicoRender);
    }
}