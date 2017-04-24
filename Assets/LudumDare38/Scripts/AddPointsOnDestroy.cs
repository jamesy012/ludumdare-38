using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPointsOnDestroy : MonoBehaviour
{
    public int m_scoreAdded = 0;
    private GameManager m_gameManager;
    // Use this for initialization
    void Start()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
		if(m_gameManager == null) {
			return;
		}
        m_gameManager.addScore(m_scoreAdded);
    }
}
