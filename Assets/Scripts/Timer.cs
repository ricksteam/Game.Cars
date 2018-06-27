using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float time;
    float _timer;
    public bool startCountDown;
    public Text timeInGame;
	// Use this for initialization
	void Start () {
        time = 0.0f;
        _timer = 0.0f;
        startCountDown = false;
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        
        if (startCountDown)
        {
            //display time every frame
            time += Time.deltaTime;
            timeInGame.GetComponent<Text>().text = "Time: " + time.ToString("0.00");
        }
        
    }
}
