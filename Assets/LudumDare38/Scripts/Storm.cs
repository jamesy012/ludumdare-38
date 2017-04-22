using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : BaseDisaster
{
    public float m_orbitSpeed = 10.0f;
    public float m_deathHeightOffset = 0.5f;
    private float m_heightRisen = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        Orbit();
        InhabitantCheck();

        //if dragged outwards from planet
        /*&& m_CurrDistToPlanetPos > m_OldDistToPlanetPos && m_OldDistToPlanetPos != 0.0f*/
        if (m_grabbed )
        {
            float distance = m_CurrDistToPlanetPos - m_OldDistToPlanetPos;
            this.transform.Translate(Vector3.up  * Time.deltaTime);
            m_heightRisen += 1 * Time.deltaTime;
        }

        //if passed death threshold self destroy
        if (m_heightRisen >= m_deathHeightOffset)
        {
            SelfDestruct();
        }
    }


    private void LightningBolt()
    {
        //kill inhabitant
    }

    private void InhabitantCheck()
    {
        RaycastHit hit;
        Debug.DrawRay(this.transform.position, -this.transform.up, Color.blue);
        if (Physics.Raycast(transform.position, -this.transform.up, out hit, 10.0f))
        {
            if(hit.collider.CompareTag("Inhabitant"))
            {
                LightningBolt();
                GameObject.Destroy(hit.collider.gameObject);
            }
        }
            
    }

    //orbit planet
    private void Orbit()
    {
        this.transform.RotateAround(Vector3.zero, Vector3.forward, m_orbitSpeed*Time.deltaTime);
    }



}
