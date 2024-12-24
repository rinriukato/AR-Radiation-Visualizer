using UnityEngine;
using System.Collections.Generic;

public class ZoneDetection : MonoBehaviour
{

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Detected Object: " + other);
    }
}
