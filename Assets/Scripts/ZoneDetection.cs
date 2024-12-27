using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZoneDetection : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    private string zoneName = "None";
    void OnTriggerEnter(Collider other) 
    {
        string name = other.gameObject.name;

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


    void OnTriggerExit(Collider other) 
    {
        string name = other.gameObject.name;

        if (name == "DangerZoneGreen") 
        {
            zoneName = "None";
        }

        textMeshPro.text = "Zone: " + zoneName;
    }

    public string getCurrentZone() 
    {
        return zoneName;
    }

}
