using TMPro;
using UIBase;
using UnityEngine;
using UnityEngine.UI;
using static CustomScenes.Manager;

namespace UIPrefab.UIObjects
{
    public class UIInputField : IUI_Create
    {
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
        public static GameObject Create(string id, float posX, float posY, float width, float height)
        {
            GameObject field = UIBaseObject.Create("INSTR_" + id, posX, posY, width, height);

            GameObject textArea = new GameObject("Text Area");
            textArea.AddComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            textArea.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            textArea.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
            textArea.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
            textArea.AddComponent<RectMask2D>();
            textArea.transform.SetParent(field.transform, false);

            GameObject placeholder = UITextComponent.Create("Enter text...",  "Placeholder");
            GameObject textCompo = UITextComponent.Create("");
            placeholder.transform.SetParent(textArea.transform, false);
            textCompo.transform.SetParent(textArea.transform, false);

            field.AddComponent<TMP_InputField>().targetGraphic = field.GetComponent<Image>();
            field.GetComponent<TMP_InputField>().textViewport = textArea.GetComponent<RectTransform>();
            field.GetComponent<TMP_InputField>().textComponent = textCompo.GetComponent<TextMeshProUGUI>();
            field.GetComponent<TMP_InputField>().placeholder = placeholder.GetComponent<TextMeshProUGUI>();

            field.GetComponent<TMP_InputField>().onSelect.AddListener((string input) => ChangeSelect());
            field.GetComponent<TMP_InputField>().onValueChanged.AddListener((string input) => SaveData.SetSaveName(input));
            field.GetComponent<TMP_InputField>().onDeselect
                .AddListener((string input) => ChangeSelect());

            return field;
        }
}
}   