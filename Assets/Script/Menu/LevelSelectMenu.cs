using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public int totalLevel = 0;

    public string UNLOCKEDLEVEL = "numberLevelUnlock";

    private LevelButton[] levelButtons;

    private int totalPage = 0;

    private int page = 0;

    private int pageItem = 9;

    public GameObject nextButton;

    public GameObject backButton;

    public int UnlockedLevel
    {
        get => PlayerPrefs.GetInt(UNLOCKEDLEVEL,1);
    }
    
    void Awake()
    {
        levelButtons = GetComponentsInChildren<LevelButton>();
    }

    private void Start()
    {
        Refresh();
        Debug.Log(UnlockedLevel);
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
        totalPage = totalLevel / pageItem;
        int index = page * pageItem;
        for (int i = 0; i < levelButtons.Length; i++)
        {   
            int level = index + i + 1;
            if (level<=totalLevel)
            {
                levelButtons[i].gameObject.SetActive(true);
                levelButtons[i].Setup(level, level<=UnlockedLevel);
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
        backButton.SetActive(page>0);
        nextButton.SetActive(page<totalPage && totalLevel > 9);
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene("Map_" + level, LoadSceneMode.Single);
    }
}
