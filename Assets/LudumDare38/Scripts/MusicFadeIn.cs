using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeIn : MonoBehaviour {

	private AudioSource m_As;

	public float m_FadeInTime = 1.0f;

	public float m_FadeToVolume = 1.0f;

	private float m_CurrentVolume = 0;

	private float m_StartTime;

	// Use this for initialization
	void Start () {
		m_As = GetComponent<AudioSource>();

		if(m_As == null) {
			Debug.LogWarning("There is no AudioSource to modify in object " + transform.name);
			Destroy(this);//destroy this script
			return;
		}
		
		m_As.volume = m_CurrentVolume;
		m_StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float time = (Time.time - m_StartTime) / m_FadeInTime;

		m_As.volume = Mathf.Lerp(m_CurrentVolume, m_FadeToVolume, time);

		if (time >= 1) {
			Destroy(this);
		}
	}
}
