using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudioIfMute : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameManager.m_Muted) {
			Destroy(GetComponent<AudioSource>());
		}
		Destroy(this);
	}
}
