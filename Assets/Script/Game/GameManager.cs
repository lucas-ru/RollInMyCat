using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public bool Playing { get; private set; }
    public PlayerManager player { get; private set; }
    public DumbbellManager dumbbell { get; private set; }
    public CameraManager camera { get; private set; }
    public AudioManager Audio { get; private set; }
    public TimeManager Timer { get; private set; }
    public ScoreManager Score { get; private set; }
    public GameUIManager Gameuimanager { get; private set; }
    public DeathManager Deathmanager { get; private set; }
    public ParticleManager Particle { get; private set; }
    public PlateformManager Plateform { get; private set; }
    
    private string LEVEL = "LevelNumber";

    public int Level
    {
        get => PlayerPrefs.GetInt(LEVEL,1);
        set => PlayerPrefs.SetInt(LEVEL, value);

    }

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
        Gameuimanager = GetComponent<GameUIManager>();
        Audio = GetComponent<AudioManager>();
        Score = GetComponent<ScoreManager>();
        Timer = GetComponent<TimeManager>();
        Deathmanager = GetComponent<DeathManager>();
        Particle = GetComponent<ParticleManager>();
        Plateform = GetComponent<PlateformManager>();

        StartGame();
    }

    private void Update()
    {
        // Control In game else movement
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    public void StartGame()
    {
        Playing = true;
        Score.Reset();
        Timer.Reset();
        Deathmanager.Reset();
        Audio.PlayMainTheme();
        Gameuimanager.inGame.gameObject.SetActive(true);
        Gameuimanager.PausePanel.gameObject.SetActive(false);
        Gameuimanager.LoosePanel.gameObject.SetActive(false);
    }

    public void Respawn()
    {
        player.ball.gravity = true;
        player.ball.StopMovement();
        camera.Reset();
        player.ball.transform.position = player.ball.startposition;
        Playing = true;
        Audio.PlayMainTheme();
        Deathmanager.DieAndRetry();
        Gameuimanager.inGame.gameObject.SetActive(true);
        Gameuimanager.PausePanel.gameObject.SetActive(false);
        Gameuimanager.LoosePanel.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Playing = true;
        Score.Reset();
        Timer.Reset();
        Gameuimanager.PausePanel.gameObject.SetActive(false);
        Gameuimanager.inGame.gameObject.SetActive(true);
    }
    
    public void LooseGame()
    {
        Playing = false;
        Audio.Stop();
        Gameuimanager.LoosePanel.gameObject.SetActive(true);
    }

    public void DisplayControl()
    {
        Gameuimanager.RenderVarNbJump();
        Gameuimanager.ControlPanel.gameObject.SetActive(true);
        Gameuimanager.PausePanel.gameObject.SetActive(false);
    }

    public void BackPauseMenu()
    {
        Gameuimanager.ControlPanel.gameObject.SetActive(false);
        Gameuimanager.PausePanel.gameObject.SetActive(true);

    }

    public void WinGame()
    { 
        // allows to manage the victory interface, nevertheless this one is not yet used
        Playing = false;
        Timer.SubmitTime(Timer.m_TimeLeft);
        Debug.Log(Timer.m_TimeLeft);
        Gameuimanager.WinPanel.gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        int IndexActualScene = SceneManager.GetActiveScene().buildIndex;
        if (IndexActualScene == Level)
        {
            Level++;
        }
        IndexActualScene++;
        Timer.SubmitTime(Timer.m_TimeLeft);
        Score.SubmitScore(Score.Value);
        Deathmanager.SubmitDeath(Deathmanager.nbMort);
        SceneManager.LoadScene("Map_"+IndexActualScene, LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        Playing = false;
        Gameuimanager.inGame.gameObject.SetActive(false);
        Gameuimanager.PausePanel.gameObject.SetActive(true);
        
        player.ball.StopMovement();
    }
}
