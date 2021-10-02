using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized] public bool isEnd;
    [SerializeField] UnityEvent m_event = default;
    bool isOn;
    [SerializeField] public Text m_text = default;
    [SerializeField] public float m_remainder = 20f;
    [SerializeField] public float m_upNum = 5f;
    [SerializeField] public Transform m_back = default;

    private void Update()
    {
        m_text.text = m_remainder.ToString("F0") + "個";

        if(isEnd && !isOn)
        {
            m_event.Invoke();
            isOn = true;
        }
    }
}
