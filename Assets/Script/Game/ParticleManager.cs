using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private GameManager m_Game;
    
    public ParticleSystem[] blueParticles;
    public ParticleSystem[] yellowParticles;
    public ParticleSystem[] redParticles;
    public ParticleSystem[] greenParticles;
    public ParticleSystem[] purpleParticles;

    
    private string DIFFICULTY = "Difficulty";
    private int Difficulty
    {
        get => PlayerPrefs.GetInt(DIFFICULTY,1);
    }
    private void Awake()
    {
        m_Game = GameManager.Instance;
        
        LoadParticles(blueParticles);
        LoadParticles(yellowParticles);
        LoadParticles(redParticles);
        LoadParticles(greenParticles);
        LoadParticles(purpleParticles);
    }

    private void Update()
    {
        StyleParticle(blueParticles);
        StyleParticle(yellowParticles);
        StyleParticle(redParticles);
        StyleParticle(greenParticles);
        StyleParticle(purpleParticles);

    }

    public void LoadParticles(ParticleSystem[] particle)
    {
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].gameObject.SetActive(true);
        }

    }

    public void StyleParticle(ParticleSystem[] particle)
    {
        for (int i = 0; i < particle.Length; i++)
        {
            ParticleSystem.MainModule particleMain = particle[i].main;
            if (m_Game.player.ball.actualspeed< 3000)
            {
                particleMain.startLifetime = m_Game.player.ball.actualspeed/1000;
            }
        }
        
    }
}
