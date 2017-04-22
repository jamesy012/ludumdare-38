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
    public float m_scaleIntervalDenominator = 10.0f;
    public uint m_numOfRocks = 1;
    private Vector3 eruptPosition;
    private float m_scaleInterval = 0.0f;

    // Use this for initialization
    void Start()
    {

        m_scaleInterval = this.transform.localScale.y / m_scaleIntervalDenominator;
        //get peak of collider;
        eruptPosition = this.transform.position + this.transform.up * m_eruptionPointOffset;
    }

    // Update is called once per frame
    void Update()
    {
        eruptPosition = this.transform.position + this.transform.up * m_eruptionPointOffset;
        m_timer += Time.deltaTime;

        if(m_timer >= m_eruptInterval)
        {
            Squash(m_scaleInterval);
            Erupt();
            m_timer = 0.0f;
        }

        if(this.transform.localScale.y <= 0.0f)
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

            Rigidbody2D rb = newLavaRock.GetComponent<Rigidbody2D>();

            Vector3 rockDirection = this.transform.up + Random.Range(-1.0f, 1.0f) * this.transform.right;
            //launch rock
            rb.AddForce(rockDirection * m_eruptionForce * Time.deltaTime, ForceMode2D.Impulse);
        }


    }



    private void Squash(float a_sqaushAmount)
    {
        this.transform.localScale -= this.transform.up * a_sqaushAmount;
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
