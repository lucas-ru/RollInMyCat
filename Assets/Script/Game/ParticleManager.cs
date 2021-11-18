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

    
    private string AUTORIZEPARTICLE = "Particle";
    private int AutorizeParticle
    {
        get => PlayerPrefs.GetInt(AUTORIZEPARTICLE,1);
        set => PlayerPrefs.SetInt(AUTORIZEPARTICLE,value);
    }
    private void Awake()
    {
        m_Game = GameManager.Instance;
        if (AutorizeParticle == 1)
        {
            LoadParticles(blueParticles);
            LoadParticles(yellowParticles);
            LoadParticles(redParticles);
            LoadParticles(greenParticles);
            LoadParticles(purpleParticles);
        }
        
    }

    private void Update()
    {
        if (AutorizeParticle==1)
        {
            StyleParticle(blueParticles);
            StyleParticle(yellowParticles);
            StyleParticle(redParticles);
            StyleParticle(greenParticles);
            StyleParticle(purpleParticles);
        }
    }

    public void LoadParticles(ParticleSystem[] particle)
    {
        // activate all particles
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].gameObject.SetActive(true);
        }

    }

    public void StyleParticle(ParticleSystem[] particle)
    {
        // function that can setup the particle
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
