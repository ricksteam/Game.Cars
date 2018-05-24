using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public Image medal;
    public Text txt;
    public string[] achievementList =
    {
        "Finish in less than 20 seconds",
        "Don't drop any of the parts",
        "Drop all the parts once"
    };

    public int dropped;

    public int[] completed =
    {
        0,
        0,
        0
    };



    void Start()
    {
        dropped = 0;

       // PlayerPrefs.SetInt("CompletedOne", 0);
       // PlayerPrefs.SetInt("CompletedTwo", 0);
        //
       // PlayerPrefs.SetInt("CompletedThree", 0);
        loadResults();
    }
    public void checkAllAchievements(float time)
    {
        for (int i = 0 ; i < achievementList.Length; i++)
        {
            checkAchievement(i, time);
        }
        checkCompleted();

    }


    void checkCompleted()
    {
        int all = 0;
        for (int i = 0; i < achievementList.Length; i++)
        {
            if (completed[i] == 1)
                all++;
        }
        if (all == completed.Length)
        {
            Debug.Log("CONGRATS");
            medal.gameObject.SetActive(true);
            txt.gameObject.SetActive(false);
        }
        else
        {
            medal.gameObject.SetActive(false);
            txt.gameObject.SetActive(true);
        }

    }
    

    public void checkAchievement(int index, float time)
    {

        switch (index)
        {
            case 0:
                if (time <= 20)
                {
                    completed[0] = 1;

                }
                break;
            case 1:
                if (dropped == 0)
                {
                    completed[1] = 1;

                }
                    
                break;
            case 2:
                if (dropped == 6)
                {
                    completed[2] = 1;
                }
                break;
            
        }
        saveResults(); 

    }
    public void saveResults()
    {
        PlayerPrefs.SetInt("CompletedOne", completed[0]);
        PlayerPrefs.SetInt("CompletedTwo", completed[1]);
        PlayerPrefs.SetInt("CompletedThree", completed[2]);


        PlayerPrefs.Save();
    }
    public void loadResults()
    {
        completed[0] = PlayerPrefs.GetInt("CompletedOne");
        completed[1] = PlayerPrefs.GetInt("CompletedTwo");
        completed[2] = PlayerPrefs.GetInt("CompletedThree");
        updateText();
        checkCompleted();
        //completed[PlayerPrefs.GetInt("CompletedIndex")] = PlayerPrefs.GetInt("CompletedValue");

    }

    public void updateText()
    {
        // Achievements a = GameObject.Find("Score").GetComponent<Achievements>();
        //Text data = GameObject.Find("AchievementText").GetComponent<Text>();
        txt.text = "\n";
        for (int i = 0; i < achievementList.Length; i++)
        {
            string s = achievementList[i];
            Debug.Log("COMPLETED: " + completed[i]);
            if (completed[i] == 0)
            {
                txt.text += s + "\n";
            }
            else
            {
                txt.text += StrikeThrough(s) + "\n";
            }

        }


    }
    public string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + c + '\u0336';
        }
        return strikethrough;
    }

}
