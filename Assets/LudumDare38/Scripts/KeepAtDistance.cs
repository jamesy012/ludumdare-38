﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAtDistance : MonoBehaviour {

	public float distance = 2.0f;

	public Transform m_ObjectToOrbit;

	public bool m_UseRotation = true;

	// Update is called once per frame
	void Update () {
		if(m_ObjectToOrbit == null) {
			return;
		}
		Vector3 position;

		if (m_UseRotation) {
			position = getDistancePosition();
		} else {
			position = getDistancePosition(transform.position, m_ObjectToOrbit, distance);
		}

		transform.position = position;
	}

	public Vector3 getDistancePosition() {
		return transform.rotation * (Vector3.up * distance) + m_ObjectToOrbit.position;
	}

	public static Vector3 getDistancePosition(Vector3 a_Position, Transform a_OrbitTransform, float a_Distance) {
		Vector3 difference = a_Position - a_OrbitTransform.position;
		float diff = a_Distance / difference.magnitude;
		return difference * diff;
	}

	public static Vector3 getDistancePosition(Quaternion a_RotationAround, Transform a_OrbitTransform, float a_Distance) {
		return a_RotationAround * (Vector3.up * a_Distance) + a_OrbitTransform.position;
	}

	public static Vector3 getDistancePosition(Transform a_Object, Transform a_OrbitTransform, float a_Distance) {
		return a_Object.rotation * (Vector3.up * a_Distance) + a_OrbitTransform.position;
	}
}
