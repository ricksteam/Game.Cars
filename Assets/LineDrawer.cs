using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour {

    public static bool ready;
    public Transform CanvasText;
    public Text textDistance;
    LineRenderer line;
    public GameObject[] items;
    int counter;
    Vector3[] positions;

	// Use this for initialization
	void Start ()
    {
        counter = 0;
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
            counter++;
        }
        positions[0] = transform.position;
        try
        {
            positions[1] = items[counter].transform.position;
        }
        catch
        {
            textDistance.text = "Good Job!\n You are Done!";
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

}
