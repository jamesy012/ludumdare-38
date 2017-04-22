using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : BaseDisaster
{
    public float m_deathHeightOffset = 0.5f;
    private float m_heightRisen = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if dragged outwards from planet
        if (m_grabbed && m_CurrDistToPlanetPos > m_OldDistToPlanetPos && m_OldDistToPlanetPos != 0.0f)
        {
            float distance = m_CurrDistToPlanetPos - m_OldDistToPlanetPos;
            this.transform.Translate(this.transform.up * distance * Time.deltaTime);
            m_heightRisen += distance * Time.deltaTime;
        }

        //if passed death threshold self destroy
        if (m_heightRisen >= m_deathHeightOffset)
        {
            SelfDestruct();
        }
    }


}
