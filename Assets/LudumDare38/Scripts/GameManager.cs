using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Transform m_InhabiantTransform;
    private bool m_wasPopulated = false;
	private bool m_HitGameOver = false;

	private string m_InhabitantTransformHolderName = "Inhabitants";

	/// <summary>
	/// list of objects to disable on game over
	/// </summary>
	public GameObject[] m_ObjectToToggleOnGameOver;

	private PickRandomSong m_RandomSongSelection;

	// Use this for initialization
	void Start()
    {

		m_InhabiantTransform = GameObject.Find(m_InhabitantTransformHolderName).transform;

		if(m_InhabiantTransform == null) {
			Debug.LogError("CANT FIND TRANSFORM CALLED " + m_InhabitantTransformHolderName);
		}

		m_RandomSongSelection = transform.GetComponentInChildren<PickRandomSong>();

		setUpGame();
	}


    // Update is called once per frame
    void Update()
    {
		if (m_HitGameOver) {
			return;
		}
		if(m_InhabiantTransform == null) {
			return;
		}
		//print("1");
		if (m_wasPopulated) {
			//print("2");
			if (m_InhabiantTransform.childCount == 0) {
				//print("3");
				finishGame();
				
			}
		} else {
			//print("4");
			if (m_InhabiantTransform.childCount != 0) {
				//print("5");
				m_wasPopulated = true;
			}
		}
    }

    public void finishGame()
    {
		m_HitGameOver = true;
        Debug.Log("GAME OVER");
		toggleObjects();
    }

	public void startGame() {
		print("Game Start");
		toggleObjects();
		setUpGame();
	}

	private void setUpGame() {
		m_HitGameOver = false;
		m_wasPopulated = false;

		m_RandomSongSelection.pickRandomSong();

		for (int i = 0; i < m_InhabiantTransform.childCount; i++) {
			Transform child = m_InhabiantTransform.GetChild(i);


			//the object are still around by the time, two update() run after the game starts
			//so just remove them from the transform so they wont get counted in our calculations
			child.parent = null;

			Destroy(child.gameObject);

		}

		GameObject[] m_DisasterTransforms = GameObject.FindGameObjectsWithTag("Disaster");
		for (int i = 0; i < m_DisasterTransforms.Length; i++) {
			Destroy(m_DisasterTransforms[i]);
		}
	}

	private void toggleObjects() {
		for(int i = 0; i < m_ObjectToToggleOnGameOver.Length; i++) {
			m_ObjectToToggleOnGameOver[i].SetActive(!m_ObjectToToggleOnGameOver[i].activeInHierarchy);
		}
	}
}
