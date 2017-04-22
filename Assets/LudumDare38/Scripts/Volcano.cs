using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : BaseDisaster
{
    public GameObject m_lavaRock;
    float m_timer = 0.0f;
    public float m_eruptInterval = 2.0f;
    public float m_eruptionForce = 100.0f;
    public float m_eruptionPointOffset = 0.5f;
    public float m_deathHeightOffset = 0.05f;
    public uint m_numOfRocks = 1;
    private Vector3 eruptPosition;

    private float m_heightSunk = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        eruptPosition = this.transform.position + this.transform.up * m_eruptionPointOffset;
        m_timer += Time.deltaTime;

        if(m_timer >= m_eruptInterval)
        {
  
            Erupt();
            m_timer = 0.0f;
        }

        //if grabbed and dragged towards planet
        /*&& m_CurrDistToPlanetPos < m_OldDistToPlanetPos && m_CurrDistToPlanetPos != 0.0f*/
        if (m_grabbed)
        {
           
            this.transform.Translate(-Vector3.up  * Time.deltaTime);
            m_heightSunk += 1 * Time.deltaTime;
        }

        //if passed death threshold self destroy
        if(m_heightSunk >= m_deathHeightOffset)
        {
            SelfDestruct();
        }
    }

    private void Erupt()
    {
        if(m_lavaRock == null)
        {
            return;
        }

        for(uint i = 0; i< m_numOfRocks; ++i)
        {
            //create new lava rock
            GameObject newLavaRock = Instantiate(m_lavaRock, eruptPosition, Quaternion.identity);

            Rigidbody rb = newLavaRock.GetComponent<Rigidbody>();

            Vector3 rockDirection = this.transform.up + Random.Range(-1.0f, 1.0f) * this.transform.right;
            //launch rock
            rb.AddForce(rockDirection.normalized * m_eruptionForce * Time.deltaTime, ForceMode.Impulse);
        }


    }





}
