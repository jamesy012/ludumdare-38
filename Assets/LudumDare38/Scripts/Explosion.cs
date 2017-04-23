using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float m_explosionDuration = 0.5f;
    private float m_timer = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;

        if(m_timer >= m_explosionDuration)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Inhabitant"))
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
