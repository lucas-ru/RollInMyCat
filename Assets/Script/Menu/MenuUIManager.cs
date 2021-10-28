using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MenuUIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelPanel;

    public string UNLOCKEDLEVEL = "numberLevelUnlock";
    
    public int UnlockedLevel
    {
        get => PlayerPrefs.GetInt(UNLOCKEDLEVEL,1);
    }
    private void Awake()
    {
        for( int i=0; i<gameObject.transform.childCount; i++ )
        {
            GameObject go = gameObject.transform.GetChild(i).gameObject;
            Debug.Log(go);
        }
    }

    public void StartGameInMenu()
    {
        SceneManager.LoadScene("Map_"+ UnlockedLevel, LoadSceneMode.Single);

    }

    public void GoLevelPanel()
    {
        MainMenu.gameObject.SetActive(false);
        LevelPanel.gameObject.SetActive(true);
    }

    public void BackButton()
    {
        MainMenu.gameObject.SetActive(true);
        LevelPanel.gameObject.SetActive(false);
    }
}
