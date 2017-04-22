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
	protected Vector2 m_DownClickPosition;
	/// <summary>
	/// position where the user clicked
	/// </summary>
	protected Vector2 m_DownStartPosition;

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

		m_DownClickPosition = getCurrentClickPosition();
		m_DownStartPosition = transform.position;

		clicked();
    }

    private void OnMouseUp()
    {
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
