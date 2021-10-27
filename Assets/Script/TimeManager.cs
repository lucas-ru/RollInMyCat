using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private GameManager m_Game;
    public int totalTime = 30;

    private float m_TimeLeft;

    public string Formatted
    {
        get
        {
            int minutes = Mathf.FloorToInt(m_TimeLeft/60);
            int seconds = Mathf.FloorToInt(m_TimeLeft%60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }

    public event EventHandler<EventArgs> Completed;
    
    private void Awake()
    {
        m_Game = GameManager.Instance;
    }

    

    public void Reset()
    {
        m_TimeLeft = totalTime;
    }

    public void Update()
    {
        if (!m_Game.Playing) return;
        m_TimeLeft = Mathf.Max(0, m_TimeLeft + Time.deltaTime);
        if (m_TimeLeft == 0)
        {
            OnCompleted();
        }
    }

    public void OnCompleted()
    {
        Completed?.Invoke(this, EventArgs.Empty);
    }
}
