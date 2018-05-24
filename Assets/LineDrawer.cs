using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK.Examples;

public class LineDrawer : MonoBehaviour {

    public static bool ready;
    public Transform CanvasText;
    public Text textDistance;
    LineRenderer line;
    public GameObject[] items;
    int counter;
    Vector3[] positions;
    Score score;
    Timer timer;
    public int[] indexes = {0, 1, 2, 3, 4, 5};


	// Use this for initialization
	void Start ()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        ready = false;
        Random.seed = System.DateTime.Now.Millisecond;
        counter = getRandomPart();
        items[counter].GetComponent<Custom_InteractableGrab>().enabled = true;

        Debug.Log(counter);
        positions = new Vector3[2];
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ready)
        {
            findClosestLinear();
        }
        
	}

    void findClosestDynamic()
    {
        for(int i = 0; i < items.Length; i++)
        {
            
        }
    }

    void findClosestLinear()
    {
        if(counter >= items.Length)
        {
            return;
        }

        if(items[counter] == null)
        {
            if (indexes.Length > 0)
            {
                counter = getRandomPart();
                items[counter].GetComponent<Custom_InteractableGrab>().enabled = true;
            }
                
       
                
        }
        positions[0] = transform.position;
        try
        {
            positions[1] = items[counter].transform.position;
        }
        catch
        {
            textDistance.text = "Good Job!\n You are Done!";
            timer.startCountDown = false;
            score.time = timer.time;
            score.Save();

            Debug.Log(timer.time);
            //GameObject.Find("ConsoleCanvas").GetComponent<DisplayScore>().updateText(GameObject.Find("Timer").GetComponent<Timer>().time);
            StartCoroutine(TeleportToMenu());
            
            return;
        }
        CanvasText.position = new Vector3(positions[0].x, positions[0].y + .1f, positions[0].z) ;
        if(Vector3.Distance(positions[0], positions[1]) > .12f)
        {
            textDistance.text = "Distance: " + string.Format("{0:0.00}", Vector3.Distance(positions[0], positions[1])) + "\n You need .12";
        }
        else
        {
            textDistance.text = "Now grab it and place it";
        }
        
        line.SetPositions(positions);
    }

    IEnumerator TeleportToMenu()
    {
        yield return new WaitForSeconds(2);

        LineDrawer.ready = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int getRandomPart()
    {
        int r = indexes[Random.Range(0, indexes.Length)];
        List<int> temp = new List<int>();

        foreach(int i in indexes)
        {
           if (i != r)
           {
                temp.Add(i);
           }
        }
        indexes = temp.ToArray();
        return r;
    }
}
