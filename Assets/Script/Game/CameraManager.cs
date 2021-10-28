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
    
    private Vector3 offset;
    
    private void Awake()
    {
        m_Game = GameManager.Instance;
        offset = cam.transform.position - target.position;
    }

    private void Update()
    {
        Vector3 smoothPosition = Vector3.Lerp(cam.transform.position, target.position + offset, smooth);
        cam.transform.position = smoothPosition;
    }
    
}
