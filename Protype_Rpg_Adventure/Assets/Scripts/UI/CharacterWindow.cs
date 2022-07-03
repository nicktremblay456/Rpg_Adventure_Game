using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ESlotsPart
{
    Left,
    Right,
    Bottom,
}

public enum ELeftSlots
{
    Head,
    Necklace,
    Shoulders,
    Chest,
    Shirt,
    Bracers,

    Count
}

public enum ERightSlots
{
    Gloves,
    Belt,
    Pants,
    Boots,
    Finger,
    Trinket,

    Count
}

public enum EBottomSlots
{
    Main,
    Off,
    Count
}

public class CharacterWindow : MonoBehaviour
{
    [SerializeField] private Color m_HeaderTextColor;

    private Button m_ButtonClose;

    public void CreateCharacterWindow()
    {
        // rename game object
        gameObject.name = "Window (Character)";
        // set anchor, position and size of the Character Window
        RectTransform windowRectTransform = GetComponent<RectTransform>();
        windowRectTransform.anchorMin = new Vector2(0, 1);
        windowRectTransform.anchorMax = new Vector2(0, 1);
        windowRectTransform.pivot = new Vector2(0, 1);
        windowRectTransform.anchoredPosition = new Vector2(28, -276);
        windowRectTransform.sizeDelta = new Vector2(1414, 1528);
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

        // set Header Text
        // set HeaderText
        GameObject headerText = new GameObject("Header Text");
        headerText.transform.SetParent(header.transform);
        // set Header Text component
        Text text = headerText.AddComponent<Text>();
        text.text = "CHARACTER";
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
        // set Content achor, position and size
        RectTransform contentRectTransform = content.GetComponent<RectTransform>();
        contentRectTransform.anchorMin = new Vector2(0, 0);
        contentRectTransform.anchorMax = new Vector2(1, 1);
        contentRectTransform.pivot = new Vector2(0, 1);
        contentRectTransform.anchoredPosition = new Vector2(0, 0);
        contentRectTransform.sizeDelta = new Vector2(0, 0);

        // set Character View
        GameObject charView = new GameObject("Character View");
        charView.transform.SetParent(content.transform);
        charView.AddComponent<RectTransform>();
        // set Character View anchor, position and size
        RectTransform charViewRectTransform = charView.GetComponent<RectTransform>();
        charViewRectTransform.anchorMin = new Vector2(0, 1);
        charViewRectTransform.anchorMax = new Vector2(0, 1);
        charViewRectTransform.pivot = new Vector2(0, 1);
        charViewRectTransform.anchoredPosition = new Vector2(190, -400);
        charViewRectTransform.sizeDelta = new Vector2(514, 926);

        // set Example
        GameObject ex = new GameObject("Example");
        ex.transform.SetParent(charView.transform);
        ex.AddComponent<RectTransform>();
        // set Example visual
        Image exImg = ex.AddComponent<Image>();
        exImg.sprite = Resources.Load<Sprite>("UI/Character_Window/CharacterWindow_Character_Example");
        // set Example anchor, position and size
        RectTransform exRectTransform = ex.GetComponent<RectTransform>();
        exRectTransform.anchorMin = new Vector2(0, 1);
        exRectTransform.anchorMax = new Vector2(0, 1);
        exRectTransform.pivot = new Vector2(0, 1);
        exRectTransform.anchoredPosition = new Vector2(74, -40);
        exRectTransform.sizeDelta = new Vector2(352, 794);

        // set Equip Slots
        GameObject equipSlots = new GameObject("Equip Slots");
        equipSlots.transform.SetParent(content.transform);
        equipSlots.AddComponent<RectTransform>();
        // set Equip Slots anchore, position and size
        RectTransform equipSlotsRectTransform = equipSlots.GetComponent<RectTransform>();
        equipSlotsRectTransform.anchorMin = new Vector2(0, 0);
        equipSlotsRectTransform.anchorMax = new Vector2(1, 1);
        equipSlotsRectTransform.pivot = new Vector2(0, 1);
        equipSlotsRectTransform.anchoredPosition = new Vector2(0, 0);
        equipSlotsRectTransform.sizeDelta = new Vector2(0, 0);

        // set Left Slots
        GameObject leftSlots = CreateLayoutGroup("Slots (Left)", equipSlots.transform, new Vector2(84, -488), new Vector2(104, 804), ESlotsPart.Left);
        for (int i = 0; i < (int)ELeftSlots.Count; i++)
        {
            CreateSlots(leftSlots.transform, i, ESlotsPart.Left);
        }
        // set Bottom Slots
        GameObject bottomSlots = CreateLayoutGroup("Slots (Bottom)", equipSlots.transform, new Vector2(326, -1326), new Vector2(244, 104), ESlotsPart.Bottom);
        for (int i = 0; i < (int)EBottomSlots.Count; i++)
        {
            CreateSlots(bottomSlots.transform, i, ESlotsPart.Bottom);
        }
        // set Right Slots
        GameObject rightSlots = CreateLayoutGroup("Slots (Left)", equipSlots.transform, new Vector2(706, -488), new Vector2(104, 804), ESlotsPart.Right);
        for (int i = 0; i < (int)ERightSlots.Count; i++)
        {
            CreateSlots(rightSlots.transform, i, ESlotsPart.Right);
        }

        // set Separator
        GameObject separator = new GameObject("Separator");
        separator.transform.SetParent(content.transform);
        //separator.AddComponent<RectTransform>();
        // set Separator visual
        Image separatorImg = separator.AddComponent<Image>();
        separatorImg.type = Image.Type.Sliced;
        separatorImg.sprite = Resources.Load<Sprite>("UI/Window/Window_Separator_Vertical");
        // set Separator anchor, position, size
        RectTransform separatorRectTransform = separator.GetComponent<RectTransform>();
        separatorRectTransform.anchorMin = new Vector2(0, 0);
        separatorRectTransform.anchorMax = new Vector2(0, 1);
        separatorRectTransform.pivot = new Vector2(0, 1);
        separatorRectTransform.anchoredPosition = new Vector2(862, 256 - (256*2));
        separatorRectTransform.sizeDelta = new Vector2(14, 54 - 364);

        // set Tab Content
        GameObject tabContent = new GameObject("Tab Contents");
        tabContent.transform.SetParent(transform);
        tabContent.AddComponent<RectTransform>();
        // set Content anchor, position ans size
        RectTransform tabContentRectTransform = content.GetComponent<RectTransform>();
        tabContentRectTransform.anchorMin = Vector2.zero;
        tabContentRectTransform.anchorMax = Vector2.one;
        tabContentRectTransform.pivot = new Vector2(0, 1);
        tabContentRectTransform.anchoredPosition = Vector2.zero;
        tabContentRectTransform.sizeDelta = Vector2.zero;
        SetStatisticsTab(tabContent.transform);
    }

    private void SetStatisticsTab(Transform parent)
    {
        // set Statisctics Tab
        GameObject statTab = new GameObject("Tab (Statistics)");
        statTab.transform.SetParent(parent);
        statTab.AddComponent<RectTransform>();
        // set Statistics Tab anchor, position and size
        RectTransform statTabRectTransform = statTab.GetComponent<RectTransform>();
        statTabRectTransform.anchorMin = Vector2.zero;
        statTabRectTransform.anchorMax = Vector2.one;
        statTabRectTransform.pivot = new Vector2(0, 1);
        statTabRectTransform.anchoredPosition = new Vector2(874, 228);
        statTabRectTransform.sizeDelta = Vector2.zero;

        // set Scroll Bar
        GameObject scrollBar = new GameObject("Scroll Bar (Vertical)");
        scrollBar.transform.SetParent(statTab.transform);
        RectTransform scrollBarRectTransform = scrollBar.AddComponent<RectTransform>();
        // set Scroll Bar component
        Scrollbar verticalScroll = scrollBar.AddComponent<Scrollbar>();
        verticalScroll.navigation = Navigation.defaultNavigation;
        // set Scroll Bar visual
        Image scrollBarImg = scrollBar.AddComponent<Image>();
        scrollBarImg.type = Image.Type.Sliced;
        scrollBarImg.sprite = Resources.Load<Sprite>("UI/ScrollBarsSliders/ScrollBar_Background");
        // set Scroll Bar anchor, position and size
        scrollBarRectTransform.anchorMin = new Vector2(1, 0);
        scrollBarRectTransform.anchorMax = Vector2.one;
        scrollBarRectTransform.pivot = Vector2.zero;
        scrollBarRectTransform.anchoredPosition = new Vector2(-76, 32);
        scrollBarRectTransform.sizeDelta = new Vector2(12, 58);

        // set Sliding Area
        GameObject slidingArea = new GameObject("Sliding Area");
        slidingArea.transform.SetParent(scrollBar.transform);
        // set Sliding Area anchor, position and size
        RectTransform slidingAreaRectTransform = slidingArea.AddComponent<RectTransform>();
        slidingAreaRectTransform.anchorMin = Vector2.zero;
        slidingAreaRectTransform.anchorMax = Vector2.one;
        slidingAreaRectTransform.pivot = Vector2.zero;
        slidingAreaRectTransform.anchoredPosition = Vector2.zero;
        slidingAreaRectTransform.sizeDelta = Vector2.zero;
        // set Handle
        GameObject handle = new GameObject("Handle");
        handle.transform.SetParent(slidingArea.transform);
        RectTransform handleRectTransform = handle.AddComponent<RectTransform>();
        // set Handle visual
        Image handleImg = handle.AddComponent<Image>();
        handleImg.type = Image.Type.Sliced;
        handleImg.sprite = Resources.Load<Sprite>("UI/ScrollBarsSliders/ScrollBar_Handle");
        // set Handle anchor, position and size
        handleRectTransform.anchorMin = new Vector2(0, 0.1244573f);
        handleRectTransform.anchorMax = Vector2.one;
        handleRectTransform.pivot = new Vector2(0.5f, 0.5f);
        handleRectTransform.anchoredPosition = Vector2.zero;
        handleRectTransform.sizeDelta = Vector2.zero;
        // set Handle Hover Overlay
        GameObject handleOverlay = new GameObject("Hover Overlay");
        handleOverlay.transform.SetParent(handle.transform);
        RectTransform handleOverlayRectTransform = handleOverlay.AddComponent<RectTransform>();
        // set Handle Hover Overlay visual
        Image handleOverlayImg = handleOverlay.AddComponent<Image>();
        handleOverlayImg.type = Image.Type.Sliced;
        handleOverlayImg.sprite = Resources.Load<Sprite>("UI/ScrollBarsSliders/ScrollBar_Hover");
        // set Handle Hover Overlay anchor, position and size
        handleOverlayRectTransform.anchorMin = Vector2.zero;
        handleOverlayRectTransform.anchorMax = Vector2.one;
        handleOverlayRectTransform.pivot = Vector2.zero;
        handleOverlayRectTransform.anchoredPosition = Vector2.zero;
        handleOverlayRectTransform.sizeDelta = Vector2.zero;

        // set Scrollbar Target Graphic
        verticalScroll.targetGraphic = handleOverlayImg;

        // set Scroll View
        GameObject scrollView = new GameObject("Scroll View");
        scrollView.transform.SetParent(statTab.transform);
        RectTransform scrollViewRectTransform = scrollView.AddComponent<RectTransform>();
        // set Scroll Rect component
        ScrollRect scrollRect = scrollView.AddComponent<ScrollRect>();
        scrollRect.horizontal = false;
        scrollRect.scrollSensitivity = 26;
        scrollRect.viewport = scrollViewRectTransform;
        scrollRect.verticalScrollbar = verticalScroll;
        scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
    }

    private GameObject CreateLayoutGroup(string name, Transform parent, Vector2 anchoredPosition, Vector2 size, ESlotsPart part)
    {
        // set Slots Grid Layout Group
        GameObject slots = new GameObject(name);
        slots.transform.SetParent(parent);
        slots.AddComponent<RectTransform>();
        // set Slots Grid Layout Group component
        GridLayoutGroup slotsGridLayout = slots.AddComponent<GridLayoutGroup>();
        slotsGridLayout.cellSize = new Vector2(104, 104);
        switch (part)
        {
            case ESlotsPart.Left:
            case ESlotsPart.Right:
                slotsGridLayout.spacing = new Vector2(0, 36);
                slotsGridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
                break;
            case ESlotsPart.Bottom:
                slotsGridLayout.spacing = new Vector2(36, 36);
                slotsGridLayout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
                break;
        }
        slotsGridLayout.constraintCount = 1;
        // set Left Slots anchor, position and size
        RectTransform slotsRectTransform = slots.GetComponent<RectTransform>();
        slotsRectTransform.anchorMin = new Vector2(0, 1);
        slotsRectTransform.anchorMax = new Vector2(0, 1);
        slotsRectTransform.pivot = new Vector2(0, 1);
        slotsRectTransform.anchoredPosition = anchoredPosition;
        slotsRectTransform.sizeDelta = size;
        
        return slots;
    }

    private void CreateSlots(Transform parent, int index, ESlotsPart part)
    {
        // set Slot
        GameObject slot = new GameObject($"Slot ({(ELeftSlots)index})");
        slot.transform.SetParent(parent);
        slot.AddComponent<RectTransform>();
        // set Slot visual
        Image slotImg = slot.AddComponent<Image>();
        switch(part)
        {
            case ESlotsPart.Left:
                switch((ELeftSlots)index)
                {
                    case ELeftSlots.Head: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Head"); break;
                    case ELeftSlots.Necklace: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Necklace"); break;
                    case ELeftSlots.Shoulders: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Shoulders"); break;
                    case ELeftSlots.Chest: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Chest"); break;
                    case ELeftSlots.Shirt: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Shirt"); break;
                    case ELeftSlots.Bracers: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Bracers"); break;
                }
                break;
            case ESlotsPart.Right:
                switch((ERightSlots)index)
                {
                    case ERightSlots.Gloves: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Gloves"); break;
                    case ERightSlots.Belt: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Belt"); break;
                    case ERightSlots.Pants: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Pants"); break;
                    case ERightSlots.Boots: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Boots"); break;
                    case ERightSlots.Finger: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Finger"); break;
                    case ERightSlots.Trinket: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Trinket"); break;
                }
                break;
            case ESlotsPart.Bottom:
                switch((EBottomSlots)index)
                {
                    case EBottomSlots.Main: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Weapon"); break;
                    case EBottomSlots.Off: slotImg.sprite = Resources.Load<Sprite>("UI/Character_Window/Slots/CharacterWindow_Slot_Shield"); break;
                }
                break;
        }

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