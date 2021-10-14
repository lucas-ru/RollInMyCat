using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_body;
    
    private GameManager m_Game;
    
    private GameObject m_Animator;
    
    private bool gravity = true;
    
    [Range(0,50)]
    public float speed = 5F;

    [Range(0,50)]
    public float jumpSpeed = 8F;

    public int NbJump = 1;
    
    private void Awake()
    {
        m_body = GetComponent<Rigidbody>();
        m_Game = GameManager.Instance;
    }

    private void Update()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationZ = Input.GetAxis("Vertical");


        Vector3 translation = new Vector3(translationZ,0, -translationX );
        m_body.AddForce(translation * speed);
        if (Input.GetKeyDown (KeyCode.Space) && NbJump == 1)
        {
            m_body.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            NbJump -= 1;
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

        if (m_body.transform.position.y < -50)
        {
            m_Game.LooseGame();
        }

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") && NbJump == 0)
        {
            NbJump += 1;
        }   
        
        if (collision.gameObject.CompareTag("Arrived"))
        {
            
        }
        
    }
}
