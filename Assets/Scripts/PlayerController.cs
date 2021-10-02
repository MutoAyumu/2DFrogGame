using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;

	Rigidbody2D m_rb;
	CircleCollider2D m_circle;

    private void Start()
    {
		Cursor.visible = false;
		m_rb = GetComponent<Rigidbody2D>();
		m_rb.gravityScale = 0;
		m_circle = GetComponent<CircleCollider2D>();
		m_circle.isTrigger = true;
    }

    void Update()
	{
		// Vector3でマウス位置座標を取得する
		position = Input.mousePosition;
		// Z軸修正
		position.z = 10f;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
		// ワールド座標に変換されたマウス座標を代入
		gameObject.transform.position = screenToWorldPointPosition;
	}
}
