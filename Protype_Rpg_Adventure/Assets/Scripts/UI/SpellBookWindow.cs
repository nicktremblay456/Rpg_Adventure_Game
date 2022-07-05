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
        UI.SetRectTransform(gameObject, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(1442, -276), new Vector2(1094, 1384));
        // set background visual
        Image windowBackgroundImg = gameObject.AddComponent<Image>();
        windowBackgroundImg.type = Image.Type.Sliced;
        windowBackgroundImg.sprite = Resources.Load<Sprite>("UI/Window/Window_Background");
        // add canvas group component
        gameObject.AddComponent<CanvasGroup>();

        // set Header
        UI.CreateHeader(transform, "SPELL BOOK", new Vector2(32, 118), new Vector2(-64, 56), m_HeaderTextColor);

        // set Tab Contents
        GameObject tabContent = new GameObject("Tab Contents");
        tabContent.transform.SetParent(transform);
        // set Tab Contents anchor, position and size
        UI.SetRectTransform(tabContent, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(0, 0));

        // TO DO - ADD BUTTON EVENT
        UI.CreateButtonClose(transform);
        SetSpellTab(tabContent.transform);
    }

    private void SetSpellTab(Transform parent)
    {
        // set Spell Tab
        GameObject spellTab = new GameObject("Tab (Spells)");
        spellTab.transform.SetParent(parent);
        // set Spell Tab anchor, position and size
        UI.SetRectTransform(spellTab, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0), new Vector2(0, 0));

        // set Scroll View
        GameObject scrollView = Instantiate(Resources.Load<GameObject>("Prefabs/UI/SpellScrollView"));
        scrollView.gameObject.name = "Scroll View";
        scrollView.transform.SetParent(spellTab.transform);
        // set Scroll View anchor, position and size
        UI.SetRectTransform(scrollView, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, 1), new Vector2(62, 266 - (266*2)), new Vector2(112, 58));
    }
}