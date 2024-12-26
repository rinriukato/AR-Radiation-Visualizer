using UnityEngine;


public class Radiate : MonoBehaviour
{

    [SerializeField] private GameObject dangerZoneGreen; // 0 - 1  mSv
    [SerializeField] private GameObject dangerZoneYellow; // 1 - 10 mSv
    [SerializeField] private GameObject dangerZoneOrange;// 10 - 49 mSv
    [SerializeField] private GameObject dangerZoneRed; // 50+ mSv


    private Vector3 defaultScale = new Vector3(0, 0, 0);
    private Vector3 maxScale = new Vector3(50,50,50); // in diameter
    private const float greenRange = 1;
    private const float yellowRange = 10;
    private const float orangeRange = 25;
    private const float redRange = 50;

    private float radiationIntensity = 0; // in mSv
    private int currentType = 0; // 0 - Alpha, 1 - Beta, 2 - Gamma

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    
    {
        InitializeZones();
        CalculateZones();
    }

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
}