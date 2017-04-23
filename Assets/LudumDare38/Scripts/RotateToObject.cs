using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToObject : MonoBehaviour {

	public Transform m_ObjectToCopy;
	public Vector3 m_RotationOffset;

	// Update is called once per frame
	void Update () {
		transform.rotation = m_ObjectToCopy.rotation * Quaternion.Euler(m_RotationOffset);
	}
}
