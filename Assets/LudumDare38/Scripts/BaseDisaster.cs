using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDisaster : MonoBehaviour
{
    private Collider2D m_collider;
    private Rigidbody2D m_rigidBody;
    public bool m_grabbed = false;
    // Use this for initialization
    void Start()
    {
        m_collider = this.GetComponent<Collider2D>();
        m_rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnMouseDown()
    {
        m_grabbed = true;

    }

    private void OnMouseUp()
    {
        m_grabbed = false;
    }

   

    

}
