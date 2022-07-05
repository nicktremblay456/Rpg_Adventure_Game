using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UI
{
    public static void SetRectTransform(GameObject obj, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot, Vector2 anchoredPosition, Vector2 sizeDelta)
    {
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            rectTransform = obj.AddComponent<RectTransform>();
        }
        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
        rectTransform.pivot = pivot;
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = sizeDelta;
    }

    public static void CreateHeader(Transform parent, string title, Vector2 headerObjSizeDelta, Vector2 headerTextSizeDelta, Color color)
    {
        // set Header
        GameObject header = new GameObject("Header");
        header.transform.SetParent(parent);
        // set Header background visual
        Image headerImg = header.AddComponent<Image>();
        headerImg.sprite = Resources.Load<Sprite>("UI/Window/Window_Header_Background");
        // set Header anchor, position and size
        SetRectTransform(header, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(32, -22), headerObjSizeDelta);

        // set HeaderText
        GameObject headerText = new GameObject("Header Text");
        headerText.transform.SetParent(header.transform);
        // set Header Text component
        Text text = headerText.AddComponent<Text>();
        text.text = title;
        text.font = Resources.Load<Font>("Fonts/MKX_Title");
        text.fontSize = 44;
        text.alignment = TextAnchor.UpperCenter;
        text.color = color;
        // set Header Text anchor, position and size
        SetRectTransform(headerText, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(32, -22), headerTextSizeDelta);
        // set Header Text Content Size Filter component
        ContentSizeFitter contentSizeFilter = headerText.AddComponent<ContentSizeFitter>();
        contentSizeFilter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
        contentSizeFilter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
    }

    public static void CreateButtonClose(Transform parent, System.Action buttonEvent = null)
    {
        // set Button Close
        GameObject buttonClose = new GameObject("Button (Close)");
        buttonClose.transform.SetParent(parent);
        // set Button Close visual
        Image buttonCloseImg = buttonClose.AddComponent<Image>();
        buttonCloseImg.sprite = Resources.Load<Sprite>("UI/Window/Window_CloseBtn_Background");
        // set Button Close anchor, position and size
        SetRectTransform(buttonClose, new Vector2(1, 1), new Vector2(1, 1), new Vector2(1, 1), new Vector2(-44, -44), new Vector2(46, 46));
        // set Button Close Overlay
        GameObject hoverOverlay = new GameObject("Hover Overlay");
        hoverOverlay.transform.SetParent(buttonClose.transform);
        // set Button Close Hover Overlay visual
        Image overlayImg = hoverOverlay.AddComponent<Image>();
        overlayImg.sprite = Resources.Load<Sprite>("UI/Window/Window_CloseBtn_Hover");
        // set Button Close Hover Overlay anchor, position and size
        SetRectTransform(hoverOverlay, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0, 0), new Vector2(36, 36));
        // set Button Close Press Overlay
        GameObject pressOverlay = new GameObject("Press Overlay");
        pressOverlay.transform.SetParent(buttonClose.transform);
        // set Button Close Press Overlay visual
        Image pressOverlayImg = pressOverlay.AddComponent<Image>();
        pressOverlayImg.sprite = Resources.Load<Sprite>("UI/Window/Window_CloseBtn_Press");
        // set Button Close Press Overlay anchor, position and size
        SetRectTransform(pressOverlay, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0, 0), new Vector2(36, 36));

        // set Button component
        Button button = buttonClose.AddComponent<Button>();
        if (buttonEvent != null)
        {
            button.onClick.AddListener(buttonEvent.Invoke);
        }
    }

    public static void CreateSlotOverlay(Transform parent)
    {
        // set Slot Hover Overlay
        GameObject hoverOverlay = new GameObject("Hover Overlay");
        hoverOverlay.transform.SetParent(parent);
        hoverOverlay.AddComponent<RectTransform>();
        // set Slot Hover Overlay visual
        Image hoverOverlayImg = hoverOverlay.AddComponent<Image>();
        hoverOverlayImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Hover");
        // set Slot Hover Overlay anchor, position and size
        SetRectTransform(hoverOverlay, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(8, -8), new Vector2(-16, -16));

        // set Slot Press Overlay
        GameObject pressOverlay = new GameObject("Press Overlay");
        pressOverlay.transform.SetParent(parent);
        pressOverlay.AddComponent<RectTransform>();
        // set Slot Press Overlay visual
        Image pressOverlayImg = pressOverlay.AddComponent<Image>();
        pressOverlayImg.sprite = Resources.Load<Sprite>("UI/ActionBar/Slots/ActionBar_Slot_Press");
        // set Slot Press Overlay anchor, position and size
        SetRectTransform(pressOverlay, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(8, -8), new Vector2(-16, -16));
    }

    public static void AddTextComponent()
    {
        
    }
}