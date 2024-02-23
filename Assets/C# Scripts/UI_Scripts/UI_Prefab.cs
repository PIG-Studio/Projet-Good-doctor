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
    
    /// <summary>
    /// Deprecated for now
    /// </summary>
    public enum UI_Types /* Available types for scripting UI objects                                                    TODO: A REMOVE ? */
    {
        BTN_ChangeScene,
        BTN_Quit,
        BTN_NewGame
    }
    
    /// <summary>
    /// <value>Working as expected</value>
    /// method creating a text component, so we can create text on button, input fields, ...
    /// </summary>
    /// <param name="textShown">string - Text we want to show in this component</param>
    /// <param name="parent">GameObject - Component's parent, this method links this component with its parent</param>
    /// <param name="name">string - Component's identifier</param>
    /// <returns>GameObject - returns instantiated component</returns>
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

    
    /// <summary>
    /// <value>Working as expected</value>
    /// Instantiate a GameObject with common parameters for GameObject, like canvas renderer, rect transform, ...
    /// </summary>
    /// <param name="id"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
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


    /// <summary>
    /// <value>Working as expected</value>
    /// uses base methods to instantiate a new text input field
    /// </summary>
    /// <param name="id"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns>Created GameObject</returns>
    private static GameObject NewInputField(string id, float posX, float posY, float width, float height)
    {
        GameObject field = NewUiElementBase("TXTIN_" + id, posX, posY, width, height);

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
        field.GetComponent<TMP_InputField>().onValueChanged.AddListener( (string input) => SaveData.SetSaveName( input ) );
        field.GetComponent<TMP_InputField>().onDeselect.AddListener( (string input) => CustomSceneManager.ChangeSelect() );
        
        return field;
    }

    /// <summary>
    /// <value>Working as expected</value>
    /// uses base methods to instantiate a new button
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="onClickActon"></param>
    /// <returns></returns>
    private static GameObject NewButton(string id, string text, float posX, float posY, float width, float height, UnityAction onClickActon)
    {
        GameObject button = NewUiElementBase("BTN_" + id, posX, posY, width, height);
        TextComponentCreator(text, button);
        button.AddComponent<Button>().onClick.AddListener(onClickActon);
        return button;

    }
    
    /// <summary>
    /// <value>WIP</value>
    /// Should be private, temporarily on protected for testing purposes
    /// uses base methods to instantiate a new dropdown
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    protected static GameObject NewDropdown(string id, string text, float posX, float posY, float width, float height)
    {
        GameObject ddw = NewUiElementBase("DDW_" + id, posX, posY, width, height);
        TextComponentCreator(text, ddw);
        ddw.AddComponent<TMP_Dropdown>().targetGraphic = ddw.GetComponent<Image>();
        ddw.AddComponent<PARAM_Resolutions>().resolutionDropdown = ddw.GetComponent<TMP_Dropdown>();
        
        
        GameObject template = NewUiElementBase("template", 0, 0, 50, 50);
        template.transform.localPosition = new Vector3(0, 0);
        template.transform.SetParent(ddw.transform);
        template.AddComponent<ScrollRect>();
        
        GameObject viewport = NewUiElementBase("viewport", 0, 0, 50, 50);
        viewport.transform.localPosition = new Vector3(0, 0);
        viewport.transform.SetParent(ddw.transform);
        viewport.GetComponent<ScrollRect>();
        
        GameObject arrow = NewUiElementBase("Arrow", 0, 0, width*0.1f, height);
        arrow.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0);
        arrow.GetComponent<RectTransform>().anchoredPosition = Vector2.right;
        arrow.GetComponent<Image>().sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/DropdownArrow.psd");
        arrow.GetComponent<Image>().type = Image.Type.Sliced;
        arrow.transform.SetParent(ddw.transform);
        
        ddw.GetComponent<TMP_Dropdown>().template = template.GetComponent<RectTransform>();
        return ddw;
    }
    
    /// <summary>
    /// <value>Working as expected</value>
    /// Instantiates a new canvas and add components to render 
    /// </summary>
    /// <param name="canvasName"></param>
    /// <param name="dicoUiComponents"></param>
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
    
    /// <summary>
    /// <value>Working as expected</value>
    /// Protected method to create a button that changes to another scene, according to its parameters.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="newScene"></param>
    /// <returns></returns>
    protected static GameObject ButtonChangeScene(string id,string text, float posX, float posY, float width, float height, string newScene)
    {
        /* Renvoie un nouveau bouton changent de scene vers le param newScene */ 
        return NewButton( id, text, posX, posY,width, height, () => CustomSceneManager.ChangeScene(newScene)); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
    }
    
    /// <summary>
    /// <value>Working as expected</value>
    /// Protected method to create a button that quit the app.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    protected static GameObject ButtonQuit(string id, string text, float posX, float posY, float width, float height)
    {
        return NewButton(id, text, posX, posY, width, height, () => CustomSceneManager.Quit());
    }

    
    /// <summary>
    /// <value>Working as expected</value>
    /// Protected method to create a text input field.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    protected static GameObject InputField(string id, float posX, float posY, float width, float height)
    {
        return NewInputField(id, posX, posY, width, height);
    }
    
    /// <summary>
    /// <value>Working as expected</value>
    /// Protected method to create a button that launches a new game.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    protected static GameObject ButtonNewGame(string id,string text, float posX, float posY, float width, float height)
    {
        return NewButton(id, text, posX, posY,width, height, () => GameVariables.NewGame(GameVariables.SaveName)); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
    }
    
    
    /// <summary>
    /// test method, kinda useless
    /// </summary>
    public static void test()
    {
        Dictionary<string, GameObject> dicoBTN =
            new Dictionary<string, GameObject>
                () { };
        dicoBTN["testBTN"] = ButtonQuit("Quit", "Quit", -300f, -300f, 150f, 75f);
        Instancier("testCanv", dicoBTN);
    }
    
}
