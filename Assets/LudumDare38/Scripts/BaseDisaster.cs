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


        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    m_grabbed = true;
                }
                else
                {
                    m_grabbed = false;
                }
            }
        }
            
     
        //if(mousePos)
    }

    //for this to work the object must have a trigger collider



}
