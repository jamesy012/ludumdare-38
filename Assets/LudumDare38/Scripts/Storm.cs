using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : BaseDisaster
{
    public float m_orbitSpeed = 10.0f;
    public float m_deathHeightOffset = 0.5f;
    private float m_heightRisen = 0.0f;

	public bool m_MoveRight = false;

    // Use this for initialization
    void Start()
    {
		if(Random.Range(0,100) > 50) {
			m_MoveRight = true;
		}
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
		float speed = m_orbitSpeed * Time.deltaTime;
		if (m_MoveRight) {
			speed *= -1;
		}
        this.transform.RotateAround(Vector3.zero, Vector3.forward, speed);
    }



}
