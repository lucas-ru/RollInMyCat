using System;
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

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        uimanager.MainMenu.gameObject.SetActive(false);
        Playing = true;
        Audio.PlayMainTheme();
    }

    public void RestartGame()
    {
        Playing = true;
        uimanager.PausePanel.gameObject.SetActive(false);
    }
    
    public void LooseGame()
    {
        Playing = false;
        Audio.Stop();
        uimanager.LoosePanel.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void WinGame()
    {
        Playing = false;
        uimanager.WinPanel.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Playing = false;
        uimanager.PausePanel.gameObject.SetActive(true);
        player.ball.StopMovement();
    }
    
}
