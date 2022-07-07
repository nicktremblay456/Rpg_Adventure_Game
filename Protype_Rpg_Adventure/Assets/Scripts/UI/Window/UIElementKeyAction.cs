using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class UIElementKeyAction : MonoBehaviour
{
    private KeyCode m_KeyCode;
    public KeyCode keyCode { get => m_KeyCode; set => m_KeyCode = value; }

    public Action keyActions;

    [Header("Timers")]
    [SerializeField] private float m_ActivationTime = 0.0f;
    [SerializeField] private bool m_Continous = false;

    private float m_ActiveTime { get; set; }
    private bool m_FiredInActiveTime { get; set; }
    private UIWindow m_Window { get; set; }

    protected virtual void Awake ()
    {
        m_Window = GetComponent<UIWindow>();
    }

    protected virtual void Update ()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        if (m_Window != null && !m_Window.IsVisible)
        {
            return;
        }

        if (m_ActivationTime <= 0.01f)
        {
            if (m_Continous)
            {
                if (Input.GetKey(m_KeyCode))
                {
                    Activate();
                }
            }
            else
            {
                if (Input.GetKeyDown(m_KeyCode))
                {
                    Activate();
                }
            }

            return;
        }

        if (Input.GetKey(m_KeyCode))
        {
            m_ActiveTime += Time.deltaTime;
        }
        else
        {
            m_ActiveTime = 0.0f;
            m_FiredInActiveTime = false;
        }

        if (m_ActiveTime < m_ActivationTime)
        {
            return;
        }

        if (m_Continous)
        {
            if (Input.GetKey(m_KeyCode))
            {
                keyActions.Invoke();
            }
        }
        else
        {
            if (m_FiredInActiveTime)
            {
                return;
            }

            if (Input.GetKey(m_KeyCode))
            {
                keyActions.Invoke();
                m_FiredInActiveTime = true;
            }
        }
    }

    protected virtual void Activate ()
    {
        keyActions.Invoke();
    }
}
