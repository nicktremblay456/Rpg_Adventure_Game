using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFrame : MonoBehaviour
{
    [SerializeField] private Color m_StatsTextColor;
    [SerializeField] private Color m_LevelTextColor;

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
        UI.SetRectTransform(gameObject, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(31, -28), new Vector2(679, 176));
        // set background visual
        Image backgroundImg = gameObject.AddComponent<Image>();
        backgroundImg.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/UnitFrame_Background");

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
        UI.SetRectTransform(hpBar, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(172, -48), new Vector2(488, 40));
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
        UI.SetRectTransform(hpText, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(18, -8), new Vector2(160, 30));

        // set MP bar
        GameObject mpBar = new GameObject("MP Bar");
        mpBar.transform.SetParent(transform);
        // set MP bar visual
        m_MpBarImage = mpBar.AddComponent<Image>();
        m_MpBarImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/Bars/UnitFrame_MP_Fill_Green");
        m_MpBarImage.type = Image.Type.Filled;
        m_MpBarImage.fillMethod = Image.FillMethod.Horizontal;
        // set MP bar anchor, position and size
        UI.SetRectTransform(mpBar, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(167, -96), new Vector2(460, 38));
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
        UI.SetRectTransform(mpText, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(22, -8), new Vector2(160, 30));
    }

    private void SetLevelFrame()
    {
        // set Level Frame
        GameObject levelFrame = new GameObject("Level Frame");
        levelFrame.transform.SetParent(transform);
        // set Level Frame visual
        m_LevelFrameImage = levelFrame.AddComponent<Image>();
        m_LevelFrameImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/Level/UnitFrame_Level_Background");
        // set Level Frame anchor, position and size;
        UI.SetRectTransform(levelFrame, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0, 1), new Vector2(122, -122), new Vector2(58, 58));
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
        UI.SetRectTransform(levelFrameText, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, -16), new Vector2(0, 32));
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
        UI.SetRectTransform(avatarMask, new Vector2(0, 1), new Vector2(0, 1), new Vector2(0.5f, 0.5f), new Vector2(105, -88), new Vector2(136, 136));

        // set Avatar
        GameObject avatar = new GameObject("Avatar");
        avatar.transform.SetParent(avatarMask.transform);
        // set Avatar visual
        m_AvatarImage = avatar.AddComponent<Image>();
        m_AvatarImage.sprite = Resources.Load<Sprite>("UI/UnitFrame/UnitFrames/Main/Avatar/UnitFrame_Avatar_Example");
        // set Avatar anchor, position and size
        UI.SetRectTransform(avatar, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0, 0), new Vector2(136, 136));
    }
}