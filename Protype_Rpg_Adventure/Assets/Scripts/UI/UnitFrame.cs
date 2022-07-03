using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFrame : MonoBehaviour
{
    [SerializeField] private Color m_StatsTextColor;
    [SerializeField] private Color m_LevelTextColor;

    private RectTransform m_UnitFrameRectTransform;

    private Image m_BackgroundImage;
    private Image m_HpBarImage;
    private Image m_MpBarImage;
    private Image m_LevelFrameImage;
    private Image m_AvatarMaskImage;
    private Image m_AvatarImage;

    private Text m_HpText;
    private Text m_MpText;
    private Text m_LevelFrameText;


    public void CreateUnitFrame()
    {
        // rename game object
        gameObject.name = "Unit Frame (Player)";
        // set anchor, position and size of the Unit Frame
        m_UnitFrameRectTransform = GetComponent<RectTransform>();
        m_UnitFrameRectTransform.anchorMin = new Vector2(0, 1);
        m_UnitFrameRectTransform.anchorMax = new Vector2(0, 1);
        m_UnitFrameRectTransform.pivot = new Vector2(0, 1);
        m_UnitFrameRectTransform.anchoredPosition = new Vector2(31, -28);
        m_UnitFrameRectTransform.sizeDelta = new Vector2(679, 176);
        // set background visual
        m_BackgroundImage = gameObject.AddComponent<Image>();
        m_BackgroundImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/UnitFrame_Background");

        SetBars();
        SetAvatarMask();
        SetLevelFrame();
    }

    private void SetBars()
    {
        // set HP bar
        GameObject hpBar = new GameObject("HP Bar");
        hpBar.transform.SetParent(transform);
        // set HP bar visual
        m_HpBarImage = hpBar.AddComponent<Image>();
        m_HpBarImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/Bars/UnitFrame_HP_Fill_Red");
        m_HpBarImage.type = Image.Type.Filled;
        m_HpBarImage.fillMethod = Image.FillMethod.Horizontal;
        // set HP bar anchor, position and size
        RectTransform hpBarRectTransform = hpBar.GetComponent<RectTransform>();
        hpBarRectTransform.anchorMin = new Vector2(0, 1);
        hpBarRectTransform.anchorMax = new Vector2(0, 1);
        hpBarRectTransform.pivot = new Vector2(0, 1);
        hpBarRectTransform.anchoredPosition = new Vector2(172, -48);
        hpBarRectTransform.sizeDelta = new Vector2(488, 40);
        // set HP Text
        GameObject hpText = new GameObject("HP Text");
        hpText.transform.SetParent(hpBar.transform);
        // set HP Text component
        m_HpText = hpText.AddComponent<Text>();
        m_HpText.text = "100%";
        m_HpText.font = Resources.Load<Font>("Fonts/KhmerUIb");
        m_HpText.fontStyle = FontStyle.Normal;
        m_HpText.fontSize = 22;
        m_HpText.color = m_StatsTextColor;
        // set HP Text ancho, position and size
        RectTransform hpTextRectTransform = hpText.GetComponent<RectTransform>();
        hpTextRectTransform.anchorMin = new Vector2(0, 1);
        hpTextRectTransform.anchorMax = new Vector2(0, 1);
        hpTextRectTransform.pivot = new Vector2(0, 1);
        hpTextRectTransform.anchoredPosition = new Vector2(18, -8);
        hpTextRectTransform.sizeDelta = new Vector2(160, 30);

        // set MP bar
        GameObject mpBar = new GameObject("MP Bar");
        mpBar.transform.SetParent(transform);
        // set MP bar visual
        m_MpBarImage = mpBar.AddComponent<Image>();
        m_MpBarImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/Bars/UnitFrame_MP_Fill_Green");
        m_MpBarImage.type = Image.Type.Filled;
        m_MpBarImage.fillMethod = Image.FillMethod.Horizontal;
        // set MP bar anchor, position and size
        RectTransform mpBarRectTransform = mpBar.GetComponent<RectTransform>();
        mpBarRectTransform.anchorMin = new Vector2(0, 1);
        mpBarRectTransform.anchorMax = new Vector2(0, 1);
        mpBarRectTransform.pivot = new Vector2(0, 1);
        mpBarRectTransform.anchoredPosition = new Vector2(167, -96);
        mpBarRectTransform.sizeDelta = new Vector2(460, 38);
        // set MP Text
        GameObject mpText = new GameObject("MP Text");
        mpText.transform.SetParent(mpBar.transform);
        // set MP Text component
        m_MpText = mpText.AddComponent<Text>();
        m_MpText.text = "100%";
        m_MpText.font = Resources.Load<Font>("Fonts/KhmerUIb");
        m_MpText.fontStyle = FontStyle.Normal;
        m_MpText.fontSize = 22;
        m_MpText.color = m_StatsTextColor;
        // set MP Text ancho, position and size
        RectTransform mpTextRectTransform = mpText.GetComponent<RectTransform>();
        mpTextRectTransform.anchorMin = new Vector2(0, 1);
        mpTextRectTransform.anchorMax = new Vector2(0, 1);
        mpTextRectTransform.pivot = new Vector2(0, 1);
        mpTextRectTransform.anchoredPosition = new Vector2(22, -8);
        mpTextRectTransform.sizeDelta = new Vector2(160, 30);
    }

    private void SetLevelFrame()
    {
        // set Level Frame
        GameObject levelFrame = new GameObject("Level Frame");
        levelFrame.transform.SetParent(transform);
        // set Level Frame visual
        m_LevelFrameImage = levelFrame.AddComponent<Image>();
        m_LevelFrameImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/Level/UnitFrame_Level_Background");
        // set Level Frame anchor, position and size
        RectTransform levelFrameRectTransform = levelFrame.GetComponent<RectTransform>();
        levelFrameRectTransform.anchorMin = new Vector2(0, 1);
        levelFrameRectTransform.anchorMax = new Vector2(0, 1);
        levelFrameRectTransform.pivot = new Vector2(0, 1);
        levelFrameRectTransform.anchoredPosition = new Vector2(122, -122);
        levelFrameRectTransform.sizeDelta = new Vector2(58, 58);
        // set Level Frame Text
        GameObject levelFrameText = new GameObject("Level Frame Text");
        levelFrameText.transform.SetParent(levelFrame.transform);
        // set Level Frame Text component
        m_LevelFrameText = levelFrameText.AddComponent<Text>();
        m_LevelFrameText.text = "1";
        m_LevelFrameText.font = Resources.Load<Font>("Fonts/arialbd");
        m_LevelFrameText.fontStyle = FontStyle.Normal;
        m_LevelFrameText.fontSize = 24;
        m_LevelFrameText.alignment = TextAnchor.UpperCenter;
        m_LevelFrameText.color = m_LevelTextColor;
        // set Level Frame Text ancho, position and size
        RectTransform levelFrameTextTextRectTransform = levelFrameText.GetComponent<RectTransform>();
        levelFrameTextTextRectTransform.anchorMin = new Vector2(0, 1);
        levelFrameTextTextRectTransform.anchorMax = new Vector2(1, 1);
        levelFrameTextTextRectTransform.pivot = new Vector2(0, 1);
        levelFrameTextTextRectTransform.anchoredPosition = new Vector2(0, -16);
        levelFrameTextTextRectTransform.sizeDelta = new Vector2(0, 32);
    }

    private void SetAvatarMask()
    {
        // set Avatar Mask
        GameObject avatarMask = new GameObject("Avatar Mask");
        avatarMask.transform.SetParent(transform);
        // set Avatar Mask visual
        m_AvatarMaskImage = avatarMask.AddComponent<Image>();
        m_AvatarMaskImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/Avatar/UnitFrame_Avatar_Mask");
        // set Avatar Mask anchor, position and size
        RectTransform avatarMaskRectTransform = avatarMask.GetComponent<RectTransform>();
        avatarMaskRectTransform.anchorMin = new Vector2(0, 1);
        avatarMaskRectTransform.anchorMax = new Vector2(0, 1);
        avatarMaskRectTransform.pivot = new Vector2(0.5f, 0.5f);
        avatarMaskRectTransform.anchoredPosition = new Vector2(105, -88);
        avatarMaskRectTransform.sizeDelta = new Vector2(136, 136);

        // set Avatar
        GameObject avatar = new GameObject("Avatar");
        avatar.transform.SetParent(avatarMask.transform);
        // set Avatar visual
        m_AvatarImage = avatar.AddComponent<Image>();
        m_AvatarImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/Avatar/UnitFrame_Avatar_Example");
        // set Avatar anchor, position and size
        RectTransform avatarRectTransform = avatar.GetComponent<RectTransform>();
        avatarRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        avatarRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        avatarRectTransform.pivot = new Vector2(0.5f, 0.5f);
        avatarRectTransform.anchoredPosition = new Vector2(0, 0);
        avatarRectTransform.sizeDelta = new Vector2(136, 136);
    }
}