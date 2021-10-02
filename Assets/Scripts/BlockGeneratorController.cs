using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGeneratorController : MonoBehaviour
{
    [SerializeField] GameObject[] m_block = default;
    [SerializeField] GameObject[] m_instancePos = default;
    [SerializeField] Transform m_blockGroup = default;
    [SerializeField] float m_instanceTime = 1.5f;
    float m_timeLimit;
    [SerializeField] float m_objGravity = 1.5f;
    [SerializeField] float m_changeGravity = 3f;
    bool isOn;

    GameManager m_gm;

    private void Start()
    {
        m_timeLimit = m_instanceTime;
        m_gm = GameObject.FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(m_gm.m_remainder <= m_gm.m_upNum && !isOn)
        {
            m_objGravity = m_changeGravity;
            isOn = true;
        }

        if(m_block != null && !m_gm.isEnd)
        {
            m_timeLimit -= Time.deltaTime;

            if (m_timeLimit <= 0)
            {
                var block = m_block[Random.Range(0, m_block.Length)];
                var Pos = m_instancePos[Random.Range(0, m_instancePos.Length)];
                var obj = Instantiate(block, Pos.transform.position, Quaternion.identity, m_blockGroup);
                var a = obj.GetComponent<Rigidbody2D>();
                a.gravityScale = m_objGravity;
                m_timeLimit = m_instanceTime;
            }
        }
    }
}
