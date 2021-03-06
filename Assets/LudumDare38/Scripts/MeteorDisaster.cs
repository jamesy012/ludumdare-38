﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDisaster : BaseDisaster {

	public float m_MaxThrowSpeed = 500;
	public float m_NormalThrowSpeed = 50;

	private float m_ClickTime = 0;
	public float m_MaxHoldTime = 0.3f;

	public GameObject m_explosionPrefab;

	public float m_StartingForce = 5.0f;

	private Vector2 m_ClickPos;

	private Rigidbody m_rigidBody;

	private AddPointsOnDestroy m_Apod;

	private void Start() {
		m_Apod = GetComponent<AddPointsOnDestroy>();
		m_Apod.enabled = false;

		m_rigidBody = this.GetComponent<Rigidbody>();

		Vector2 startForce;
		startForce.x = Random.Range(0.0f, m_StartingForce);
		startForce.y = Random.Range(0.0f, m_StartingForce);

		m_rigidBody.AddForce(startForce);

	}
	// Update is called once per frame
	void Update() {
		if (m_grabbed) {


			if (Time.time > m_ClickTime + m_MaxHoldTime) {
				m_ClickTime = Time.time - m_MaxHoldTime;//make the time calculation = 0
				releaceFling();
			} else {
				//this.transform.position = getWorldPosOfMouse();
			}

		}


	}

	protected override void clicked() {
		base.clicked();
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



	private void flingMeteor(float a_Speed) {
		m_rigidBody.velocity = Vector3.zero;

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
			//have to use distance now instead due to 2nd collider being a trigger. so the meteor is easier to grab
			if (Vector3.Distance(Vector3.zero, transform.position) > 10) {
				Destroy(gameObject);
			}
		}
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag == "Meteor") {
			SelfDestruct();
		}
		if (collision.transform.tag == "Planet") {
			SelfDestruct();
			DecreaseSizeDestroy dsd = GetComponent<DecreaseSizeDestroy>();
			dsd.m_TimeTakenToFadeOut = 0.2f;
		}
	}

	protected override void SelfDestruct() {
		m_Apod.enabled = true;
		Destroy(this);
		gameObject.AddComponent<DecreaseSizeDestroy>();
		Instantiate(m_explosionPrefab, this.transform.position, Quaternion.identity);

	}
}
