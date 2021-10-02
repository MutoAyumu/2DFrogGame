using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementScript : MonoBehaviour
{
    [SerializeField] string m_trueTag = "True";
    [SerializeField] string m_FalseTag = "False";
    [SerializeField] ModeType m_type;

    GameManager m_gm;

    private void Start()
    {
        m_gm = GameObject.FindObjectOfType<GameManager>();
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
