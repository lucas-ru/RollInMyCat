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

    public GameObject MyBall;

    private Vector3 translation;

    public bool gravity = true;
    
    private float gravityValue = 14f;
    
    private float JumpForce = 8.0f;

    private bool isGrounded = true;
    
    private int nbJump;

    private Vector3 lastPosition = Vector3.zero;
    
    public float actualspeed;

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
        
        // fix the position of the image in the ball 
        MyBall = GameObject.FindGameObjectsWithTag("Player")[0];
        m_NianCatImage = GameObject.FindGameObjectsWithTag("NianCat")[0];
        m_NianCatImage.transform.rotation = Quaternion.Euler(0,0,0);
        m_NianCatImage.transform.position = MyBall.transform.position;
        
        // load the specificities of the level
        LoadSceneSpecificity();
        LoadDifficulty();
        nbJump = MaxJump;
    }

    private void Update()
    {
        // recovery of the current speed
        actualspeed = (transform.position - lastPosition).magnitude / Time.fixedDeltaTime;
        
        // define permanently the position of the image in relation to the ball
        m_NianCatImage.transform.position = MyBall.transform.position;
        
        if (m_Game.Playing)
        {
            float translationX = Input.GetAxis("Horizontal");
            float translationZ = Input.GetAxis("Vertical");

            if (gravity)
            {
                translation = new Vector3(translationZ,0, -translationX );
            }
            else
            {
                translation = new Vector3(translationZ,0, translationX );
            }
            


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
                    gravity = false;
                    Physics.gravity = new Vector3(0, gravityValue, 0);
                }
                else
                {
                    gravity = true;
                    Physics.gravity = new Vector3(0, -gravityValue, 0);
                }
                m_Game.camera.returnCamera();
                        
            }
        }
        

        if (m_body.transform.position.y < -50 || m_body.transform.position.y > 100)
        {
            m_Game.LooseGame();
        }

    }
    
    void OnCollisionEnter(Collision collision)
    {
        // when the player touches the finish
        if (collision.gameObject.tag == "Arrived")
        {
            m_Game.NextLevel();
        }
        
        // type of platform that boosts the player's jump
        if (collision.gameObject.tag == "Jump")
        {
            m_body.AddForce(Vector3.up * jumpSpeed*1.5f, ForceMode.Impulse);
        }
        
        // type of platform that teleport the player
        if (collision.gameObject.tag == "Tp")
        {
            m_body.transform.position = new Vector3(171,61,0);
        }
        
        // allows to activate the movement of a platform
        if (collision.gameObject.tag == "Floor")
        {
            m_Game.Plateform.active = true;
        }
        nbJump = MaxJump;
        isGrounded = true;
        
    }

    public void LoadSceneSpecificity()
    {
        // define the parameters of the scenes
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_6")
        || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_10"))
        {
            MaxJump = 2;
        }else if(
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_1") 
            || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_2")
            || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_3")
            || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_4")
            || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_5")
            || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_7")
        )
        {
            MaxJump = 1;
        }else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_8")
        || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_9"))
        {
            MaxJump = 1;
            CanChangeGravity = true;
        }
    }


    
    public void StopMovement()
    {
        m_body.velocity = Vector3.zero;
        Physics.gravity = new Vector3(0, -gravityValue, 0);
        
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
