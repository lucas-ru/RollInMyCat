using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_body;

    public GameObject m_NianCatImage;
    
    public Vector3 startposition;
    
    private GameManager m_Game;
    
    private GameObject m_Animator;

    private GameObject MyBall;
    
    
    
    private bool gravity = true;
    
    private float gravityValue = 14f;
    
    private float JumpForce = 8.0f;

    private bool isGrounded = true;
    
    private int nbJump;

    private Vector3 lastPosition = Vector3.zero;
    
    public float actualspeed;

    public Vector3 currentDirection;
    
    
    public bool CanChangeGravity = false;
    
    [Range(0,10)]
    public int MaxJump = 1;
    
    [Range(0,50)]
    public float speed = 5F;

    [Range(0,50)]
    public float jumpSpeed = 8F;
    
    
    
    private string DIFFICULTY = "Difficulty";
    private int Difficulty
    {
        get => PlayerPrefs.GetInt(DIFFICULTY,1);
    }

    private void Awake()
    {
        m_Game = GameManager.Instance;
        
        m_body = GetComponent<Rigidbody>();
        startposition = m_body.transform.position;
        MyBall = GameObject.FindGameObjectsWithTag("Player")[0];
        Physics.gravity = new Vector3(0, -gravityValue, 0);
        m_NianCatImage = GameObject.FindGameObjectsWithTag("NianCat")[0];
        m_NianCatImage.transform.rotation = Quaternion.Euler(0,0,0);
        m_NianCatImage.transform.position = MyBall.transform.position;
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_3"))
        {
            MaxJump = 2;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_1") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_2"))
        {
            MaxJump = 1;
        }
        LoadDifficulty();
        nbJump = MaxJump;
    }

    private void Update()
    {
        actualspeed = (transform.position - lastPosition).magnitude / Time.fixedDeltaTime;
        m_NianCatImage.transform.position = MyBall.transform.position;
        currentDirection = (transform.position-lastPosition).normalized;
        
        if (m_Game.Playing)
        {
            float translationX = Input.GetAxis("Horizontal");
            float translationZ = Input.GetAxis("Vertical");
            
            
            Vector3 translation = new Vector3(translationZ,0, -translationX );


            m_body.AddForce(translation * speed);

            if (Input.GetKeyDown (KeyCode.Space) && (isGrounded || nbJump > 0))
            {
                
                isGrounded = false;
                nbJump -= 1;
                if (Difficulty==1)
                {
                    Vector3 Jump = new Vector3(0, JumpForce, 0);
                    m_body.velocity = Jump;
                }
                else
                {
                    m_body.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                }
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

    // private void OnCollisionExit(Collision other)
    // {
    //     VerticalVelocity -= gravityValue * Time.deltaTime;
    //     Vector3 Jump = new Vector3(0, VerticalVelocity, 0);
    //     m_body.velocity = Jump * Time.deltaTime;
    // }


    public void StopMovement()
    {
        m_body.velocity = Vector3.zero;
        
    }

    public void LoadDifficulty()
    {
        float coeff;
        switch (Difficulty)
        {
            case 1:
                coeff = 0.8f;
                MaxJump+=2;
                break;
            case 2:
                coeff = 0.4f;
                MaxJump++;
                break;
            case 3:
                coeff = 0f;
                break;
            default:
                coeff = 0.5f;
                break;
        }
        MyBall.gameObject.transform.localScale += new Vector3(coeff, coeff, coeff);
        
    }
}
