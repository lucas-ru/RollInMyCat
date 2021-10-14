using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager m_Game;

    public GameObject WinPanel;
    public GameObject LoosePanel;
    public GameObject PausePanel;
    public GameObject MainMenu;
    private void Awake()
    {
        m_Game = GameManager.Instance;
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
        m_Game.StartGame();
    }
}
