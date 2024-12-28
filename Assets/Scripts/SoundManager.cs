using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource geigerLow;
    [SerializeField] private AudioSource geigerMed;
    [SerializeField] private AudioSource geigerHigh;
    
    public void StopAllAudio() 
    {
        geigerLow.Stop();
        geigerMed.Stop();
        geigerHigh.Stop();
    }

    public void PlayAudio(int trackNum) 
    {
        StopAllAudio();

        if (trackNum == 0)
            geigerLow.Play();
        else if (trackNum == 1)
            geigerMed.Play();
        else if (trackNum == 2)
            geigerHigh.Play();
        else
            Debug.LogWarning("Invalid track number");
    }
}
