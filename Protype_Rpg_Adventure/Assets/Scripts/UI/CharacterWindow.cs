using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWindow : MonoBehaviour
{
    [SerializeField] private Color m_HeaderTextColor;

    private Button m_ButtonClose;

    public void CreateCharacterWindow()
    {
        // rename game object
        gameObject.name = "Window (Character)";
        // set anchor, position and size of the Character Window
        UI.SetRectTransform(gameObject, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(28, -276), new Vector2(1414, 1528));
        // set background visual
        Image windowBackgroundImg = gameObject.AddComponent<Image>();
        windowBackgroundImg.type = Image.Type.Sliced;
        windowBackgroundImg.sprite = Resources.Load<Sprite>("UI/Window/Window_Background");
        // add canvas group component
        gameObject.AddComponent<CanvasGroup>();

        // set Header
        UI.CreateHeader(transform, "CHARACTER", new Vector2(32, 118), new Vector2(-64, 56), m_HeaderTextColor);

        SetContent();

        // set UIWindow component and Input Handler to toggle the Window
        UIWindow window = gameObject.AddComponent<UIWindow>();
        UIWindowInputHandler inputHandler = gameObject.AddComponent<UIWindowInputHandler>();
        inputHandler.Key = KeyCode.C;
        // Add Close Button and add event
        UI.CreateButtonClose(transform, inputHandler.HideWindow);
    }

    private void SetContent()
    {
        // set Content
        GameObject content = new GameObject("Content");
        content.transform.SetParent(transform);
        // set Content achor, position and size
        UI.SetRectTransform(content, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(0, 0));

        // set Character View
        GameObject charView = new GameObject("Character View");
        charView.transform.SetParent(content.transform);
        // set Character View anchor, position and size
        UI.SetRectTransform(charView, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(190, -400), new Vector2(514, 926));

        // set Example
        GameObject ex = new GameObject("Example");
        ex.transform.SetParent(charView.transform);
        // set Example visual
        Image exImg = ex.AddComponent<Image>();
        exImg.sprite = Resources.Load<Sprite>("UI/Character_Window/CharacterWindow_Character_Example");
        // set Example anchor, position and size
        UI.SetRectTransform(ex, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(74, -40), new Vector2(352, 794));

        // set Equip Slots
        GameObject equipSlots = new GameObject("Equip Slots");
        equipSlots.transform.SetParent(content.transform);
        // set Equip Slots anchore, position and size
        UI.SetRectTransform(equipSlots, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(0, 0));

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
        // set Separator visual
        Image separatorImg = separator.AddComponent<Image>();
        separatorImg.type = Image.Type.Sliced;
        separatorImg.sprite = Resources.Load<Sprite>("UI/Window/Window_Separator_Vertical");
        // set Separator anchor, position, size
        UI.SetRectTransform(separator, new Vector2(0, 0), new Vector2(0, 1), new Vector2(0, 1), new Vector2(862, 256 - (256*2)), new Vector2(14, 54 - 364));

        // set Tab Content
        GameObject tabContent = new GameObject("Tab Contents");
        tabContent.transform.SetParent(transform);
        // set Content anchor, position ans size
        UI.SetRectTransform(tabContent, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(0, 0));

        // set Statisctics Tab
        GameObject statTab = new GameObject("Tab (Statistics)");
        statTab.transform.SetParent(tabContent.transform);
        // set Statistics Tab anchor, position and size
        UI.SetRectTransform(statTab, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(874, 228 - (228*2)), new Vector2(-874, -228));

        // set Stats Content
        GameObject statsContent = Instantiate(Resources.Load<GameObject>("Prefabs/UI/StatsContent"));
        statsContent.gameObject.name = "Content";
        statsContent.transform.SetParent(statTab.transform);
        UI.SetRectTransform(statsContent, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, -32), new Vector2(76, 1382));
    }

    private GameObject CreateLayoutGroup(string name, Transform parent, Vector2 anchoredPosition, Vector2 size, ESlotsPart part)
    {
        // set Slots Grid Layout Group
        GameObject slots = new GameObject(name);
        slots.transform.SetParent(parent);
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
        // set Slots anchor, position and size
        UI.SetRectTransform(slots, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), anchoredPosition, size);
        
        return slots;
    }

    private void CreateSlots(Transform parent, int index, ESlotsPart part)
    {
        // set Slot
        GameObject slot = new GameObject($"Slot ({(ELeftSlots)index})");
        slot.transform.SetParent(parent);
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

        UI.AddSlotOverlay(slot.transform);
    }
}