using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGeneratorController : MonoBehaviour
{
    [SerializeField] GameObject[] m_block = default;
    [SerializeField] GameObject[] m_instancePos = default;
    [SerializeField] float m_instanceTime = 3f;
    float m_timeLimit;

    GameManager m_gm;

    private void Start()
    {
        m_timeLimit = m_instanceTime;
        m_gm = GameObject.FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
        if(m_block != null && !m_gm.isEnd)
        {
            m_timeLimit -= Time.deltaTime;

            if (m_timeLimit <= 0)
            {
                var block = m_block[Random.Range(0, m_block.Length)];
                var Pos = m_instancePos[Random.Range(0, m_instancePos.Length)];
                Instantiate(block, Pos.transform.position, Quaternion.identity);
                m_timeLimit = m_instanceTime;
            }
        }
    }
}
