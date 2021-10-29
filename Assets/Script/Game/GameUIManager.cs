using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    private GameManager m_Game;

    public GameObject WinPanel;
    public GameObject LoosePanel;
    public GameObject PausePanel;
    public GameObject inGame;
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public TextMeshProUGUI besttime;
    public TextMeshProUGUI bestscore;
    public TextMeshProUGUI deathCounter;

    private void Awake()
    {
        m_Game = GameManager.Instance;
    }
    
    private void Update()
    {
        if (m_Game.Playing)
        {
            score.text = "Score : " + m_Game.Score.Value;
            time.text = m_Game.Timer.Formatted(m_Game.Timer.m_TimeLeft);
        }
        besttime.text = "Best time : " + m_Game.Timer.Formatted(m_Game.Timer.Best);
        bestscore.text = "Best score : " + m_Game.Score.Score;
        deathCounter.text = "death : " + m_Game.Deathmanager.nbMort;
    }

    public void ContinueGame()
    {
        m_Game.RestartGame();
    }

    public void MoveInMenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
    
    public void ExitGame()
    {
        m_Game.EndGame();   
    }

    public void StartGame()
    {
        m_Game.StartGame();
    }
}
