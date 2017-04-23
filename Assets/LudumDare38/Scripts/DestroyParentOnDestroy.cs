using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentOnDestroy : MonoBehaviour {

	public void OnDestroy() {
		Destroy(transform.parent.gameObject);
	}

}
