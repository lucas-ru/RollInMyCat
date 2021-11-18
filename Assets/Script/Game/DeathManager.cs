using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public int nbMort;
    
    private string DEATHCOUNTER = "DeathCounter";
    
    public int DeathCounter
    {
        get => PlayerPrefs.GetInt(DEATHCOUNTER,0);
        set => PlayerPrefs.SetInt(DEATHCOUNTER, value);
    }

    public void DieAndRetry()
    {
        nbMort++;
    }
    
    public void SubmitDeath(int death)
    {
        if (death < DeathCounter || DeathCounter == 0)
        {
            DeathCounter = death;
        }
    }
    
    public void Reset()
    {
        nbMort = 0;
    }
}
