using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text m_startText = default;
    [SerializeField] float m_count = 3.5f;
    [SerializeField] UnityEvent m_startEvent = default;
    bool isStart;

    [System.NonSerialized] public bool isOver;
    [SerializeField] UnityEvent m_GameOverEvent = default;
    [SerializeField] UnityEvent m_GameClearEvent = default;
    bool isOn;
    [SerializeField] public Text m_text = default;
    [SerializeField] public float m_remainder = 20f;
    [System.NonSerialized]public float m_maxNum;
    [SerializeField] public float m_upNum = 5f;
    [SerializeField] public Transform m_back = default;

    private void Start()
    {
        m_maxNum = m_remainder;
    }

    private void Update()
    {
        m_text.text = m_remainder.ToString("F0") + "個";

        if(m_count >= 0)
        {
            m_count -= Time.deltaTime;
            m_startText.text = m_count.ToString("F0");
        }
        else if(m_count <= 0 && !isStart)
        {
            m_startEvent.Invoke();
            isStart = true;
        }

        if(isOver && !isOn)
        {
            m_GameOverEvent.Invoke();
            Cursor.visible = true;
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(m_maxNum - m_remainder);
            isOn = true;
        }
        if(m_remainder <= 0 && !isOn)
        {
            m_GameClearEvent.Invoke();
            Cursor.visible = true;
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(m_maxNum - m_remainder);
            isOn = true;
        }
    }
}
