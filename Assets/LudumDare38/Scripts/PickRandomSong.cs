using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRandomSong : MonoBehaviour {

	public AudioClip[] m_MusicClips;
	AudioSource m_As;

	// Use this for initialization
	void OnEnable() {
		m_As = GetComponent<AudioSource>();

		if (m_As == null) {
			Destroy(this);
			return;
		}

		pickRandomSong();

	}

	public void Update() {
		if (!m_As.isPlaying) {
			pickRandomSong();
		}
	}

	private void pickRandomSong() {
		m_As.clip = m_MusicClips[UnityEngine.Random.Range(0, m_MusicClips.Length)];
		m_As.Play();
	}
}
