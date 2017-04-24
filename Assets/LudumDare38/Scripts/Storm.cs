using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : Clouds
{


    public float m_deathHeightOffset = 0.5f;
    private float m_heightRisen = 0.0f;
	private float m_StartHeight;


	//lightning
	public float m_HitCooldown = 4;
	private float m_LastHit;
	public GameObject m_LightingBolt;

	[Range(0,1000)]
	public float m_RandomChanceToSpawnLightning = 0.1f;

	//flicking

	private float m_ClickTime = 0;
	public float m_MaxHoldTime = 0.3f;

	private Vector2 m_ClickPos;
	private bool m_HasBeenFlicked = false;
	/// <summary>
	/// treat as Vector2
	/// </summary>
	private Vector3 m_FlickDirection;

	//start


	// Use this for initialization
	protected override void Start()
    {
		base.Start();

		//start cooldown from spawn time
		//m_LastHit = Time.time;

		m_StartHeight = getHeight();
	}

    // Update is called once per frame
    protected override void Update()
    {
		Orbit();
		moveUpDown();     
		if (Time.time > m_LastHit + m_HitCooldown) {

			if (Random.Range(0, 1000) <= m_RandomChanceToSpawnLightning) {
				LightningBolt();
			} else {//else do the normal check
				InhabitantCheck();
			}
		}

		//if dragged outwards from planet
		if (m_HasBeenFlicked) {
			Vector3 pos = transform.position;
			pos += m_FlickDirection * Time.deltaTime;
			transform.position = pos;
		} else {
			if (m_grabbed) {
				//limit amount of time for click
				if (Time.time > m_ClickTime + m_MaxHoldTime) {
					m_ClickTime = Time.time - m_MaxHoldTime;//make the time calculation = 0
					checkIfFlick();
				}
			}
		}
    }

	protected override void clicked() {
		base.clicked();
		m_ClickTime = Time.time;
		m_ClickPos = getWorldPosOfMouse();
	}

	public void OnMouseExit() {
		if (m_grabbed) {

			checkIfFlick();
		}
	}

	private void checkIfFlick() {
		Vector2 mousePos = getWorldPosOfMouse();

		float startToCenter = Vector3.Distance(m_ClickPos, Vector3.zero);
		float endToCenter = Vector3.Distance(mousePos, Vector3.zero);

		if(endToCenter > startToCenter) {
			m_FlickDirection = mousePos - m_ClickPos;
			m_FlickDirection.z = 0;
			m_HasBeenFlicked = true;
			gameObject.AddComponent<FadeOutDestroy>();
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
