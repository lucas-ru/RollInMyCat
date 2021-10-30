using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private GameManager m_Game;
    
    public ParticleSystem blueParticles;
    public ParticleSystem yellowParticles;
    public ParticleSystem redParticles;
    public ParticleSystem greenParticles;
    public ParticleSystem purpleParticles;

    
    private string DIFFICULTY = "Difficulty";
    private int Difficulty
    {
        get => PlayerPrefs.GetInt(DIFFICULTY,1);
    }
    private void Awake()
    {
        m_Game = GameManager.Instance;
        
        LoadParticles(blueParticles);
        // LoadParticles(yellowParticles);
        // LoadParticles(redParticles);
        // LoadParticles(greenParticles);
        // LoadParticles(purpleParticles);
    }

    private void Update()
    {
        StyleParticle(blueParticles);
        // StyleParticle(yellowParticles);
        // StyleParticle(redParticles);
        // StyleParticle(greenParticles);
        // StyleParticle(purpleParticles);

    }

    public void LoadParticles(ParticleSystem particle)
    {
        particle.gameObject.SetActive(true);
        float positionYParticle;
        if (Difficulty==1)
        {
            positionYParticle = 0.9f;
        }else if (Difficulty == 2)
        {
            positionYParticle = 0.7f;;
        }else
        {
            positionYParticle = 0.5f;
        }
        particle.transform.position = new Vector3(m_Game.player.ball.transform.position.x,m_Game.player.ball.transform.position.y-positionYParticle,m_Game.player.ball.transform.position.z);
        

    }

    public void StyleParticle(ParticleSystem particle)
    {
        ParticleSystem.MainModule particleMain = particle.main;
        if (m_Game.player.ball.actualspeed< 3000)
        {
            particleMain.startLifetime = m_Game.player.ball.actualspeed/500;
            particleMain.startSpeed = m_Game.player.ball.actualspeed/1000;

        }
        // particle.transform.rotation = Quaternion.Euler(m_Game.player.ball.currentDirection.x,m_Game.player.ball.currentDirection.y,m_Game.player.ball.currentDirection.z);
        Debug.Log(particle.transform.rotation);
    }
}
