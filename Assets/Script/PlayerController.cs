using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_body;

    private GameManager m_Game;

    [Range(0,50)]
    public float speed = 5F;

    [Range(0,50)]
    public float jumpSpeed = 8F;
    
    private bool gravity = true;
    
    private void Awake()
    {
        m_body = GetComponent<Rigidbody>();
        m_Game = GameManager.Instance;
    }

    private void Update()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationZ = Input.GetAxis("Vertical");


        Vector3 translation = new Vector3(translationX,0, translationZ );
        m_body.AddForce(translation * speed);

        if (Input.GetKeyDown (KeyCode.Space)){
            m_body.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (gravity)
            {
                m_body.useGravity = false;
                gravity = false;
            }
            else
            {
                m_body.useGravity = true;
                gravity = true;
            }
            
        }

    }
}
