using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowTimeSurvived : MonoBehaviour
{
    private GameManager m_gameManager;
    private Text m_timeDisplay;
    // Use this for initialization
    void Start()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_timeDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timeDisplay.text = "Time Survived: " + ((int)m_gameManager.m_timeSurvived).ToString() + "s";
    }
}
