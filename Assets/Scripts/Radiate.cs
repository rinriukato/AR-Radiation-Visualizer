using UnityEngine;


public class Radiate : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private GameObject dangerZoneGreen; // 0 - 1  mSv
    [SerializeField] private GameObject dangerZoneYellow; // 1 - 10 mSv
    [SerializeField] private GameObject dangerZoneOrange;// 10 - 49 mSv
    [SerializeField] private GameObject dangerZoneRed; // 50+ mSv
    
    [SerializeField] private float alphaScaleFactor = 0.02f;


    private Vector3 defaultScale = new Vector3(0, 0, 0);
    private Vector3 maxScale = new Vector3(50,50,50); // in diameter
    private const float greenRange = 1;
    private const float yellowRange = 10;
    private const float orangeRange = 25;
    private const float redRange = 50;

    private float radiationIntensity = 0; // in mSv
    private int currentType = 0; // 0 - Alpha, 1 - Beta, 2 - Gamma


    public void SetRadiationIntensity(float newValue) 
    {
        radiationIntensity = newValue;
        CalculateZones();
    } 

    // The 'zone' radius is dictated by the inverse square law given by radiation intensity at a given distance
    void CalculateZones() 
    {
        float greenZone = Mathf.Sqrt(radiationIntensity/greenRange) * 2;
        float yellowZone = Mathf.Sqrt(radiationIntensity/yellowRange) * 2;
        float orangeZone = Mathf.Sqrt(radiationIntensity/orangeRange) * 2;
        float redZone = Mathf.Sqrt(radiationIntensity/redRange) * 2;
        // Debug.Log("Green Zone:" + greenZone);
        // Debug.Log("Yellow Zone:" + yellowZone);
        // Debug.Log("Orange Zone:" + orangeZone);
        // Debug.Log("Red Zone:" + redZone);

        dangerZoneGreen.transform.localScale = new Vector3(greenZone, greenZone, greenZone);
        dangerZoneYellow.transform.localScale = new Vector3(yellowZone, yellowZone, yellowZone);
        dangerZoneOrange.transform.localScale = new Vector3(orangeZone, orangeZone, orangeZone);
        dangerZoneRed.transform.localScale = new Vector3(redZone, redZone, redZone);
        // Set the radius of the particle system to that of the green area.
        var main = particleSystem.main;
        main.startLifetime = greenZone;
        main.startSpeed = greenZone;

        CalculateRadiationType();
    }

    void CalculateRadiationType() 
    {   
        // Alpha Particles
        if (currentType == 0) {

            dangerZoneGreen.transform.localScale = dangerZoneGreen.transform.localScale * alphaScaleFactor;
            dangerZoneYellow.transform.localScale = dangerZoneYellow.transform.localScale * alphaScaleFactor;
            dangerZoneOrange.transform.localScale = dangerZoneOrange.transform.localScale * alphaScaleFactor;
            dangerZoneRed.transform.localScale =  dangerZoneRed.transform.localScale * alphaScaleFactor;

        }
        // Beta Particles
        else if (currentType == 1) {

        }
        // Gamma Rays
        else {

        }
    }

    void InitializeZones() 
    {
        dangerZoneGreen.transform.localScale = defaultScale;
        dangerZoneYellow.transform.localScale =  defaultScale;
        dangerZoneOrange.transform.localScale = defaultScale;
        dangerZoneRed.transform.localScale = defaultScale;
    }

    public void SetRadiationType(int type) 
    {
        currentType = type;
        Debug.Log("Current Type is now: " + currentType);
    }

    public float getRadiationIntensity()
    {
        return radiationIntensity;
    }
}