using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDHolder : MonoBehaviour
{
    public int ID;
    public Vector3 originalLocation;
    public Quaternion originalRotation;

    private void Start()
    {
        originalLocation = transform.position;
        originalRotation = transform.rotation;
    }
}
