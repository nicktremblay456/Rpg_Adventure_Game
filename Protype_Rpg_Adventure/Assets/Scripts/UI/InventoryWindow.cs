using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Color m_HeaderTextColor;

    private Button m_ButtonClose;

    public void CreateInventory()
    {
        // rename game object
        gameObject.name = "Window (Inventory)";
        // set anchor, position and size of the Inventory
        RectTransform inventoryRectTransform = GetComponent<RectTransform>();
        inventoryRectTransform.anchorMin = new Vector2(0, 1);
        inventoryRectTransform.anchorMax = new Vector2(0, 1);
        inventoryRectTransform.pivot = new Vector2(0, 1);
        inventoryRectTransform.anchoredPosition = new Vector2(3014, -1086);
        inventoryRectTransform.sizeDelta = new Vector2(734, 1010);
        // set background visual
        Image inventoryBackgroundImage = gameObject.AddComponent<Image>();
        inventoryBackgroundImage.type = Image.Type.Sliced;
        inventoryBackgroundImage.sprite = Resources.Load<Sprite>("UI/Window/Window_Background");
        // add canvas group component
        gameObject.AddComponent<CanvasGroup>();

        // set Header
        GameObject header = new GameObject("Header");
        header.transform.SetParent(transform);
        // set Header background visual
        Image headerImg = header.AddComponent<Image>();
        headerImg.sprite = Resources.Load<Sprite>("UI/Window/Window_Header_Background");
        // set Header anchor, position and size
        RectTransform headerRectTransform = header.GetComponent<RectTransform>();
        headerRectTransform.anchorMin = new Vector2(0, 1);
        headerRectTransform.anchorMax = new Vector2(1, 1);
        headerRectTransform.pivot = new Vector2(0, 1);
        headerRectTransform.anchoredPosition = new Vector2(32, -22);
        headerRectTransform.sizeDelta = new Vector2(-64, 92);

        // set HeaderText
        GameObject headerText = new GameObject("Header Text");
        headerText.transform.SetParent(header.transform);
        // set Header Text component
        Text text = headerText.AddComponent<Text>();
        text.text = "INVENTORY";
        text.font = Resources.Load<Font>("Fonts/MKX_Title");
        text.fontSize = 44;
        text.alignment = TextAnchor.UpperCenter;
        text.color = m_HeaderTextColor;
        // set Header Text anchor, position and size
        RectTransform headerTextRectTransform = headerText.GetComponent<RectTransform>();
        headerTextRectTransform.anchorMin = new Vector2(0, 1);
        headerTextRectTransform.anchorMax = new Vector2(1, 1);
        headerTextRectTransform.pivot = new Vector2(0, 1);
        headerTextRectTransform.anchoredPosition = new Vector2(32, -22);
        headerTextRectTransform.sizeDelta = new Vector2(-64, 48);
        // set Header Text Content Size Filter component
        ContentSizeFitter contentSizeFilter = headerText.AddComponent<ContentSizeFitter>();
        contentSizeFilter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
        contentSizeFilter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        SetButtonClose();
        SetContent();
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

    private void SetContent()
    {
        // set Content
        GameObject content = new GameObject("Content");
        content.transform.SetParent(transform);
        content.AddComponent<RectTransform>();
        // set Content anchor, position and size
        RectTransform contentRectTransform = content.GetComponent<RectTransform>();
        contentRectTransform.anchorMin = new Vector2(0, 0);
        contentRectTransform.anchorMax = new Vector2(1, 1);
        contentRectTransform.pivot = new Vector2(0, 1);
        contentRectTransform.anchoredPosition = new Vector2(0, 0);
        contentRectTransform.sizeDelta = new Vector2(0, 0);

        // set Slots
        GameObject slotsObj = new GameObject("Slots");
        slotsObj.transform.SetParent(content.transform);
        slotsObj.AddComponent<RectTransform>();
        // set Slots anchor, position, size
        RectTransform slotsRectTransform = slotsObj.GetComponent<RectTransform>();
        slotsRectTransform.anchorMin = new Vector2(0, 0);
        slotsRectTransform.anchorMax = new Vector2(1, 1);
        slotsRectTransform.pivot = new Vector2(0, 1);
        slotsRectTransform.anchoredPosition = new Vector2(40, -134);
        slotsRectTransform.sizeDelta = new Vector2(-80, 108);
        // set Slots Grid Layout Group
        GridLayoutGroup slotsGridLayoutGroup = slotsObj.AddComponent<GridLayoutGroup>();
        slotsGridLayoutGroup.cellSize = new Vector2(104, 104);
        slotsGridLayoutGroup.spacing = new Vector2(6, 6);
        slotsGridLayoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;
        slotsGridLayoutGroup.startAxis = GridLayoutGroup.Axis.Horizontal;
        slotsGridLayoutGroup.childAlignment = TextAnchor.UpperLeft;
        slotsGridLayoutGroup.constraint = GridLayoutGroup.Constraint.Flexible;

        // create slots
        for (int i = 0; i < 42 ; i++)
        {
            CreateSlot(slotsObj.transform, i);
        }
    }

    private void CreateSlot(Transform parent, int index)
    {
        // set Slot
        GameObject slot = new GameObject($"Slot({index + 1})");
        slot.transform.SetParent(parent);
        // set Slot visual
        Image slotImg = slot.AddComponent<Image>();
        slotImg.sprite = Resources.Load<Sprite>("UI/Inventory/Inventory_Slot_Background");

        // set Slot Hover Overlay
        GameObject hoverOverlay = new GameObject("Hover Overlay");
        hoverOverlay.transform.SetParent(slot.transform);
        hoverOverlay.AddComponent<RectTransform>();
        // set Slot Hover Overlay visual
        Image hoverOverlayImg = hoverOverlay.AddComponent<Image>();
        hoverOverlayImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Hover");
        // set Slot Hover Overlay anchor, position and size
        RectTransform hoverOverlayRectTransform = hoverOverlay.GetComponent<RectTransform>();
        hoverOverlayRectTransform.anchorMin = new Vector2(0, 0);
        hoverOverlayRectTransform.anchorMax = new Vector2(1, 1);
        hoverOverlayRectTransform.pivot = new Vector2(0, 1);
        hoverOverlayRectTransform.anchoredPosition = new Vector2(8, -8);
        hoverOverlayRectTransform.sizeDelta = new Vector2(-16, -16);

        // set Slot Press Overlay
        GameObject pressOverlay = new GameObject("Press Overlay");
        pressOverlay.transform.SetParent(slot.transform);
        pressOverlay.AddComponent<RectTransform>();
        // set Slot Press Overlay visual
        Image pressOverlayImg = pressOverlay.AddComponent<Image>();
        pressOverlayImg.sprite = Resources.Load<Sprite>("UI/ActionBar/Slots/ActionBar_Slot_Press");
        // set Slot Press Overlay anchor, position and size
        RectTransform pressOverlayRectTransform = pressOverlay.GetComponent<RectTransform>();
        pressOverlayRectTransform.anchorMin = new Vector2(0, 0);
        pressOverlayRectTransform.anchorMax = new Vector2(1, 1);
        pressOverlayRectTransform.pivot = new Vector2(0, 1);
        pressOverlayRectTransform.anchoredPosition = new Vector2(8, -8);
        pressOverlayRectTransform.sizeDelta = new Vector2(-16 , -16);
    }
}