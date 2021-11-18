using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public int totalLevel = 0;

    private string LEVEL = "LevelNumber";

    private LevelButton[] levelButtons;

    private int totalPage = 0;

    private int page = 0;

    private int pageItem = 9;

    public GameObject nextButton;

    public GameObject backButton;
    
    private string SCORE;
    public int Score
    {
        get => PlayerPrefs.GetInt(SCORE,0);
        set => PlayerPrefs.SetInt(SCORE, value);
    }

    public int Level
    {
        get => PlayerPrefs.GetInt(LEVEL,1);
    }
    
    void Awake()
    {
        levelButtons = GetComponentsInChildren<LevelButton>();
    }

    private void Start()
    {
        Refresh();
    }

    public void ClickNext()
    {
        page += 1;
        Refresh();
    }

    public void ClickBack()
    {
        page -= 1;
        Refresh();
    }

    public void Refresh()
    {
        // display levels
        totalPage = totalLevel / pageItem;
        int index = page * pageItem;
        for (int i = 0; i < levelButtons.Length; i++)
        {   
            int Listlevel = index + i + 1;
            if (Listlevel<=totalLevel)
            {
                SCORE = "bestscore_Map_" + Listlevel;
                levelButtons[i].gameObject.SetActive(true);
                levelButtons[i].Setup(Listlevel,Listlevel<=Level,Score);
            }
            else
            {
                levelButtons[i].gameObject.SetActive(false);
            }
        }
        CheckButton();
    }

    private void CheckButton()
    {
        // check the necessity of the next page button/ previous page button
        backButton.SetActive(page>0);
        nextButton.SetActive(page<totalPage && totalLevel > 9);
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene("Map_" + level, LoadSceneMode.Single);
    }
}
