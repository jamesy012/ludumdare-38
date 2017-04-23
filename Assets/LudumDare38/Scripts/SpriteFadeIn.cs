using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFadeIn : MonoBehaviour {

	private SpriteRenderer m_Sr;
	private float m_Desired;

	public MonoBehaviour m_EnableWhenDone;

	/// <summary>
	/// how long in seconds will this object take to fade out
	/// </summary>
	public float m_TimeTakenToFadeIn = 1.0f;

	/// <summary>
	/// start time of the script
	/// </summary>
	private float m_StartTime;

	public void Awake() {
	m_Sr = GetComponent<SpriteRenderer>();

		if(m_Sr == null) {
			Debug.LogWarning("No SpriteRenderer on " + transform.name);
			finish();
			return;
		}

		Color col = m_Sr.color;
		m_Desired = col.a;
		col.a = 0;

		m_Sr.color = col;

		m_StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_Sr == null) {
			return;
		}
		float time = (Time.time - m_StartTime) / m_TimeTakenToFadeIn;

		Color col = m_Sr.color;

		col.a = Mathf.Lerp(0, m_Desired, time);

		m_Sr.color = col;

		if (time >= 1) {
			finish();
		}
	}

	void finish() {

		if(m_EnableWhenDone != null) {
			m_EnableWhenDone.enabled = true;
		}

		Destroy(this);
	}
}
