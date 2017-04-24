using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhabitantBehavior : MonoBehaviour {

	public float m_walkSpeed = 5.0f;
	/// <summary>
	/// how much speed will be randomly taken or added 
	/// </summary>
	public float m_WalkSpeedDeviation = 2.5f;

	private bool m_MoveRight = true;

	public float m_StandStillTimer = 0;

	/// <summary>
	/// every frame out of 1000, will check if the inhabitant should change direction
	/// </summary>
	[Range(0, 1000)]
	public float m_ChanceToChangeDirection = 1f;
	[Range(0, 1000)]
	public float m_ChanceToStandStill = 2f;

	// Use this for initialization
	void Start() {
		//random chance to walk other way
		if (Random.Range(0, 2) == 0) {
			m_MoveRight = false;
		}

		m_WalkSpeedDeviation = Random.Range(-m_WalkSpeedDeviation, m_WalkSpeedDeviation);
	}

	// Update is called once per frame
	void Update() {
		if (m_StandStillTimer < 0) {
			Walk();
			//random chance to change direction
			if (Random.Range(0, 1000) <= m_ChanceToChangeDirection) {
				m_MoveRight = !m_MoveRight;
			}
			if (Random.Range(0, 1000) <= m_ChanceToStandStill) {
				m_StandStillTimer = Random.Range(0.0f, 5.0f);
			}
		} else {
			m_StandStillTimer -= Time.deltaTime;
		}





	}

	private void Walk() {
		float speed = (m_walkSpeed + m_WalkSpeedDeviation) * Time.deltaTime;
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
		print("cc " + collision.transform.name);
		if (collision.gameObject.CompareTag("Disaster")) {
			print("zz");
			GameObject.Destroy(this.gameObject);
		}
	}


}
