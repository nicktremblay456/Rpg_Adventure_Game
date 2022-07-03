using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBookWindow : MonoBehaviour
{
    [SerializeField] private Color m_HeaderTextColor;

    private Button m_ButtonClose;

    public void CreateSpellBookWindow()
    {
        // rename game object
        gameObject.name = "Window (Spell Book)";
        // set anchor, position and size of the Character Window
        RectTransform windowRectTransform = GetComponent<RectTransform>();
        windowRectTransform.anchorMin = new Vector2(0, 1);
        windowRectTransform.anchorMax = new Vector2(0, 1);
        windowRectTransform.pivot = new Vector2(0, 1);
        windowRectTransform.anchoredPosition = new Vector2(1442, -276);
        windowRectTransform.sizeDelta = new Vector2(1094, 1384);
        // set background visual
        Image windowBackgroundImg = gameObject.AddComponent<Image>();
        windowBackgroundImg.type = Image.Type.Sliced;
        windowBackgroundImg.sprite = Resources.Load<Sprite>("UI/Window/Window_Background");
        // add canvas group component
        gameObject.AddComponent<CanvasGroup>();

        // set Header
        GameObject header = new GameObject("Header");
        header.transform.SetParent(transform);
        // set Header background
        Image headerBackgroundImg = header.AddComponent<Image>();
        headerBackgroundImg.sprite = Resources.Load<Sprite>("UI/Window/Window_Header_Background");
        //set Header anchore, position and size
        RectTransform headerRectTransform = header.GetComponent<RectTransform>();
        headerRectTransform.anchorMin = new Vector2(0, 1);
        headerRectTransform.anchorMax = new Vector2(1, 1);
        headerRectTransform.pivot = new Vector2(0, 1);
        headerRectTransform.anchoredPosition = new Vector2(32, -22);
        headerRectTransform.sizeDelta = new Vector2(32, 118);

        // set HeaderText
        GameObject headerText = new GameObject("Header Text");
        headerText.transform.SetParent(header.transform);
        // set Header Text component
        Text text = headerText.AddComponent<Text>();
        text.text = "SPELL BOOK";
        text.font = Resources.Load<Font>("Fonts/MKX_Title");
        text.fontSize = 52;
        text.alignment = TextAnchor.UpperCenter;
        text.color = m_HeaderTextColor;
        // set Header Text anchor, position and size
        RectTransform headerTextRectTransform = headerText.GetComponent<RectTransform>();
        headerTextRectTransform.anchorMin = new Vector2(0, 1);
        headerTextRectTransform.anchorMax = new Vector2(1, 1);
        headerTextRectTransform.pivot = new Vector2(0, 1);
        headerTextRectTransform.anchoredPosition = new Vector2(32, -30);
        headerTextRectTransform.sizeDelta = new Vector2(-64, 56);
        // set Header Text Content Size Filter component
        ContentSizeFitter contentSizeFilter = headerText.AddComponent<ContentSizeFitter>();
        contentSizeFilter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
        contentSizeFilter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        SetButtonClose();
    }

    private void SetButtonClose()
    {
        // set Button Close
        GameObject buttonClose = new GameObject("Button (Close)");
        buttonClose.transform.SetParent(transform);
        // set Button Close visual
        Image buttonCloseImg = buttonClose.AddComponent<Image>();
        buttonCloseImg.sprite = Resources.Load<Sprite>("UI/Window/Window_CloseBtn_Background");
        // set Button Close anchor, position and size
        RectTransform btnCloseRectTransform = buttonClose.GetComponent<RectTransform>();
        btnCloseRectTransform.anchorMin = new Vector2(1, 1);
        btnCloseRectTransform.anchorMax = new Vector2(1, 1);
        btnCloseRectTransform.pivot = new Vector2(1, 1);
        btnCloseRectTransform.anchoredPosition = new Vector2(-44, -44);
        btnCloseRectTransform.sizeDelta = new Vector2(46, 46);
        // set Button Close Overlay
        GameObject hoverOverlay = new GameObject("Hover Overlay");
        hoverOverlay.transform.SetParent(buttonClose.transform);
        // set Button Close Hover Overlay visual
        Image overlayImg = hoverOverlay.AddComponent<Image>();
        overlayImg.sprite = Resources.Load<Sprite>("UI/Window/Window_CloseBtn_Hover");
        // set Button Close Hover Overlay anchor, position and size
        RectTransform overlayRectTransform = hoverOverlay.GetComponent<RectTransform>();
        overlayRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        overlayRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        overlayRectTransform.pivot = new Vector2(0.5f, 0.5f);
        overlayRectTransform.anchoredPosition = new Vector2(0, 0);
        overlayRectTransform.sizeDelta = new Vector2(36, 36);
        // set Button Close Press Overlay
        GameObject pressOverlay = new GameObject("Press Overlay");
        pressOverlay.transform.SetParent(buttonClose.transform);
        // set Button Close Press Overlay visual
        Image pressOverlayImg = pressOverlay.AddComponent<Image>();
        pressOverlayImg.sprite = Resources.Load<Sprite>("UI/Window/Window_CloseBtn_Press");
        // set Button Close Press Overlay anchor, position and size
        RectTransform pressRectTransform = pressOverlay.GetComponent<RectTransform>();
        pressRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        pressRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        pressRectTransform.pivot = new Vector2(0.5f, 0.5f);
        pressRectTransform.anchoredPosition = new Vector2(0, 0);
        pressRectTransform.sizeDelta = new Vector2(36, 36);

        // set Button component
        m_ButtonClose = buttonClose.AddComponent<Button>();
        // TO DO - ADD EVENT TO CLOSE WINDOW
    }
}