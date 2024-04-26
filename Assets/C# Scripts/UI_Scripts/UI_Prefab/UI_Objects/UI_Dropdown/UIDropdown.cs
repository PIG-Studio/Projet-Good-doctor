using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UIBase;
using Interfaces;
using Interfaces.UI_Input_management;

namespace UI_Scripts.UI_Prefab.UI_Objects.UI_Dropdown
{
    public class UIDropdown : IUiCreate
    {
        /// <summary>
        /// <value>WIP</value>
        /// temporarily on protected for testing purposes
        /// uses base methods to instantiate a new Dropdown
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="heightOption"></param>
        /// <returns></returns>
        public static GameObject Create<T>(string id, string text, float posX, float posY, float width, float height,
            float heightOption = 0) where T : MonoBehaviour, IDropdownable
        {

            if (heightOption == 0)
            {
                heightOption = height / 3f;
            }

            GameObject ddw = UIBaseObject.Create("DDW_" + id, posX, posY, width, height);
            GameObject label = UITextComponent.Create(text);
            label.transform.SetParent(ddw.transform);
            label.GetComponent<TextMeshProUGUI>().fontSize = height / 3f;

            label.GetComponent<RectTransform>().sizeDelta = new Vector2(-width / 12f, 0);
            label.GetComponent<RectTransform>().anchoredPosition = new Vector2(-width / 12f / 2f, 0);

            ddw.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/prettyButton/Blue-Rect-Default");
            ddw.AddComponent<TMP_Dropdown>().targetGraphic = ddw.GetComponent<Image>();
            ddw.AddComponent<T>()
                .SetDropdown(ddw
                    .GetComponent<
                        TMP_Dropdown>()); // TODO : a passer en parametre de la methode, pour pouvoir changer le script associe

            GameObject template = UIBaseObject.Create("Template", 0, 0, 50, 50);
            template.transform.SetParent(ddw.transform);

            template.AddComponent<ScrollRect>();
            template.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            template.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0);
            template.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
            template.GetComponent<RectTransform>().offsetMax = new Vector2(0, height * 3);
            template.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            template.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);

            GameObject viewport = UIBaseObject.Create("Viewport", 0, 0, 0, 0);
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

            GameObject arrow = UIBaseObject.Create("Arrow", 0, 0, width / 4, width / 4);

            arrow.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Green gradient");
            arrow.GetComponent<Image>().type = Image.Type.Simple;
            arrow.transform.SetParent(ddw.transform);
            arrow.GetComponent<RectTransform>().transform.localPosition = new Vector3(-width / 8f, 0);
            arrow.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
            arrow.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);

            ddw.GetComponent<TMP_Dropdown>().template = template.GetComponent<RectTransform>();
            ddw.GetComponent<TMP_Dropdown>().captionText = ddw.GetComponentInChildren<TextMeshProUGUI>();

            GameObject scrollbar = UIBaseObject.Create("Scrollbar", 0, 0, 20, 50);
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

            GameObject itemBackground = UIBaseObject.Create("Item Background", 0, 0, 20, heightOption);
            itemBackground.transform.SetParent(item.transform);
            itemBackground.GetComponent<Image>().sprite = null;
            itemBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            itemBackground.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            itemBackground.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            itemBackground.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            itemBackground.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);

            GameObject itemCheckmark = UIBaseObject.Create("Item Checkmark", 0, 0, 20, heightOption);
            itemCheckmark.transform.SetParent(item.transform);

            itemCheckmark.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
            itemCheckmark.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
            itemCheckmark.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            itemCheckmark.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Orange gradient");
            itemCheckmark.GetComponent<Image>().type = Image.Type.Simple;
            itemCheckmark.GetComponent<RectTransform>().offsetMax = new Vector2(width / 10f, width / 5f);
            itemCheckmark.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            itemCheckmark.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(width / 10f, 0, 0);

            GameObject slidingArea = new GameObject("Sliding Area");
            slidingArea.AddComponent<RectTransform>();
            slidingArea.transform.SetParent(scrollbar.transform);
            slidingArea.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            slidingArea.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            slidingArea.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            slidingArea.GetComponent<RectTransform>().offsetMin = new Vector2(20, 20);
            slidingArea.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);

            GameObject handle = UIBaseObject.Create("Handle", 0, 0, 20, height);
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
            template.GetComponent<ScrollRect>().verticalScrollbarVisibility =
                ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
            template.GetComponent<ScrollRect>().verticalScrollbarSpacing = -3;

            item.AddComponent<Toggle>().targetGraphic = itemBackground.GetComponent<Image>();
            item.GetComponent<Toggle>().graphic = itemCheckmark.GetComponent<Image>();
            item.GetComponent<Toggle>().isOn = true;
            template.SetActive(false);
            ddw.GetComponent<TMP_Dropdown>().itemText = itemLabel.GetComponent<TextMeshProUGUI>();
            return ddw;
        }
    }
}