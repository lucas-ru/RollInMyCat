using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    public TextMeshProUGUI TextDifficulty;

    private string DIFFICULTY = "Difficulty";
    private int Difficulty
    {
        get => PlayerPrefs.GetInt(DIFFICULTY,1);
        set => PlayerPrefs.SetInt(DIFFICULTY,value);
    }

    private void Awake()
    {
        RenderDifficulty();
    }


    public void RenderDifficulty()
    {
        switch (Difficulty)
        {
            case 1:
                TextDifficulty.text = "Easy";
                break;
            case 2:
                TextDifficulty.text = "Medium";
                break;
            case 3:
                TextDifficulty.text = "Hard";
                break;
            default:
                TextDifficulty.text = "Easy";
                break;
        }
    }

    public void ChangeDifficulty()
    {
        Difficulty++;
        if (Difficulty==4)
        {
            Difficulty = 1;
        }
        RenderDifficulty();
    }
}
