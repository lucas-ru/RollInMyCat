using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager m_Game;

    public GameObject WinPanel;
    public GameObject LoosePanel;
    private void Awake()
    {
        m_Game = GameManager.Instance;
    }
    
}
