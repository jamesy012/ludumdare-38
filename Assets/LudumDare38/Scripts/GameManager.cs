using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Transform m_InhabiantTransform;
    private bool m_wasPopulated = false;
	private bool m_HitGameOver = false;

	private string m_InhabitantTransformHolderName = "Inhabitants";
    public float m_timeSurvived = 0.0f;
	/// <summary>
	/// list of objects to disable on game over
	/// </summary>
	public GameObject[] m_ObjectToToggleOnGameOver;

	private PickRandomSong m_RandomSongSelection;

	public bool m_EndlessMode = false;

	public GameObject[] m_ObjectsToToggleOnPause;
	public static bool m_Paused = false;
	public static bool m_Muted = false;

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
		if (m_EndlessMode) {
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

        m_timeSurvived += Time.deltaTime;
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

    public void exitGame()
    {
        Application.Quit();
    }

	private void setUpGame() {
		m_HitGameOver = false;
		m_wasPopulated = false;
        m_timeSurvived = 0.0f;
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

	public void pause() {
		if (m_Paused) {
			Time.timeScale = 1.0f;
		} else {
			Time.timeScale = 0.0f;
		}
		for (int i = 0; i < m_ObjectsToToggleOnPause.Length; i++) {
			m_ObjectsToToggleOnPause[i].SetActive(!m_ObjectsToToggleOnPause[i].activeInHierarchy);
		}
		m_Paused = !m_Paused;
	}

	public void muteButton() {
		if (m_Muted) {
			GetComponentInChildren<AudioSource>().UnPause();
		} else {
			GetComponentInChildren<AudioSource>().Pause();
		}
		m_Muted = !m_Muted;
	}

	public void loadMainMenu() {
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
