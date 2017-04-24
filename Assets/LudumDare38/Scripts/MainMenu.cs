using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public GameObject[] m_CreditsToggle;
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Endless()
    {
		SceneManager.LoadScene(2);
	}

    public void Credits()
    {
		for(int i = 0; i < m_CreditsToggle.Length; i++) {
			m_CreditsToggle[i].SetActive(!m_CreditsToggle[i].activeInHierarchy);
		}
    }

    public void Exit()
    {
        Application.Quit();
    }
}
