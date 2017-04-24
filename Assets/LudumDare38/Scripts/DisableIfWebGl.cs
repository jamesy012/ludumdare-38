using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfWebGl : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if UNITY_WEBGL
		gameObject.SetActive(false);		
#endif
	}
}
