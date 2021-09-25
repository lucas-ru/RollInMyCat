using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameManager m_Game;

    private Vector3 offset;
    
    private void Awake()
    {
        m_Game = GameManager.Instance;
    }

    private void Update()
    {
        transform.position = m_Game.player.transform.position + offset;
    }
    
}
