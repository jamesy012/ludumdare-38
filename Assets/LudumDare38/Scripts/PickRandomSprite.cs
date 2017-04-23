using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRandomSprite : MonoBehaviour {


	public Sprite[] m_Sprites;

	private SpriteRenderer m_Sr;

	// Use this for initialization
	void OnEnable () {

		m_Sr = GetComponent<SpriteRenderer>();

		if(m_Sr == null) {
			Debug.LogWarning("No SpriteRenderer " + transform.name);
			return;
		}
		if (m_Sprites.Length == 0) {
			Debug.LogWarning("No sprites " + transform.name);
			return;
		}

		m_Sr.sprite = m_Sprites[Random.Range(0,m_Sprites.Length)];

		//destroy this script
		Destroy(this);

	}
}
