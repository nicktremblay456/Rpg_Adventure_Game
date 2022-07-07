using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowToggler : MonoBehaviour
{
    [SerializeField] private KeyCode m_ShowWindowKeyCode = KeyCode.I;
    [SerializeField] private KeyCode m_HideKeyCode = KeyCode.Escape;
    private UIWindow m_Window;

    private void Awake() 
    {
        m_Window = GetComponent<UIWindow>();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(m_ShowWindowKeyCode) && !m_Window.IsVisible)
        {
            m_Window.Show();
        }
        else if (Input.GetKeyDown(m_HideKeyCode) || Input.GetKeyDown(m_ShowWindowKeyCode) && m_Window.IsVisible)
        {
            m_Window.Hide();
        }
    }
}
