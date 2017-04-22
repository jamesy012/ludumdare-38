using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ConstantForce))]
public class Gravity : MonoBehaviour
{
    
    private ConstantForce m_gravity;
    // Use this for initialization
    void Start()
    {
        m_gravity = this.GetComponent<ConstantForce>();
    }

    // Update is called once per frame
    void Update()
    {
        m_gravity.force = (Vector3.zero - this.transform.position).normalized;
    }
}
