using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public PlayerController player { get; private set; }

    public CameraManager camera { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }

        player = GetComponent<PlayerController>();
        camera = GetComponent<CameraManager>();
    }
    
    
}
