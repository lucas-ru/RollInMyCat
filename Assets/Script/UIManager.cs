using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameManager m_Game;

    public GameObject WinPanel;
    public GameObject LoosePanel;
    public GameObject PausePanel;
    public GameObject MainMenu;
    public GameObject inGame;

    
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    private void Awake()
    {
        m_Game = GameManager.Instance;
    }
    
    private void Update()
    {
        if (m_Game.Playing)
        {
            score.text = "Score : " + m_Game.Score.Value;
            time.text = m_Game.Timer.Formatted;
        }
    }

    public void ContinueGame()
    {
        m_Game.RestartGame();
    }
    
    public void ExitGame()
    {
        m_Game.EndGame();   
    }

    public void FirstStart()
    {
        MainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(true);
        m_Game.StartGame();
    }

    public void StartGameInMenu()
    {
        SceneManager.LoadScene("Map_01", LoadSceneMode.Single);
        FirstStart();
    }
}
