﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : BaseDisaster {
	public GameObject m_lavaRock;
	float m_timer = 0.0f;
	public float m_eruptInterval = 2.0f;
	public float m_eruptionForce = 100.0f;
	public float m_eruptionPointOffset = 0.5f;
	public float m_deathHeightOffset = 0.05f;

	public uint m_numOfRocks = 1;
	private Vector3 eruptPosition;
	private float m_eruptHeight = 0.0f;
	private float m_currHeight = 0.0f;
	private bool m_risen = false;
	private float m_heightSunk = 0.0f;

	//flick
	private float m_ClickTime = 0;
	public float m_MaxHoldTime = 0.3f;
	private bool m_HasBeenFlicked = false;
	private Vector2 m_ClickPos;

	// Use this for initialization
	void Start() {
		m_eruptHeight = Vector3.Distance(Vector3.zero, this.transform.position);
		//push down
		this.transform.position = Vector3.down * m_deathHeightOffset;
	}

	// Update is called once per frame
	void Update() {
		eruptPosition = this.transform.position + this.transform.up * m_eruptionPointOffset;

		m_currHeight = Vector3.Distance(Vector3.zero, this.transform.position);

		if (m_timer >= m_eruptInterval) {

			Erupt();
			m_timer = 0.0f;
		}

		//if grabbed and dragged towards planet

		if (m_HasBeenFlicked) {
			SquashDown();
		} else {
			if (m_grabbed) {
				//limit amount of time for click
				if (Time.time > m_ClickTime + m_MaxHoldTime) {
					m_ClickTime = Time.time - m_MaxHoldTime;//make the time calculation = 0
					checkIfFlick();
				}
			} else {
				RiseUp();

				m_timer += Time.deltaTime;
			}
		}

		//if passed death threshold self destroy
		if (m_heightSunk >= m_deathHeightOffset) {
			SelfDestruct();
		}
	}

	private void Erupt() {
		if (m_lavaRock == null) {
			return;
		}

		for (uint i = 0; i < m_numOfRocks; ++i) {
			//create new lava rock
			GameObject newLavaRock = Instantiate(m_lavaRock, eruptPosition, Quaternion.identity);

			Rigidbody rb = newLavaRock.GetComponent<Rigidbody>();

			Vector3 rockDirection = this.transform.up + Random.Range(-1.0f, 1.0f) * this.transform.right;
			//launch rock
			rb.AddForce(rockDirection.normalized * m_eruptionForce * Time.deltaTime, ForceMode.Impulse);
		}


	}

	protected override void clicked() {
		base.clicked();
		m_ClickTime = Time.time;
		m_ClickPos = getWorldPosOfMouse();
	}

	public void OnMouseExit() {
		if (m_grabbed) {

			checkIfFlick();
		}
	}

	private void checkIfFlick() {
		Vector2 mousePos = getWorldPosOfMouse();

		float startToCenter = Vector3.Distance(m_ClickPos, Vector3.zero);
		float endToCenter = Vector3.Distance(mousePos, Vector3.zero);

		if (endToCenter < startToCenter) {
			m_HasBeenFlicked = true;
		}
	}

	private void RiseUp() {
		if (m_currHeight <= m_eruptHeight) {
			this.transform.Translate(Vector3.up * Time.deltaTime);
			if (m_risen) {

				m_heightSunk -= Time.deltaTime;
			}

		} else {
			m_risen = true;
		}



	}

	private void SquashDown() {
		this.transform.Translate(-Vector3.up * Time.deltaTime);
		m_heightSunk += 1 * Time.deltaTime;
	}




}
