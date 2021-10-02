using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementScript : MonoBehaviour
{
    [SerializeField] string m_trueTag = "True";
    [SerializeField] string m_FalseTag = "False";
    [SerializeField] ModeType m_type;
    [SerializeField] float m_increase = 1f;

    GameManager m_gm;
    Vector2 m_pos;

    private void Start()
    {
        m_gm = GameObject.FindObjectOfType<GameManager>();
        m_pos = m_gm.m_back.position;
    }

    enum ModeType
    {
        Player,
        DestroyArea
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(m_type)
        {
            case ModeType.Player:
                if (collision.gameObject.tag == m_trueTag)
                {
                    m_gm.m_remainder--;
                    m_pos.y -= m_increase;
                    m_gm.m_back.position = m_pos;
                    Destroy(collision.gameObject);
                }
                if (collision.gameObject.tag == m_FalseTag)
                {
                    m_gm.isEnd = true;
                    Destroy(collision.gameObject);
                }
                break;
            case ModeType.DestroyArea:
                if (collision.gameObject.tag == m_trueTag)
                {
                    m_gm.isEnd = true;
                    Destroy(collision.gameObject);
                }
                if (collision.gameObject.tag == m_FalseTag)
                {
                    Destroy(collision.gameObject);
                }
                break;
        }
        
    }
}
