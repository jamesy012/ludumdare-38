using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int m_inhabitantCount = 0;
    private GameObject[] m_inhabitants;
    private bool m_wasPopulated = false;
    // Use this for initialization
    void Start()
    {
      
      m_inhabitants =  GameObject.FindGameObjectsWithTag("Inhabitant");
      m_inhabitantCount = m_inhabitants.Length;
    }


    // Update is called once per frame
    void Update()
    {
        m_inhabitants = GameObject.FindGameObjectsWithTag("Inhabitant");
        m_inhabitantCount = m_inhabitants.Length;

        if(m_inhabitantCount > 0)
        {
            m_wasPopulated = true;
        }

        if(m_inhabitantCount <= 0 && m_wasPopulated)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
