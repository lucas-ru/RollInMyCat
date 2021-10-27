using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public bool Playing { get; private set; }
    public PlayerManager player { get; private set; }
    public DumbbellManager dumbbell { get; private set; }
    public CameraManager camera { get; private set; }
    public UIManager uimanager { get; private set; }
    public AudioManager Audio { get; private set; }
    public TimeManager Timer { get; private set; }
    public ScoreManager Score { get; private set; }
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }

        dumbbell = GetComponent<DumbbellManager>();
        player = GetComponent<PlayerManager>();
        camera = GetComponent<CameraManager>();
        uimanager = GetComponent<UIManager>();
        Audio = GetComponent<AudioManager>();
        Score = GetComponent<ScoreManager>();
        Timer = GetComponent<TimeManager>();
        
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
        Playing = true;
        Score.Reset();
        Timer.Reset();
        Audio.PlayMainTheme();
    }

    public void RestartGame()
    {
        Playing = true;
        Score.Reset();
        Timer.Reset();
        uimanager.PausePanel.gameObject.SetActive(false);
        uimanager.inGame.gameObject.SetActive(true);
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
        uimanager.inGame.gameObject.SetActive(false);
        uimanager.PausePanel.gameObject.SetActive(true);
        
        player.ball.StopMovement();
    }
    
    
}
