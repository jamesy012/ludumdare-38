using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour {

	public float m_AddedDelay = 0.0f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + m_AddedDelay);
	}
	
}
