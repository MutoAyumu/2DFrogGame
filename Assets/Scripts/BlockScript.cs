using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BlockScript : MonoBehaviour
{
    [SerializeField] string m_mouseTag = "Player";
    [SerializeField] string m_destroyAreaTag = "Finish";

    CircleCollider2D m_circle;

    private void Start()
    {
        m_circle = GetComponent<CircleCollider2D>();
        m_circle.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == m_mouseTag)
        {

            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == m_destroyAreaTag)
        {

            Destroy(this.gameObject);
        }
    }
}
