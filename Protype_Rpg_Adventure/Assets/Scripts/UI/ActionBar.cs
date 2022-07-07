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
        UI.SetRectTransform(gameObject, new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0.5f, 1), new Vector2(0, 152), new Vector2(720, 152));

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
        UI.SetRectTransform(mainBarObj, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, -20), new Vector2(0, 132));

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
        UI.SetRectTransform(slotsGrid, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(100, -20), new Vector2(520, 104));

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

        // set Hover and Press Overlay
        UI.AddSlotOverlay(slot.transform);

        // set Hotkey
        GameObject hotKey = new GameObject("Hotkey");
        hotKey.transform.SetParent(slot.transform);
        // set Hotkey Text
        UI.AddTextComponent(hotKey, $"{index + 1}", 22, m_HotkeyTextColor, EFont.KhmerUIb, TextAnchor.UpperLeft);
        // set Hotkey Text anchore, position and size
        UI.SetRectTransform(hotKey, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(14, -68), new Vector2(14, 32));
    }
}