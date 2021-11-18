using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameManager m_Game;

    public Transform target;

    public Transform cam;
    
    [Range(0.01f, 1.0f)] public float smooth;

    private Vector3 GravityMovement = new Vector3(-15, 6, 0);

    private Vector3 smoothPosition;
    
    private Quaternion rotationCam = Quaternion.Euler(12, 90, 0);


    private void Awake()
    {
        m_Game = GameManager.Instance;
    }

    private void Update()
    {
        // fix the position of the camera in relation to the player
        cam.transform.position = new Vector3(m_Game.player.ball.MyBall.transform.position.x+ GravityMovement.x, 
            m_Game.player.ball.MyBall.transform.position.y+ GravityMovement.y, 
            m_Game.player.ball.MyBall.transform.position.z+ + GravityMovement.z
            );
        cam.transform.rotation = rotationCam;
    }

    public void returnCamera()
    {
        // when you change the gravity, the camera turns
        if (!m_Game.player.ball.gravity)
        {
            GravityMovement.y=  GravityMovement.y-10;
            rotationCam = Quaternion.Euler(-12, 90, 180);

        }
        else if (m_Game.player.ball.gravity)
        {
            GravityMovement.y=  GravityMovement.y+10;
            rotationCam = Quaternion.Euler(12, 90, 0);
        }
    }

    public void Reset()
    {
        // when you respawn, the camera returns to its initial position
        rotationCam = Quaternion.Euler(12, 90, 0);
    }

}
