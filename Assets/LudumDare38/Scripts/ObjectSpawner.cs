using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	/// <summary>
	/// list of objects to spawn
	/// </summary>
	public GameObject[] m_ObjectsToSpwan;

	/// <summary>
	/// possible transform for the parent of all objects spawned
	/// just to clean up the hierarchy
	/// </summary>
	public Transform m_ParentTransform;

	[Header("__Timers")]
	/// <summary>
	/// amount of time it will take to get from m_Starting timers to m_Desired Timers
	/// </summary>
	public float m_TimeToGetToDesiredTimers = 180.0f;

	/// <summary>
	/// min times for spawning
	/// these are the starting values for minmax
	/// </summary>
	public float m_StartingMinTimer, m_StartingMaxTimer;
	/// <summary>
	/// max times for spawning
	/// these are the quickened times
	/// the min/max timer will be this after 
	/// </summary>
	public float m_DesiredMinTimer, m_DesiredMaxTimer;

	/// <summary>
	/// starting time of script
	/// </summary>
	private float m_StartTime;

	/// <summary>
	/// a flag to check if the min and max timers have hit their end
	/// </summary>
	private bool m_HitEndOfSpawnSpeedTimer = false;

	/// <summary>
	/// picks a random number between these two numbers
	/// updated to be the lerp between the other 4 min/max variables
	/// </summary>
	//[SerializeField] // show in inspector
	private float m_MinTimer, m_MaxTimer;

	/// <summary>
	/// random value between m_MinTimer and m_MaxTimer
	/// </summary>
	private float m_SpawnTime;

	[Header("__Spawn Options")]

	/// <summary>
	/// distance at which to spawn at
	/// </summary>
	public float m_SpawnDistance;

	/// <summary>
	/// time of last spawn
	/// </summary>
	private float m_LastSpawnTime;

	/// <summary>
	/// a counter that wont spawn a new 
	/// </summary>
	public uint m_MaxAmountSpawned = 0;

	// Use this for initialization
	void Start() {

	}

	public void OnEnable() {
		if(m_ParentTransform != null) {
			for(int i = 0; i < m_ParentTransform.childCount; i++) {
				Destroy(m_ParentTransform.GetChild(i).gameObject);
			}
		}

		if (m_StartingMinTimer >= m_StartingMaxTimer || m_DesiredMinTimer >= m_DesiredMaxTimer) {
			Debug.LogWarning("Min timer is higher then max timer in Spawner " + transform.name);
		}


		//set up spawn timers
		if (m_StartingMaxTimer == 0 || m_StartingMaxTimer == 0 || m_DesiredMinTimer == 0 || m_DesiredMinTimer == 0) {
			Debug.LogWarning("One of the timers, min or max times are not set, using defaults. " + transform.name);
			m_HitEndOfSpawnSpeedTimer = true;
			m_MinTimer = 5;
			m_MaxTimer = 10;
		}

		m_StartTime = Time.time;
		updateMinMax();

		//set up next spawn
		updateLastSpawn();

		//let it spawn from the start of play
		m_SpawnTime = UnityEngine.Random.Range(0, m_MaxTimer);
	}

	private void updateMinMax() {
		if (m_HitEndOfSpawnSpeedTimer) {
			return;
		}
		float time = (Time.time - m_StartTime) / m_TimeToGetToDesiredTimers;

		m_MinTimer = Mathf.Lerp(m_StartingMinTimer, m_DesiredMinTimer, time);
		m_MaxTimer = Mathf.Lerp(m_StartingMaxTimer, m_DesiredMaxTimer, time);

		if (time > 1) {
			m_HitEndOfSpawnSpeedTimer = true;
		}

	}

	// Update is called once per frame
	void Update() {
		if (checkSpawn()) {
			if (hasSpawnSlot()) {
				spawnObject();
			}
			updateMinMax();
			updateLastSpawn();
		}
	}

	/// <summary>
	/// checks to see if there has been enough time between spawns
	/// </summary>
	/// <returns></returns>
	public bool checkSpawn() {
		//if last spawn + spawn time is less then time
		//then you can spawn
		if (m_LastSpawnTime + m_SpawnTime < Time.time) {

			return true;
		}
		return false;
	}

	public bool hasSpawnSlot() {
		if (m_ParentTransform != null && m_MaxAmountSpawned != 0) {
			//if the max number of spawn able objects is more then the amount of children in the parent transform
			if (m_MaxAmountSpawned > m_ParentTransform.childCount) {
				return true;
			} else {
				return false;
			}

		} else {
			return true;
		}
	}

	/// <summary>
	/// spawns the object
	/// with a random rotation and direction
	/// at the specified distance
	/// </summary>
	public void spawnObject() {

		int objectIndex = UnityEngine.Random.Range(0, m_ObjectsToSpwan.Length);
		float spawnRotation = UnityEngine.Random.Range(0.0f, 360.0f);
		Quaternion rotation = Quaternion.Euler(0, 0, spawnRotation);

		GameObject go = Instantiate(m_ObjectsToSpwan[objectIndex]);
		go.transform.position = transform.position + (rotation * new Vector3(0, m_SpawnDistance, 0));
		go.transform.rotation = rotation;

		go.transform.parent = m_ParentTransform;


	}

	/// <summary>
	/// updates the LastSpawnTime and also updates the random SpawnTime
	/// </summary>
	public void updateLastSpawn() {
		m_LastSpawnTime = Time.time;

		m_SpawnTime = UnityEngine.Random.Range(m_MinTimer, m_MaxTimer);
	}

	public void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;

		for (int i = 0; i < 8; i++) {
			float rot = (i / 8.0f) * 360.0f;
			Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, rot));
			Gizmos.DrawSphere(rotation * Vector3.up * m_SpawnDistance, 0.25f);
		}
	}
}
