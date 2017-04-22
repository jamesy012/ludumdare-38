using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDisaster : BaseDisaster {

	public float m_MaxThrowSpeed = 10;

	// Update is called once per frame
	void Update() {
		if (m_grabbed) {

			Vector2 mousePos = Camera.main.ScreenToWorldPoint(m_CurrMousePosition);

			Vector2 difference = mousePos - (Vector2)transform.position;

			float speed = m_MaxThrowSpeed / difference.magnitude;

			m_rigidBody.AddForce(difference * speed);
		}
	}

	//public void OnMouseExit() {
	//	if (m_grabbed) {
	//		m_grabbed = false;
	//	}
	//}
}
