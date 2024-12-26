using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZoneDetection : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    void OnTriggerEnter(Collider other) 
    {
        string name = other.gameObject.name;
        string zoneName = "None";

        if (name == "DangerZoneGreen") 
        {
            zoneName = "Green";
        }
        else if (name == "DangerZoneYellow")
        {
            zoneName = "Yellow";
        }
        else if (name == "DangerZoneOrange")
        {
            zoneName = "Orange";
        }
        else if (name == "DangerZoneRed")
        {
            zoneName = "Red";
        }

        textMeshPro.text = "Zone: " + zoneName;
    }

}
