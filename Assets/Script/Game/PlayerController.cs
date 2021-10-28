using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_body;
    
    private GameManager m_Game;
    
    private GameObject m_Animator;
    
    private bool gravity = true;

    private bool isGrounded = true;

    private int nbJump;
    
    public bool CanChangeGravity = false;
    
    [Range(0,10)]
    public int MaxJump = 1;
    
    [Range(0,50)]
    public float speed = 5F;

    [Range(0,50)]
    public float jumpSpeed = 8F;

    private void Awake()
    {
        m_body = GetComponent<Rigidbody>();
        m_Game = GameManager.Instance;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_3"))
        {
            MaxJump = 2;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_1") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_2"))
        {
            MaxJump = 1;
        }
        nbJump = MaxJump;
    }

    private void Update()
    {
        if (m_Game.Playing)
        {
            float translationX = Input.GetAxis("Horizontal");
            float translationZ = Input.GetAxis("Vertical");
            
            
            Vector3 translation = new Vector3(translationZ,0, -translationX );
            m_body.AddForce(translation * speed);
            if (Input.GetKeyDown (KeyCode.Space) && (isGrounded || nbJump > 0))
            {
                isGrounded = false;
                m_body.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                nbJump -= 1;
            }
                    
            if (Input.GetKeyDown(KeyCode.G) && CanChangeGravity)
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
        

        if (m_body.transform.position.y < -50)
        {
            m_Game.LooseGame();
        }

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrived")
        {
            m_Game.NextLevel();
        }

        if (collision.gameObject.tag == "Jump")
        {
            Debug.Log("Explosion");
            m_body.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "Tp")
        {
            m_body.transform.position = new Vector3(171,61,0);
        }
        nbJump = MaxJump;
        isGrounded = true;
        
    }
    public void StopMovement()
    {
        m_body.velocity = Vector3.zero;
        
    }
}
