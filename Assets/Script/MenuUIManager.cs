using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    private GameManager m_Game;
    
    public GameObject MainMenu;


    private void Awake()
    {
        for( int i=0; i<gameObject.transform.childCount; i++ )
        {
            GameObject go = gameObject.transform.GetChild(i).gameObject;
            Debug.Log(go);
        }
        
        m_Game = GameManager.Instance;
    }

    public void StartGameInMenu()
    {
        SceneManager.LoadScene("Map_01", LoadSceneMode.Single);

    }
}
