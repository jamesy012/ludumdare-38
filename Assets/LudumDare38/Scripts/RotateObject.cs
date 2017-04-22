using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	public float m_Speed;
	public Vector3 m_Axis = Vector3.forward;

	public bool m_RandomStartRotation = true;

	void Start() {
		if (m_RandomStartRotation) {
			transform.Rotate(m_Axis * Random.Range(0.0f, 360.0f));
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(m_Axis * m_Speed * Time.deltaTime);
	}
}
