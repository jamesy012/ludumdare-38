using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDisaster : MonoBehaviour
{
 
    //protected Collider m_collider;
    //protected Rigidbody m_rigidBody;

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
       
     
    }

    // Update is called once per frame
    void Update()
    {
        


    }


	//danm functions have a range limit
	//might need to change to ray cast, then check if it has this component
	//and call clicked()

    private void OnMouseDown()
    {
        clicked();
    }

    private void OnMouseDrag()
    {
		drag();  
    }

    private void OnMouseUp()
    {
		released();
    }

	protected virtual void clicked() {
		m_grabbed = true;

		m_OldMousePosition = m_CurrMousePosition;
		m_CurrMousePosition = getCurrentClickPosition();
		m_DownStartPosition = transform.position;

	}


	protected virtual void drag() {
		m_OldDistToPlanetPos = m_CurrDistToPlanetPos;
		m_OldMousePosition = m_CurrMousePosition;

		m_CurrMousePosition = getCurrentClickPosition();
		m_CurrDistToPlanetPos = Mathf.Abs(Vector2.Distance(Vector3.zero, m_CurrMousePosition));
	}


	protected virtual void released() {
		m_OldDistToPlanetPos = 0.0f;
		m_CurrDistToPlanetPos = 0.0f;
		m_grabbed = false;
	}


	protected virtual void SelfDestruct()
    {
		//Destroy(this.gameObject);
		Destroy(this);
		gameObject.AddComponent<FadeOutDestroy>();
    }

    protected Vector2 getCurrentClickPosition() {
		//might need to be different for phone
		//also might want to convert to world coord instead of screen coord?
		return Input.mousePosition;
	}
    

}
