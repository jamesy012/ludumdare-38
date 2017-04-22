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

	/// <summary>
	/// picks a random number between these two numbers
	/// </summary>
	public float m_MinTimer, m_MaxTimer;

	/// <summary>
	/// random value between m_MinTimer and m_MaxTimer
	/// </summary>
	private float m_SpawnTime;

	/// <summary>
	/// distance at which to spawn at
	/// </summary>
	public float m_SpawnDistance;

	/// <summary>
	/// time of last spawn
	/// </summary>
	private float m_LastSpawnTime;

	// Use this for initialization
	void Start() {
		if (m_MinTimer >= m_MaxTimer) {
			Debug.LogWarning("Min timer is higher then max timer in Spawner " + transform.name);
		}

		updateLastSpawn();
	}

	// Update is called once per frame
	void Update() {
		if (checkSpawn()) {
			spawnObject();
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

	/// <summary>
	/// spawns the object
	/// with a random rotation and direction
	/// at the specified distance
	/// </summary>
	public void spawnObject() {

		int objectIndex = Random.Range(0, m_ObjectsToSpwan.Length);
		float spawnRotation = Random.Range(0.0f, 360.0f);
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

		m_SpawnTime = Random.Range(m_MinTimer, m_MaxTimer);
	}
}
