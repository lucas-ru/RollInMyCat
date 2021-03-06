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
    public GameObject ControlPanel;
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public TextMeshProUGUI besttime;
    public TextMeshProUGUI bestscore;
    public TextMeshProUGUI deathCounter;
    public TextMeshProUGUI VarNbJump;

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
        // redirects to the start menu
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public void StartGame()
    {
        // allows to manage the victory interface, nevertheless this one is not yet used
        m_Game.StartGame();
    }

    public void ControlRedirect()
    {
        m_Game.DisplayControl();
    }
    
    public void RenderVarNbJump()
    {
        // display the number of jumps allowed
        VarNbJump.text = m_Game.player.ball.MaxJump.ToString();
    }
}
