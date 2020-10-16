using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextWinLose : MonoBehaviour
{
    private Text myText;
    
    [Serializable]
    public enum TargetType {
        Win,
        Lose
    }

    public TargetType target; 
    
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        
        if (target == TargetType.Win)
        {
            SetWins();
        }
        else
        {
            SetLoses();
        }
    }

    public void SetWins()
    {
        myText.text = PlayerPrefs.GetInt("win", 0) + " victories";
    }
    public void SetLoses()
    {
        myText.text = PlayerPrefs.GetInt("lose", 0) + " defeats";
    }
}
