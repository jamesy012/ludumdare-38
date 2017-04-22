using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDisaster : BaseDisaster {

	private Vector2 m_LastPosition;
	
	// Update is called once per frame
	void Update () {
		if (m_grabbed) {
			Vector2 currPosition = getCurrentClickPosition();
			Vector2 difference = currPosition - m_LastPosition;
			m_LastPosition = currPosition;

			m_rigidBody.AddForce(difference);
		}
	}

	protected override void clicked() {
		m_LastPosition = m_CurrMousePosition;
	}
}
