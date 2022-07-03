using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    [SerializeField] private Color m_HotkeyTextColor;

    public void CreateActionBar()
    {
        // rename game object
        gameObject.name = "Action Bar";
        // set anchor, position and size of the Action Bar
        RectTransform actionBarRectTransform = GetComponent<RectTransform>();
        actionBarRectTransform.anchorMin = new Vector2(0.5f, 0);
        actionBarRectTransform.anchorMax = new Vector2(0.5f, 0);
        actionBarRectTransform.pivot = new Vector2(0.5f, 1);
        actionBarRectTransform.anchoredPosition = new Vector2(0, 152);
        actionBarRectTransform.sizeDelta = new Vector2(720, 152);

        SetMainBar();
    }


    private void SetMainBar()
    {
        // set Main Bar
        GameObject mainBarObj = new GameObject("Main Bar");
        mainBarObj.transform.SetParent(transform);
        // set Main Bar visual
        Image mainBarImage = mainBarObj.AddComponent<Image>();
        mainBarImage.type = Image.Type.Tiled;
        //mainBarImage.fillCenter = true;
        mainBarImage.sprite = Resources.Load<Sprite>("UI/ActionBar/ActionBar_Main_Background");
        // set Main Bar anchor, position and size
        RectTransform mainBarRectTransform = mainBarObj.GetComponent<RectTransform>();
        mainBarRectTransform.anchorMin = new Vector2(0, 1);
        mainBarRectTransform.anchorMax = new Vector2(1, 1);
        mainBarRectTransform.pivot = new Vector2(0, 1);
        mainBarRectTransform.anchoredPosition = new Vector2(0, -20);
        mainBarRectTransform.sizeDelta = new Vector2(0, 132);

        // set Slots Grid
        GameObject slotsGrid = new GameObject("Slots Grid");
        slotsGrid.transform.SetParent(mainBarObj.transform);
        // set Grid Layout Group component
        GridLayoutGroup grid = slotsGrid.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(104, 104);
        grid.constraint =GridLayoutGroup.Constraint.FixedRowCount;
        grid.constraintCount = 1;
        // set Content Size Filter component
        ContentSizeFitter contentSizeFilter = slotsGrid.AddComponent<ContentSizeFitter>();
        contentSizeFilter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        // set Grid anchor, position and size
        RectTransform slotsGridRectTransform = slotsGrid.GetComponent<RectTransform>();
        slotsGridRectTransform.anchorMin = new Vector2(0, 1);
        slotsGridRectTransform.anchorMax = new Vector2(0, 1);
        slotsGridRectTransform.pivot = new Vector2(0, 1);
        slotsGridRectTransform.anchoredPosition = new Vector2(100, -20);
        slotsGridRectTransform.sizeDelta = new Vector2(520, 104);

        for (int i = 0; i < 5; i++)
        {
            CreateSlots(slotsGrid.transform, i);
        }
    }

    private void CreateSlots(Transform parent, int index)
    {
        // set Slot
        GameObject slot = new GameObject($"Slot {index + 1}");
        slot.transform.SetParent(parent);
        // set Slot visual
        Image slotImg = slot.AddComponent<Image>();
        slotImg.sprite = Resources.Load<Sprite>("UI/ActionBar/Slots/ActionBar_Slot_Background");

        // set Slot Hover Overlay
        GameObject hoverOverlay = new GameObject("Hover Overlay");
        hoverOverlay.transform.SetParent(slot.transform);
        hoverOverlay.AddComponent<RectTransform>();
        // set Slot Hover Overlay visual
        Image hoverOverlayImg = hoverOverlay.AddComponent<Image>();
        hoverOverlayImg.type = Image.Type.Sliced;
        hoverOverlayImg.sprite = Resources.Load<Sprite>("UI/ActionBar/Slots/ActionBar_Slot_Hover");
        // set Slot Hover Overlay anchor, position and size
        RectTransform hoverOverlayRectTransform = hoverOverlay.GetComponent<RectTransform>();
        hoverOverlayRectTransform.anchorMin = new Vector2(0, 0);
        hoverOverlayRectTransform.anchorMax = new Vector2(1, 1);
        hoverOverlayRectTransform.pivot = new Vector2(0.5f, 0.5f);
        hoverOverlayRectTransform.anchoredPosition = new Vector2(0, 0);
        hoverOverlayRectTransform.sizeDelta = new Vector2(0, 0);

        // set Slot Press Overlay
        GameObject pressOverlay = new GameObject("Press Overlay");
        pressOverlay.transform.SetParent(slot.transform);
        pressOverlay.AddComponent<RectTransform>();
        // set Slot Press Overlay visual
        Image pressOverlayImg = pressOverlay.AddComponent<Image>();
        pressOverlayImg.type = Image.Type.Sliced;
        pressOverlayImg.sprite = Resources.Load<Sprite>("UI/ActionBar/Slots/ActionBar_Slot_Press");
        // set Slot Press Overlay anchor, position and size
        RectTransform pressOverlayRectTransform = pressOverlay.GetComponent<RectTransform>();
        pressOverlayRectTransform.anchorMin = new Vector2(0, 0);
        pressOverlayRectTransform.anchorMax = new Vector2(1, 1);
        pressOverlayRectTransform.pivot = new Vector2(0.5f, 0.5f);
        pressOverlayRectTransform.anchoredPosition = new Vector2(0, 0);
        pressOverlayRectTransform.sizeDelta = new Vector2(0 , 0);

        // set Hotkey
        GameObject hotKey = new GameObject("Hotkey");
        hotKey.transform.SetParent(slot.transform);
        // set Hotkey Text
        Text hotKeyText = hotKey.AddComponent<Text>();
        hotKeyText.text = $"{index + 1}";
        hotKeyText.font = Resources.Load<Font>("Fonts/KhmerUIb");
        hotKeyText.fontSize = 22;
        hotKeyText.color = m_HotkeyTextColor;
        // set Hotkey Text anchore, position and size
        RectTransform hotKeyRectTransform = hotKey.GetComponent<RectTransform>();
        hotKeyRectTransform.anchorMin = new Vector2(0, 1);
        hotKeyRectTransform.anchorMax = new Vector2(1, 1);
        hotKeyRectTransform.pivot = new Vector2(0, 1);
        hotKeyRectTransform.anchoredPosition = new Vector2(14, -68);
        hotKeyRectTransform.sizeDelta = new Vector2(14, 32);
    }
}