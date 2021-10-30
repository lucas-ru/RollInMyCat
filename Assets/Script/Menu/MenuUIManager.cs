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
    public GameObject ParamPanel;

    private string LEVEL = "LevelNumber";
    
    
    private int Level
    {
        get => PlayerPrefs.GetInt(LEVEL,1);
    }



    public void StartGameInMenu()
    {
        Debug.Log(Level);
        SceneManager.LoadScene("Map_"+ Level, LoadSceneMode.Single);

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
        ParamPanel.gameObject.SetActive(false);
    }

    public void GoParameterPanel()
    {
        ParamPanel.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }


}
