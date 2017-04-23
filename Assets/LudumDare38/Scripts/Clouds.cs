using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : BaseDisaster {

	public float m_orbitSpeed = 10.0f;

	/// <summary>
	/// deviation for the speed, to give each cloud their own individuality/personalty  
	/// </summary>
	public float m_OrbitSpeedDeviation = 5.0f;

	public bool m_MoveRight = false;

	public float m_CloudsBobScale = 0.2f;
	private float m_CloudBobRandomScale = 1.0f;
	private float m_StartTime;

	/// <summary>
	/// Destroy object after this many seconds
	/// if it's under 1, then it will be ignored
	/// </summary>
	public float m_DestroyAfter = 0.0f;

	// Use this for initialization
	protected virtual void Start () {
		if (Random.Range(0, 100) > 50) {
			m_MoveRight = true;
		}
		m_OrbitSpeedDeviation = Random.Range(-m_OrbitSpeedDeviation, m_OrbitSpeedDeviation);
		m_CloudBobRandomScale = Random.Range(-1.0f, 1.0f);
		m_StartTime = Time.time;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Orbit();
		moveUpDown();

		if (m_DestroyAfter > 1) {
			if (Time.time > m_StartTime + m_DestroyAfter) {
				SelfDestruct();
			}
		}
	}

	protected void moveUpDown() {
		transform.Translate(Vector3.up * Mathf.Sin(m_StartTime + Time.time) * Time.deltaTime * (m_CloudsBobScale * m_CloudBobRandomScale));
	}

	//orbit planet
	protected void Orbit() {
		float speed = (m_orbitSpeed + m_OrbitSpeedDeviation) * Time.deltaTime;
		if (m_MoveRight) {
			speed *= -1;
		}
		this.transform.RotateAround(Vector3.zero, Vector3.forward, speed);
	}

	protected float getHeight() {
		return Vector3.Distance(Vector3.zero, transform.position);
	}
}
