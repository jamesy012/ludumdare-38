using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutDestroy : MonoBehaviour {

	/// <summary>
	/// if there is a sprite renderer the object
	/// </summary>
	private SpriteRenderer m_Sr;

	/// <summary>
	/// how long in seconds will this object take to fade out
	/// </summary>
	public float m_TimeTakenToFadeOut = 1.0f;

	/// <summary>
	/// start time of the script
	/// </summary>
	private float m_StartTime;

	/// <summary>
	/// if there is no spriteRenderer then the script is useless
	/// so lets just destroy it
	/// </summary>
	private bool m_IfNoSpriteRendererDestroyObject = true;

	private Color m_StartColor;
	private Color m_DesiredColor;

	// maybe change to OnEnable
	void Start () {
		m_Sr = GetComponent<SpriteRenderer>();

		if(m_Sr == null && m_IfNoSpriteRendererDestroyObject) {
			Destroy(gameObject);
			Debug.LogWarning("Object has no SpriteRenderer to fade out " + transform.name);
			return;
		}

		m_StartTime = Time.time;
		m_StartColor = m_DesiredColor = m_Sr.color;
		m_DesiredColor.a = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (m_Sr == null) {
			return;
		}
		float time = (Time.time - m_StartTime) / m_TimeTakenToFadeOut;

		m_Sr.color = Color.Lerp(m_StartColor, m_DesiredColor,time);

		if(time >= 1) {
			Destroy(gameObject);
		}
	}
}
