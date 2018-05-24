using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class RespawnObjects : MonoBehaviour {
    public GameObject[] parts;
    public Vector3[] partPos;
    Achievements a;
    public GameObject rightController;
    LineDrawer ld;
    void Start()
    {
        a = GameObject.Find("Achievements").GetComponent<Achievements>();
        ld = rightController.GetComponent<LineDrawer>();
        for (int i = 0; i < parts.Length; i++)
        {
            partPos[i] = parts[i].transform.position; 
            parts[i].GetComponent<Custom_InteractableGrab>().enabled = false;
        }
        
    }

    void OnTriggerEnter(Collider collider)
    {
        
        GameObject newPiece = collider.gameObject;
        int index = System.Array.IndexOf(parts, newPiece);
        if (index != -1)
        {
            a.dropped++;
            GameObject n = Instantiate(newPiece, partPos[index], Quaternion.Euler(0, -90.0f, 0));
            parts[index] = n;
            ld.items[index] = n;
            Destroy(newPiece);
        }
        
        
    }
}
