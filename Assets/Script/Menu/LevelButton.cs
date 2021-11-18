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

    private int Listlevel = 0;

    private Button button;


    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Setup(int Listlevel, bool isUnlock,int score)
    {
        // allows you to lock levels
        this.Listlevel = Listlevel;
        levelText.text = "level " + Listlevel + "\n" + score + "/10";
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
        // redirects to the right level
        menu.StartLevel(Listlevel);
    }
}
