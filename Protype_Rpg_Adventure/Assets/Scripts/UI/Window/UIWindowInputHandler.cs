using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIWindow))]
public class UIWindowInputHandler : MonoBehaviour, IUIWindowInputHandler
{
    [SerializeField] private KeyCode m_KeyCode = KeyCode.None;
    public KeyCode Key { get => m_KeyCode; set => m_KeyCode = value; }
    
    protected UIWindow m_Window;
    private bool m_IsOpen = false;
    

    protected virtual void Awake ()
    {
        m_Window = GetComponent<UIWindow>();
    }

    protected virtual void Update ()
    {
        //if (Input.GetKeyDown(m_KeyCode))
        //{
        //    m_Window.Toggle();
        //}
        if (Input.GetKeyDown(m_KeyCode) && !m_IsOpen)
        {
            ShowWindow();
        }
        else if (Input.GetKeyDown(m_KeyCode) && m_IsOpen)
        {
            HideWindow();
        }
    }

    public void ShowWindow()
    {
        m_IsOpen = true;
        m_Window.Show();
    }

    public void HideWindow()
    {
        m_IsOpen = false;
        m_Window.Hide();
    }
}
