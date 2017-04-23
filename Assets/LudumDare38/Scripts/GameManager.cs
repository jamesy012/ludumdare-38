using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Transform m_InhabiantTransform;
    private bool m_wasPopulated = false;
	private bool m_HitGameOver = false;

	private string m_InhabitantTransformHolderName = "Inhabitants";
	// Use this for initialization
	void Start()
    {

		m_InhabiantTransform = GameObject.Find(m_InhabitantTransformHolderName).transform;

		if(m_InhabiantTransform == null) {
			Debug.LogError("CANT FIND TRANSFORM CALLED " + m_InhabitantTransformHolderName);
		}

	}


    // Update is called once per frame
    void Update()
    {
		if(m_InhabiantTransform == null) {
			return;
		}

		if (m_wasPopulated) {
			if(m_InhabiantTransform.childCount == 0) {
				if (!m_HitGameOver) {
					GameOver();
				}
			}
		} else {
			if(m_InhabiantTransform.childCount != 0) {
				m_wasPopulated = true;
			}
		}
    }

    private void GameOver()
    {
		m_HitGameOver = true;
        Debug.Log("GAME OVER");
    }
}
