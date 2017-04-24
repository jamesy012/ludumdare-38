using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    private GameManager m_gameManager;
    private Text m_scoreDisplay;
    // Use this for initialization
    void Start()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_scoreDisplay = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_scoreDisplay.text = "Score: " + m_gameManager.m_score.ToString();
    }
}
