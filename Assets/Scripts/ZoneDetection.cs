using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ZoneDetection : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    private string zoneName = "None";

    [SerializeField] private GameObject soundManagerObject;
    private SoundManager soundManager;

    void Start() 
    {
        if (soundManagerObject != null)
            soundManager = soundManagerObject.GetComponent<SoundManager>();
        else
            Debug.LogWarning("Sound Manager Object not set in inspector!");
    }
    void OnTriggerEnter(Collider other) 
    {
        string name = other.gameObject.name;

        if (name == "DangerZoneGreen") 
        {
            zoneName = "Green";
            QueueAudio(0);
        }
        else if (name == "DangerZoneYellow")
        {
            zoneName = "Yellow";
            QueueAudio(1);
        }
        else if (name == "DangerZoneOrange")
        {
            zoneName = "Orange";
            QueueAudio(2);
        }
        else if (name == "DangerZoneRed")
        {
            zoneName = "Red";
            QueueAudio(2);
        }

        textMeshPro.text = "Zone: " + zoneName;
    }


    void OnTriggerExit(Collider other) 
    {
        string name = other.gameObject.name;

        if (name == "DangerZoneGreen") 
        {
            zoneName = "None";
            soundManager.StopAllAudio();
        }
        else if (name == "DangerZoneYellow")
        {
            zoneName = "Green";
            QueueAudio(0);
        }
        else if (name == "DangerZoneOrange")
        {
            zoneName = "Yellow";
            QueueAudio(1);
        }
        else if (name == "DangerZoneRed")
        {
            zoneName = "Orange";
            QueueAudio(2);
        }

        textMeshPro.text = "Zone: " + zoneName;
    }

    public string getCurrentZone() 
    {
        return zoneName;
    }

    void QueueAudio(int trackNum)
    {
        if (soundManager == null)
            return;
        
        soundManager.PlayAudio(trackNum);
    }

}
