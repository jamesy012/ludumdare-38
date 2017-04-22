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
    public uint m_numOfRocks = 1;
    private Vector3 eruptPosition;
    // Use this for initialization
    void Start()
    {
        
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
            Squash(1);
            Erupt();
            m_timer = 0.0f;
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
            GameObject newLavaRock = Instantiate(m_lavaRock, eruptPosition, Quaternion.identity, this.transform);

            Rigidbody2D rb = newLavaRock.GetComponent<Rigidbody2D>();

            Vector3 rockDirection = this.transform.up + Random.Range(-1.0f, 1.0f) * this.transform.right;
            //launch rock
            rb.AddForce(rockDirection * m_eruptionForce * Time.deltaTime, ForceMode2D.Impulse);
        }


    }



    private void Squash(float a_sqaushAmount)
    {
        this.transform.localScale -= this.transform.up * a_sqaushAmount;
        this.transform.localPosition -= this.transform.up * Time.deltaTime;
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
