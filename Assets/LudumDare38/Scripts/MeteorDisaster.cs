using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDisaster : BaseDisaster {

	public float m_MaxThrowSpeed = 500;
	public float m_NormalThrowSpeed = 50;

	private float m_ClickTime = 0;
	public float m_MaxHoldTime = 0.3f;

	private Vector2 m_ClickPos;

    private Rigidbody m_rigidBody;

    private void Start()
    {
        m_rigidBody = this.GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update() {
		if (m_grabbed)
        {

			if (Time.time > m_ClickTime + m_MaxHoldTime) {
				m_ClickTime = Time.time - m_MaxHoldTime;//make the time calculation = 0
				releaceFling();
			} else {
				//flingMeteor(m_NormalThrowSpeed);
			}

		}

	}

	protected override void clicked() {
		m_ClickTime = Time.time;
		m_ClickPos = getWorldPosOfMouse();
	}

	public void OnMouseExit() {
		if (m_grabbed) {

			releaceFling();
		}
	}

	private void releaceFling() {
		flingMeteor(m_MaxThrowSpeed);

		m_grabbed = false;
	}

	private Vector2 getWorldPosOfMouse() {
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	private void flingMeteor(float a_Speed) {

		float timeLeft = ((m_ClickTime + m_MaxHoldTime) - Time.time) / m_MaxHoldTime;

		timeLeft = Mathf.Max(timeLeft, 0.5f);//make sure it's not 0

		Vector2 mousePos = getWorldPosOfMouse();

		Vector2 difference = mousePos - m_ClickPos;

		//float speed = m_MaxThrowSpeed / difference.magnitude;

		Vector2 force = difference * a_Speed * timeLeft;

		m_rigidBody.AddForce(force);
	}

	public void OnTriggerExit(Collider collision) {
		if (collision.transform.tag == "Planet") {
			Destroy(gameObject);
		}
	}
}
