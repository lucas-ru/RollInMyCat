using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private GameManager m_Game;
    public int totalTime = 0;

    public float m_TimeLeft;
    
    private const string BEST = "bestscore";
    
    public float Best
    {
        get => PlayerPrefs.GetFloat(BEST,0);
        set => PlayerPrefs.GetFloat(BEST, value);
    }

    public event EventHandler<EventArgs> Completed;
    
    private void Awake()
    {
        m_Game = GameManager.Instance;
    }

    public string Formatted(float time)
    {
        int minutes = Mathf.FloorToInt(time/60);
        int seconds = Mathf.FloorToInt(time%60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SubmitTime(float time)
    {
        if (time > Best)
        {
            Best = time;
        }
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
