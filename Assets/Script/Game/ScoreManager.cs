using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private GameManager m_Game;
    public int Value { get; private set; }

    private void Awake()
    {
        m_Game = GameManager.Instance;
    }

    public void Reset()
    {
        Value = 0;
    }

    public void DumbbellCollectedHandler()
    {
        Value += 1;
        Debug.Log(Value);
    }
}
