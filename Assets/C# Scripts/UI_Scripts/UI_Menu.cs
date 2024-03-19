using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : UI_Prefab
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, GameObject> dicoRender =
            new Dictionary<string, GameObject>
                () { };
        dicoRender["Parametres"] = ButtonChangeScene("Parameters", "Parametres", -300f, 100f, 150f, 50f, "Parameters");
        dicoRender["Quit"] = ButtonQuit("Quit", "Quit", -300f, -100f, 150f, 50f);
        dicoRender["InputGameName"] = InputField("input", 300f, -100f, 150f, 50f);
        dicoRender["NewGame"] = ButtonNewGame("NewGame", "New Game", 300f, 100f, 150f, 50f);
        dicoRender["LoadGame"] = ButtonLoad("LoadGame", "Load Game", 300f, 0f, 150f, 50f);
        Instancier("UI_MenuCanvas", dicoRender);
    }

}
