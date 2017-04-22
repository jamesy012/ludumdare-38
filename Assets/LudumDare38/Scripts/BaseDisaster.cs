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
	protected Vector2 m_CurrMousePosition;

    /// <summary>
    /// prev mouse position
    /// </summary>
    protected Vector2 m_OldMousePosition;

    /// <summary>
    /// position where the user clicked
    /// </summary>
    protected Vector2 m_DownStartPosition;

    /// <summary>
    /// Distance to Planet
    /// </summary>
    public float m_CurrDistToPlanetPos = 0.0f;

    /// <summary>
    /// Prev distance to planet
    /// </summary>
    public float m_OldDistToPlanetPos = 0.0f;

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



        m_OldMousePosition = getCurrentClickPosition();
        m_CurrMousePosition = getCurrentClickPosition();
        m_DownStartPosition = transform.position;
        m_CurrDistToPlanetPos = Vector2.Distance(Vector3.zero, m_CurrMousePosition);



        clicked();
    }

    private void OnMouseDrag()
    {
        m_OldDistToPlanetPos = m_CurrDistToPlanetPos;
        m_OldMousePosition = m_CurrMousePosition;

        m_CurrMousePosition = getCurrentClickPosition();
        m_CurrDistToPlanetPos = Vector2.Distance(Vector3.zero, m_CurrMousePosition);

  
    }

    private void OnMouseUp()
    {

        m_OldDistToPlanetPos = 0.0f;
        m_CurrDistToPlanetPos = 0.0f;
        m_grabbed = false;
    }

	protected virtual void clicked() {

	}

	protected Vector2 getCurrentClickPosition() {
		//might need to be different for phone
		//also might want to convert to world coord instead of screen coord?
		return Input.mousePosition;
	}
    

}
