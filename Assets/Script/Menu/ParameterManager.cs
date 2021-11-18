using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParameterManager : MonoBehaviour
{
    public TextMeshProUGUI TextDifficulty;
    public TextMeshProUGUI TextParticle;
    public Slider SliderValue;

    private string DIFFICULTY = "Difficulty";
    
    private string AUTORIZEPARTICLE = "Particle";
    
    private string MUSICVOLUME = "MusicVolume";
    private int Difficulty
    {
        get => PlayerPrefs.GetInt(DIFFICULTY,1);
        set => PlayerPrefs.SetInt(DIFFICULTY,value);
    }
    private int AutorizeParticle
    {
        get => PlayerPrefs.GetInt(AUTORIZEPARTICLE,1);
        set => PlayerPrefs.SetInt(AUTORIZEPARTICLE,value);
    }
    
    private float MusicVolume
    {
        get => PlayerPrefs.GetFloat(MUSICVOLUME,1);
        set => PlayerPrefs.SetFloat(MUSICVOLUME,value);
    }

    private void Awake()
    {
        RenderDifficulty();
        RenderParticle();
        RenderVolume();
        SliderValue.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
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

    public void RenderParticle()
    {
        switch (AutorizeParticle)
        {
            case 1:
                TextParticle.text = "On";
                break;
            case 2:
                TextParticle.text = "Off";
                break;
            default:
                TextParticle.text = "On";
                break;
        }
    }

    public void RenderVolume()
    {
        SliderValue.value = MusicVolume;
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

    public void ChangeParticle()
    {
        if (AutorizeParticle ==2)
        {
            AutorizeParticle = 1;
        }
        else
        {
            AutorizeParticle++;
        }

        RenderParticle();
    }
    
    public void ValueChangeCheck()
    {
        // display music levels
        MusicVolume = SliderValue.value;
    }
}
