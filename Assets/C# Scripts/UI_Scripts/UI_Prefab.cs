using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Prefab : MonoBehaviour
{
    public enum UI_Types /* Available types for scripting UI objects                                                    TODO: A REMOVE ? */
    {
        BTN_ChangeScene,
        BTN_Quit,
        BTN_NewGame
    }
    
    
    private static GameObject TextComponentCreator(string textShown, GameObject parent, string name="Text")
    {
        /* Prend un objet parent et lui cree et ajoute un component affichant du texte */

        Canvas.ForceUpdateCanvases();
        GameObject text = new GameObject(name, new Type[] { });
        text.AddComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        text.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        text.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        text.AddComponent<CanvasRenderer>();
        text.AddComponent<TextMeshProUGUI>().text = textShown;
        text.GetComponent<TextMeshProUGUI>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
        text.GetComponent<TextMeshProUGUI>().horizontalAlignment = HorizontalAlignmentOptions.Center;
        text.GetComponent<TextMeshProUGUI>().verticalAlignment = VerticalAlignmentOptions.Middle;
        text.GetComponent<TextMeshProUGUI>().fontSize = 23;
        text.GetComponent<TextMeshProUGUI>().enableAutoSizing = false;
        
        text.transform.SetParent(parent.transform, false);

        return text;
    }

    private static GameObject NewUiElementBase(string id, float posX, float posY, float width, float height)
    {
        GameObject button = new GameObject(id, new Type[] { });
        
        button.AddComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        button.transform.localPosition = new Vector3(posX, posY);
        button.AddComponent<CanvasRenderer>();
        button.AddComponent<Image>().sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        button.GetComponent<Image>().type = Image.Type.Sliced;
        
        return button;
    }


    private static GameObject NewInputField(string id, float posX, float posY, float width, float height)
    {
        GameObject field = NewUiElementBase(id, posX, posY, width, height);

        GameObject textArea = new GameObject("Text Area");
        textArea.AddComponent<RectTransform>();
        textArea.AddComponent<RectMask2D>();
        textArea.transform.SetParent(field.transform, false);

        GameObject placeholder = TextComponentCreator("Enter text...", textArea, "Placeholder");
        GameObject textCompo = TextComponentCreator("", textArea);       
        
        field.AddComponent<TMP_InputField>().targetGraphic = field.GetComponent<UnityEngine.UI.Image>();
        field.GetComponent<TMP_InputField>().textViewport = textArea.GetComponent<RectTransform>();
        field.GetComponent<TMP_InputField>().textComponent = textCompo.GetComponent<TextMeshProUGUI>();
        field.GetComponent<TMP_InputField>().placeholder = placeholder.GetComponent<TextMeshProUGUI>();
        
        field.GetComponent<TMP_InputField>().onSelect.AddListener( (string input) => CustomSceneManager.ChangeSelect() );
        field.GetComponent<TMP_InputField>().onValueChanged.AddListener( (string input) => GameVariables.SetSaveName( input ) );
        field.GetComponent<TMP_InputField>().onDeselect.AddListener( (string input) => CustomSceneManager.ChangeSelect() );
        
        return field;
    }

    private static GameObject NewButton(string id, string text, float posX, float posY, float width, float height, UnityAction onClickActon)
    {
        GameObject button = NewUiElementBase(id, posX, posY, width, height);
        TextComponentCreator(text, button);
        button.AddComponent<Button>().onClick.AddListener(onClickActon);
        return button;

    }
    protected static void Instancier(string canvasName, Dictionary<string, GameObject> dicoUiComponents)
    {
        /* Cree un nouveau canvas et y ajoute les objects du dicoUiComponents */
        
        GameObject canvas = new GameObject(canvasName, new Type[] { });
        canvas.AddComponent<RectTransform>();
        canvas.transform.position = new Vector3(0, 0);
        canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        
        foreach (var cle in dicoUiComponents.Keys)
        {
            GameObject temp = dicoUiComponents[cle];
            temp.transform.SetParent(canvas.transform, false);
        }
    }
    
    protected static GameObject ButtonChangeScene(string id,string text, float posX, float posY, float width, float height, string newScene)
    {
        /* Renvoie un nouveau bouton changent de scene vers le param newScene */ 
        return NewButton(id, text, posX, posY,width, height, () => CustomSceneManager.ChangeScene(newScene)); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
    }
    
    protected static GameObject ButtonQuit(string id, string text, float posX, float posY, float width, float height)
    {
        return NewButton(id, text, posX, posY, width, height, () => CustomSceneManager.Quit());
    }

    protected static GameObject InputField(string id, float posX, float posY, float width, float height)
    {
        return NewInputField(id, posX, posY, width, height);
    }
    
    protected static GameObject ButtonNewGame(string id,string text, float posX, float posY, float width, float height)
    {
        return NewButton(id, text, posX, posY,width, height, () => GameVariables.NewGame(GameVariables.SaveName)); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
    }
    
    public static void test()
    {
        Dictionary<string, GameObject> dicoBTN =
            new Dictionary<string, GameObject>
                () { };
        dicoBTN["testBTN"] = ButtonQuit("Quit", "Quit", -300f, -300f, 150f, 75f);
        Instancier("testCanv", dicoBTN);
    }
    
}