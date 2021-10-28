using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbbellManager : MonoBehaviour
{
    private GameManager m_Game;
    public Collectible Collectible { get; private set; }
    public DumbbellData Data { get; private set; }
    
    public ParticleSystem particles;

    public Light pointLight;

    private DumbbellManager m_Dumbbell;
    
    public event EventHandler<DumbbellEvent> DumbbellCollected;
    void Awake()
    {
        Collectible = GetComponent<Collectible>();
        m_Game = GameManager.Instance;
        Collectible.Collected += CollectedHandler;
    }

    public void LoadData(DumbbellData data)
    {
        Data = data;
        ParticleSystem.MainModule particleMain = particles.main;
    }

    public void CollectedHandler(object sender, EventArgs args)
    {

        Collectible c = sender as Collectible;
        DumbbellManager dumbbell = c.GetComponent<DumbbellManager>();
        m_Game.Score.DumbbellCollectedHandler();
        OnDumbbellCollected(dumbbell);
    }
    
    private void OnDumbbellCollected(DumbbellManager dumbbell){
        DumbbellCollected?.Invoke(this,new DumbbellEvent(dumbbell));
    }
}
