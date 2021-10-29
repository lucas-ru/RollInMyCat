using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private GameManager m_Game;
    public int Value { get; private set; }
    
    private string SCORE;
    
    public int Score
    {
        get => PlayerPrefs.GetInt(SCORE,0);
        set => PlayerPrefs.SetInt(SCORE, value);
    }

    private void Awake()
    {
        m_Game = GameManager.Instance;
        SCORE = "bestscore_" + SceneManager.GetActiveScene().name;
    }

    public void Reset()
    {
        Value = 0;
    }

    public void DumbbellCollectedHandler()
    {
        Value += 1;
    }
    
    public void SubmitScore(int score)
    {
        if (score > Score)
        {
            Score = score;
        }
    }
}
