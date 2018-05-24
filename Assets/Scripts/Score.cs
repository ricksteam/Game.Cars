using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public float time;

    public Text bestTime;
    public int wins;
    public int losses;

    [SerializeField]
    private bool debugMode = true;
    

   //public DisplayScore ds;
    
    void Start()
    {
        //PlayerPrefs.SetFloat("bestTime", 0.0f);
        //achievements = GetComponent<Achievements>();
        //ds = GetComponent<DisplayScore>();
        //Debug.Log(achievements.gameObject.name);
        bestTime = bestTime.GetComponent<Text>();
        
        Load();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && debugMode == true)
        {
            PlayerPrefs.SetFloat("bestTime", 0.0f);
            PlayerPrefs.SetInt("CompletedOne", 0);
            PlayerPrefs.SetInt("CompletedTwo", 0);
            PlayerPrefs.SetInt("CompletedThree", 0);
            GameObject.Find("Achievements").GetComponent<Achievements>().updateText();
            GameObject.Find("Achievements").GetComponent<Achievements>().loadResults();
            GameObject.Find("Achievements").GetComponent<Achievements>().checkCompleted();
            Load();
        }
    }
	
     public void Save()
    {

        if (!PlayerPrefs.HasKey("bestTime"))
        {
            PlayerPrefs.SetFloat("bestTime", this.time);
        }
        else
        {
            float prevTime = PlayerPrefs.GetFloat("bestTime");
            Debug.Log(this.time + " < " + prevTime);
            if (prevTime == 0 || this.time < prevTime)
            {
                PlayerPrefs.SetFloat("bestTime", this.time);
            }
           
        }
        
       

        PlayerPrefs.Save();
        Load();
    }

    public void Load()
    {
        
        if (PlayerPrefs.HasKey("bestTime"))
        {
            this.time = PlayerPrefs.GetFloat("bestTime");
        }
        else
        {
            this.time = 0;
        }

        
        //Debug.Log(achievements.gameObject.name); 
        bestTime.text = "Best time: " + this.time.ToString("f2");
    }
   
}
