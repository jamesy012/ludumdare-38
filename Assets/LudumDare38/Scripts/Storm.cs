using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : Clouds
{


    public float m_deathHeightOffset = 0.5f;
    private float m_heightRisen = 0.0f;

	public float m_HitCooldown = 4;
	private float m_LastHit;

	public GameObject m_LightingBolt;

	private float m_StartHeight;


    // Use this for initialization
    protected override void Start()
    {
		base.Start();

		//start cooldown from spawn time
		m_LastHit = Time.time;

		m_StartHeight = getHeight();
	}

    // Update is called once per frame
    protected override void Update()
    {
		Orbit();
		moveUpDown();     
		if (Time.time > m_LastHit + m_HitCooldown) {
			InhabitantCheck();
		}

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
		m_LastHit = Time.time;

		if(m_LightingBolt != null) {
			GameObject go = Instantiate(m_LightingBolt);
			go.transform.parent = transform;
			go.transform.position = transform.position;
			go.transform.rotation = transform.rotation;
			Vector3 scale = go.transform.GetChild(1).localScale;
			scale.y = getHeight() / m_StartHeight;
			go.transform.GetChild(1).localScale = scale;
		}
	}

    private void InhabitantCheck()
    {
        RaycastHit hit;
        Debug.DrawRay(this.transform.position, -this.transform.up * 10.0f, Color.blue);

		int layerMask = 0;
		layerMask = -LayerMask.NameToLayer("Inhabitant");

        if (Physics.Raycast(transform.position, -this.transform.up, out hit, 10.0f, layerMask))
        {
            if(hit.collider.CompareTag("Inhabitant"))
            {
				


				LightningBolt();
                //GameObject.Destroy(hit.collider.gameObject);
            }
        }
            
    }

}
