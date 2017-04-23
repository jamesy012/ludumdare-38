using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSizeDestroy : MonoBehaviour {

	/// <summary>
	/// how long in seconds will this object take to fade out
	/// </summary>
	public float m_TimeTakenToFadeOut = 1.0f;

	/// <summary>
	/// start time of the script
	/// </summary>
	private float m_StartTime;

	private Vector3 m_StartSize;
	private Vector3 m_DesiredSize;


	// Use this for initialization
	void Start () {

		m_StartTime = Time.time;

		m_StartSize = transform.localScale;
		m_DesiredSize = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		float time = (Time.time - m_StartTime) / m_TimeTakenToFadeOut;

		transform.localScale = Vector3.Lerp(m_StartSize, m_DesiredSize, time);

		if (time >= 1) {
			Destroy(gameObject);
		}
	}
}
