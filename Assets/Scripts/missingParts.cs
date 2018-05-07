using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class missingParts : MonoBehaviour
{
    public int HowMany; //how many should be there
    public Transform[] parts;
    public Text scoreText;
    public Text timerText;

    IDHolder currentID;
    GameObject temp;
    new AudioSource audio;

    public float timeCounter;

    bool counting;

    int partsAdded;
    int points;
    int pointCounter;
    int extraPoints;
    
    // Use this for initialization
    void Start()
    {
        partsAdded = 0;
        points = 0;
        timeCounter = 1;
        extraPoints = 10;

        scoreText.text = "Score: 0";
        timerText.text = "Extra Points: ";
        pointCounter = extraPoints;

        StartCoroutine(timer());      
        parts = new Transform[HowMany];
        checkParts();

        audio = gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.volume = .5f;
        audio.clip = Resources.Load("Audio/Completed") as AudioClip;
    }

    public void checkParts()
    {
        int x = 0;
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "objects")
            {
                parts[x] = transform.GetChild(i);
                x++;
            }
        }
    }

    /*
     * Will require just an id of an object 
     * once object was snapped, original gets destyoed 
     * but basic 3d model will be deoloyed
     */
    public void addParts(Transform justSnapped)
    {
        currentID = justSnapped.GetComponent<IDHolder>();

        temp = Instantiate((GameObject)Resources.Load("DummyObjects/ID-" + currentID.ID), justSnapped.position, justSnapped.rotation);

        for (int i = 0; i < HowMany; i++)
        {
            if (parts[i] == null)
            {
                parts[i] = temp.transform;
                temp.transform.parent = transform;
                partsAdded += 1;
                break;
            }
        }

        if (partsAdded == HowMany)
        {
            audio.Play();
        }

        //addPoints();
        Destroy(justSnapped.gameObject);
    }

    void addPoints()
    {
        if(pointCounter != 0)
        {
            StopCoroutine("timer");
            points += 10 + pointCounter;
            scoreText.text = "Score: " + points;
            pointCounter = extraPoints;
            return;
        }
        points += 10;
        scoreText.text = "Score: " + points;
        pointCounter = extraPoints;
        StartCoroutine(timer());
    }

    void assemblyCompleted()
    {

    }

    IEnumerator timer()
    {
        counting = true;
        while(pointCounter > 0)
        {
            pointCounter -= 1;
            timerText.text = "Extra Points: " + pointCounter;
            yield return new WaitForSeconds(timeCounter);
        }
        counting = false;
    }
}

