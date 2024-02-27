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
        button.AddComponent<Image>().sprite = Resources.Load<Sprite>("Button/Blue gradient");
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
    /// <param name="heightOption"></param>
    /// <returns></returns>
    protected static GameObject NewDropdown<T>(string id, string text, float posX, float posY, float width, float height, float heightOption = 0) where T : MonoBehaviour, IDropdownadble
    {
        
        if (heightOption == 0)
        {
            heightOption = height / 3f;
        }
        GameObject ddw = NewUiElementBase("DDW_" + id, posX, posY, width, height);
        GameObject label = TextComponentCreator(text, ddw);
        label.GetComponent<TextMeshProUGUI>().fontSize = height / 3f;
        label.GetComponent<RectTransform>().anchoredPosition = new Vector2(-width/12f, 0);
        ddw.AddComponent<TMP_Dropdown>().targetGraphic = ddw.GetComponent<Image>();
        ddw.AddComponent<T>().SetDropdown(ddw.GetComponent<TMP_Dropdown>());                    // TODO : a passer en parametre de la methode, pour pouvoir changer le script associe
        
        GameObject template = NewUiElementBase("Template", 0, 0, 50, 50);
        template.transform.SetParent(ddw.transform);
        
        template.AddComponent<ScrollRect>();
        template.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        template.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0);
        template.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
        template.GetComponent<RectTransform>().offsetMax = new Vector2(0, height*3);
        template.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        template.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        
        GameObject viewport = NewUiElementBase("Viewport", 0, 0, 0, 0);
        viewport.transform.SetParent(ddw.transform);
        viewport.GetComponent<Transform>().SetParent(template.GetComponent<Transform>());
        viewport.AddComponent<Mask>();
        viewport.GetComponent<Mask>().showMaskGraphic = false;
        viewport.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        viewport.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        viewport.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        viewport.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        viewport.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        viewport.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
        viewport.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Blue gradient");
        viewport.GetComponent<RectTransform>().right = new Vector3(0, 0, 0);
        //viewport.AddComponent<Image>().sprite = Resources.GetBuiltinResource<Sprite>("UI/Skin/UIMask.psd");
        
        GameObject arrow = NewUiElementBase("Arrow", 0, 0, width/4, width/4);
        
        arrow.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Green gradient");
        arrow.GetComponent<Image>().type = Image.Type.Simple;
        arrow.transform.SetParent(ddw.transform);
        arrow.GetComponent<RectTransform>().transform.localPosition = new Vector3(-width/8f, 0);
        arrow.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
        arrow.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
        
        ddw.GetComponent<TMP_Dropdown>().template = template.GetComponent<RectTransform>();
        ddw.GetComponent<TMP_Dropdown>().captionText = ddw.GetComponentInChildren<TextMeshProUGUI>();
        
        GameObject scrollbar = NewUiElementBase("Scrollbar", 0, 0, 20, 50);
        scrollbar.AddComponent<Scrollbar>();
        scrollbar.transform.SetParent(template.transform);

        GameObject content = new GameObject("Content");
        content.AddComponent<RectTransform>();
        content.transform.SetParent(viewport.transform);
        content.transform.localPosition = new Vector3(0, 0, 0);
        content.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        content.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        content.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
        content.GetComponent<RectTransform>().offsetMax = new Vector2(0, heightOption);
        content.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        content.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        
        GameObject item = new GameObject("Item");
        item.transform.SetParent(content.transform);
        item.AddComponent<RectTransform>().anchorMin = new Vector2(0f, 0.5f);
        item.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 0.5f);
        item.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        item.GetComponent<RectTransform>().offsetMax = new Vector2(0, heightOption);
        item.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        
        GameObject itemBackground = NewUiElementBase("Item Background", 0, 0, 20, heightOption);
        itemBackground.transform.SetParent(item.transform);
        itemBackground.GetComponent<Image>().sprite = null;
        itemBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        itemBackground.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        itemBackground.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        itemBackground.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        itemBackground.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        
        GameObject itemCheckmark = NewUiElementBase("Item Checkmark", 0, 0, 20, heightOption);
        itemCheckmark.transform.SetParent(item.transform);
        
        itemCheckmark.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
        itemCheckmark.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
        itemCheckmark.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        itemCheckmark.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Orange gradient");
        itemCheckmark.GetComponent<Image>().type = Image.Type.Simple;
        itemCheckmark.GetComponent<RectTransform>().offsetMax = new Vector2(width/10f, width/5f);
        itemCheckmark.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        itemCheckmark.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(width/10f, 0, 0);
        
        GameObject slidingArea = new GameObject("Sliding Area");
        slidingArea.AddComponent<RectTransform>();
        slidingArea.transform.SetParent(scrollbar.transform);
        slidingArea.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        slidingArea.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        slidingArea.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        slidingArea.GetComponent<RectTransform>().offsetMin = new Vector2(20, 20);
        slidingArea.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        
        GameObject handle = NewUiElementBase("Handle", 0, 0, 20, height);
        handle.transform.SetParent(slidingArea.transform);
        handle.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        handle.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.2f);
        handle.GetComponent<RectTransform>().offsetMax = new Vector2(20, 20);
        handle.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        handle.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        
        
        scrollbar.GetComponent<Scrollbar>().handleRect = handle.GetComponent<RectTransform>();
        scrollbar.GetComponent<Scrollbar>().targetGraphic = handle.GetComponent<Image>();
        scrollbar.GetComponent<Scrollbar>().direction = Scrollbar.Direction.BottomToTop;
        scrollbar.GetComponent<Scrollbar>().value = 1;
        scrollbar.GetComponent<Scrollbar>().size = 1f;
        scrollbar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Orange gradient");
        scrollbar.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0);
        scrollbar.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        scrollbar.GetComponent<RectTransform>().pivot = new Vector2(1f, 1f);
        scrollbar.GetComponent<RectTransform>().offsetMax = new Vector2(20, 0);
        scrollbar.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        scrollbar.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        

        GameObject itemLabel = new GameObject("Item Label");
        itemLabel.AddComponent<RectTransform>();
        itemLabel.AddComponent<CanvasRenderer>();
        itemLabel.AddComponent<TextMeshProUGUI>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
        itemLabel.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        itemLabel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        itemLabel.transform.SetParent(item.transform);
        itemLabel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        itemLabel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        itemLabel.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        itemLabel.GetComponent<TextMeshProUGUI>().fontSize = height / 4f; 
        itemLabel.GetComponent<TextMeshProUGUI>().verticalAlignment = VerticalAlignmentOptions.Middle;
        itemLabel.GetComponent<TextMeshProUGUI>().horizontalAlignment = HorizontalAlignmentOptions.Center;
        
        template.GetComponent<ScrollRect>().content = content.GetComponent<RectTransform>();
        template.GetComponent<ScrollRect>().horizontal = false;
        template.GetComponent<ScrollRect>().vertical = true;
        template.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Clamped;
        template.GetComponent<ScrollRect>().viewport = viewport.GetComponent<RectTransform>();
        template.GetComponent<ScrollRect>().verticalScrollbar = scrollbar.GetComponent<Scrollbar>();
        template.GetComponent<ScrollRect>().verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
        template.GetComponent<ScrollRect>().verticalScrollbarSpacing = -3;
        
        item.AddComponent<Toggle>().targetGraphic = itemBackground.GetComponent<Image>();
        item.GetComponent<Toggle>().graphic = itemCheckmark.GetComponent<Image>();
        item.GetComponent<Toggle>().isOn = true;
        template.SetActive(false);
        ddw.GetComponent<TMP_Dropdown>().itemText = itemLabel.GetComponent<TextMeshProUGUI>();
        return ddw;
    }
    
    /// <summary>
    /// <value>Working as expected</value>
    /// Instantiates a new canvas and add components to render 
    /// </summary>
    /// <param name="canvasName"></param>
    /// <param name="dicoUiComponents"></param>
    protected static GameObject Instancier(string canvasName, Dictionary<string, GameObject> dicoUiComponents)
    {
        /* Cree un nouveau canvas et y ajoute les objects du dicoUiComponents */
        
        GameObject canvas = new GameObject(canvasName, new Type[] { });
        canvas.AddComponent<RectTransform>();
        canvas.transform.position = new Vector3(0, 0);
        canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);
        canvas.AddComponent<GraphicRaycaster>();
        
        foreach (var cle in dicoUiComponents.Keys)
        {
            GameObject temp = dicoUiComponents[cle];
            temp.transform.SetParent(canvas.transform, false);
        }

        return canvas;
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
    /// <value>WIP</value>
    /// Protected method to create a button create a save.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="text"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    protected static GameObject ButtonSave(string id,string text, float posX, float posY, float width, float height)
    {
        return NewButton(id, text, posX, posY,width, height, () => SaveData.SaveGame()); //TODO : ON VERRA SI ON SE FAIT CHIER AVEC LES LANGUES
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
