using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_Prefab : MonoBehaviour
{
    protected static void Instancier(string canvasName, Dictionary<string, (string text, float posX, float posY, float width, float height)> dicoButtons)
    {
        GameObject canvas = new GameObject(canvasName, new Type[] { });
        canvas.AddComponent<RectTransform>();
        canvas.transform.position = new Vector3(0, 0);
        canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        
                //new RectTransform(),
                //new Canvas(){renderMode = RenderMode.ScreenSpaceOverlay, pixelPerfect = false, sortingOrder = 0,targetDisplay = 0, additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1}//,
                //new CanvasScaler() {uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize, referenceResolution = new(1920f, 1080f), screenMatchMode = CanvasScaler.ScreenMatchMode.Expand, referencePixelsPerUnit = 10},
                //new GraphicRaycaster() {ignoreReversedGraphics = true, blockingObjects = GraphicRaycaster.BlockingObjects.None}
                
        
        
        //GameObject newCanvas = Instantiate(canvas);
        GameObject button;
        foreach (var cle in dicoButtons.Keys)
        {
            (string, float, float, float, float ) temp = dicoButtons[cle];
            
            button = new GameObject(cle, new Type[] { });
            button.AddComponent<RectTransform>();
            button.transform.localPosition = new Vector3(temp.Item2, temp.Item3);
            button.AddComponent<CanvasRenderer>();
            button.AddComponent<Image>().sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            button.GetComponent<Image>().type = Image.Type.Sliced;
            button.AddComponent<Button>();
            TMP_Text text = new TextMeshPro() { };
            
            
                /*new CanvasRenderer() { cullTransparentMesh = true},
                new Image(),
                new Button() { interactable = true}
                ]
                );
            button.onClick.AddListener(SpawnPlayer);*/
            
            //GameObject newButton = Instantiate(button) as GameObject;
            button.transform.SetParent(canvas.transform, false);
            text.transform.SetParent(canvas.transform, false);
        }

        
    }
    
    public static void test()
    {
        Dictionary<string, (string text, float posX, float posY, float width, float height)> dicoBTN =
            new Dictionary<string, (string text, float posX, float posY, float width, float height)>
                () { };
        dicoBTN["testBTN"] = ("testBTN", 0f, 0f, 100f, 100f);
        Instancier("testCanv", dicoBTN);
    }
    
}
