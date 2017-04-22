using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour {

	/// <summary>
	/// which layer to react to
	/// </summary>
	public LayerMask m_DestroyAfterHit;

	public void OnCollisionEnter(Collision collision) {
		//bit shift 1 by layer number(0,31) to get 00100000 which is whats stored in LayerMask.value
		if ((1 << collision.gameObject.layer & m_DestroyAfterHit.value) > 0) {
			//todo change it so it will start losing size, then when small enough it destroys the object
			Destroy(gameObject);
		}
	}


}
