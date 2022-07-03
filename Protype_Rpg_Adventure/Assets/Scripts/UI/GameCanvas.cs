using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameCanvas : MonoBehaviour
{
    private GameObject m_CanvasObj;
    private Canvas m_Canvas;
    private CanvasScaler m_CanvasScaler;
    private GraphicRaycaster m_GraphicRaycaster;

    private void Start()
    {
        // Create the gameobject
        m_CanvasObj = new GameObject("Game Canvas");
        m_CanvasObj.transform.SetParent(this.transform);

        // add canvas component
        m_Canvas = m_CanvasObj.AddComponent<Canvas>();
        m_CanvasScaler = m_CanvasObj.AddComponent<CanvasScaler>();
        m_GraphicRaycaster = m_CanvasObj.AddComponent<GraphicRaycaster>();

        // set canvas settings
        m_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        m_Canvas.sortingOrder = 1;

        // set canvas scaler
        m_CanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        m_CanvasScaler.referenceResolution = new Vector2(3840, 2160);
        m_CanvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        m_CanvasScaler.matchWidthOrHeight = 1;

        // set graphic raycaster
        m_GraphicRaycaster.ignoreReversedGraphics = true;
        m_GraphicRaycaster.blockingObjects = GraphicRaycaster.BlockingObjects.None;

        // create Unity Frame
        UnitFrame unitFrame = Instantiate(Resources.Load<UnitFrame>("Prefabs/UI/UnitFrame"));
        unitFrame.transform.SetParent(m_Canvas.transform);
        unitFrame.CreateUnitFrame();

        // create Inventory Window
        InventoryWindow invWindow = Instantiate(Resources.Load<InventoryWindow>("Prefabs/UI/InventoryWindow"));
        invWindow.transform.SetParent(m_Canvas.transform);
        invWindow.CreateInventory();
        
        // create Character Window
        CharacterWindow charWindow = Instantiate(Resources.Load<CharacterWindow>("Prefabs/UI/CharacterWindow"));
        charWindow.transform.SetParent(m_Canvas.transform);
        charWindow.CreateCharacterWindow();

        // create Action Bar
        ActionBar actionBar = Instantiate(Resources.Load<ActionBar>("Prefabs/UI/ActionBar"));
        actionBar.transform.SetParent(m_Canvas.transform);
        actionBar.CreateActionBar();

        // create Spell Book Window
        SpellBookWindow spellBook = Instantiate(Resources.Load<SpellBookWindow>("Prefabs/UI/SpellBookWindow"));
        spellBook.transform.SetParent(m_Canvas.transform);
        spellBook.CreateSpellBookWindow();

        // create Event System
        GameObject eventSystObj = new GameObject("EventSystem");
        eventSystObj.AddComponent<EventSystem>();
        eventSystObj.AddComponent<StandaloneInputModule>();
        eventSystObj.transform.SetParent(transform);
    }
}