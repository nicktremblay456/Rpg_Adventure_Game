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
        UI.SetRectTransform(gameObject, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(3014, -1086), new Vector2(734, 1010));
        // set background visual
        Image inventoryBackgroundImage = gameObject.AddComponent<Image>();
        inventoryBackgroundImage.type = Image.Type.Sliced;
        inventoryBackgroundImage.sprite = Resources.Load<Sprite>("UI/Window/Window_Background");
        // add canvas group component
        gameObject.AddComponent<CanvasGroup>();

        // set Header
        UI.CreateHeader(transform, "INVENTORY", new Vector2(-64, 92), new Vector2(-64, 48), m_HeaderTextColor);

        SetContent();

        // set UIWindow component and Input Handler to toggle the Window
        UIWindow window = gameObject.AddComponent<UIWindow>();
        UIWindowInputHandler inputHandler = gameObject.AddComponent<UIWindowInputHandler>();
        inputHandler.Key = KeyCode.I;
        // Add Close Button and add event
        UI.CreateButtonClose(transform, inputHandler.HideWindow);
    }

    private void SetContent()
    {
        // set Content
        GameObject content = new GameObject("Content");
        content.transform.SetParent(transform);
        // set Content anchor, position and size
        UI.SetRectTransform(content, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(0, 0));

        // set Slots
        GameObject slotsObj = new GameObject("Slots");
        slotsObj.transform.SetParent(content.transform);
        // set Slots anchor, position, size
        UI.SetRectTransform(slotsObj, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(40, -134), new Vector2(-80, 108));
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

        UI.AddSlotOverlay(slot.transform);
    }
}