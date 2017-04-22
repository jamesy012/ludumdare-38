using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDisaster : MonoBehaviour
{
 
    protected Collider2D m_collider;
    protected Rigidbody2D m_rigidBody;

	/// <summary>
	/// position where the user clicked
	/// </summary>
	protected Vector3 m_CurrMousePosition;

    /// <summary>
    /// prev mouse position
    /// </summary>
    protected Vector3 m_OldMousePosition;

    /// <summary>
    /// position where the user clicked
    /// </summary>
    protected Vector3 m_DownStartPosition;

    /// <summary>
    /// Distance to Planet
    /// </summary>
    public float m_CurrDistToPlanetPos = 0.0f;

    /// <summary>
    /// Prev distance to planet
    /// </summary>
    public float m_OldDistToPlanetPos = 0.0f;

    /// <summary>
    /// Drag direction
    /// </summary>
    protected Vector3 dragDirection;

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



      
       
        m_DownStartPosition = transform.position;




        clicked();
    }

    private void OnMouseDrag()
    {
        m_CurrMousePosition = getCurrentClickPosition();

        dragDirection = (m_DownStartPosition - m_CurrMousePosition).normalized;
  
    }

    private void OnMouseUp()
    {

        dragDirection = Vector3.zero;
        m_grabbed = false;
    }

	protected virtual void clicked() {

	}


    protected void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    protected Vector3 getCurrentClickPosition() {
		//might need to be different for phone
		//also might want to convert to world coord instead of screen coord?
		return Input.mousePosition;
	}
    

}
