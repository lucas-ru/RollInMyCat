using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public LevelSelectMenu menu;
    
    
    public TextMeshProUGUI levelText;

    private int level = 0;

    private Button button;


    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Setup(int level, bool isUnlock)
    {
        this.level = level;
        levelText.text = level.ToString();
        if (isUnlock)
        {
            button.interactable = true;
            button.enabled = true;
            levelText.gameObject.SetActive(true);
        }
        else
        {
            button.interactable = false;
            button.enabled = false;
            levelText.gameObject.SetActive(false);
        }
    }

    public void Onclick()
    {
        menu.StartLevel(level);
    }
}
