using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhabitantBehavior : MonoBehaviour {

	public float m_walkSpeed = 5.0f;

	private bool m_MoveRight = true;

	/// <summary>
	/// every frame out of 1000, will check if the inhabitant should change direction
	/// </summary>
	[Range(0,1000)]
	public float m_ChanceToChangeDirection = 0.1f;

	// Use this for initialization
	void Start() {
		//random chance to walk other way
		if (Random.Range(0, 2) == 0) {
			m_MoveRight = false;
		}
	}

	// Update is called once per frame
	void Update() {
		Walk();

		//random chance to change direction
		if (Random.Range(0, 1000) <= m_ChanceToChangeDirection) {
			m_MoveRight = !m_MoveRight;
		}

	}

	private void Walk() {
		float speed = m_walkSpeed * Time.deltaTime;
		if (m_MoveRight) {
			speed *= -1;
		}
		this.transform.RotateAround(Vector3.zero, Vector3.forward, speed);


	}

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Disaster")) {
			GameObject.Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Disaster")) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
