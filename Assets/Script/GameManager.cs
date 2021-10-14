using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool Playing { get; private set; }
    
    public PlayerManager player { get; private set; }

    public CameraManager camera { get; private set; }
    
    public UIManager uimanager { get; private set; }
    
    public AudioManager Audio { get; private set; }
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }

        player = GetComponent<PlayerManager>();
        camera = GetComponent<CameraManager>();
        uimanager = GetComponent<UIManager>();
        Audio = GetComponent<AudioManager>();
        
        
        
        Debug.Log(player.transform.position);
    }

    public void StartGame()
    {
        Playing = true;
        Audio.PlayMainTheme();
    }
    
    public void LooseGame()
    {
        Playing = false;
        uimanager.LoosePanel.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        Playing = false;
        uimanager.WinPanel.gameObject.SetActive(true);
    }
}
