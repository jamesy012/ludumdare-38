using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhabitantBehavior : MonoBehaviour
{
   
    public float m_walkSpeed = 5.0f; 
    // Use this for initialization
    void Start()
    {
        //random chance to walk other way
       if(Random.Range(0,2) == 1)
        {
            m_walkSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        this.transform.RotateAround(Vector3.zero, Vector3.forward, m_walkSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Disaster"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
