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
    private const float orangeRange = 49;
    private const float redRange = 50;

    private float radiationIntensity = 0; // in mSv


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    
    {
        InitializeZones();
        radiationIntensity = 30;
        calculateZones();
    }

    // The 'zone' radius is dictated by the inverse square law given by radiation intensity at a given distance
    void calculateZones() 
    {
        float greenZone = Mathf.Sqrt(radiationIntensity/greenRange);
        float yellowZone = Mathf.Sqrt(radiationIntensity/yellowRange);
        float orangeZone = Mathf.Sqrt(radiationIntensity/orangeRange);
        float redZone = Mathf.Sqrt(radiationIntensity/redRange);
        Debug.Log("Green Zone:" + greenRange);
        Debug.Log("Yellow Zone:" + yellowZone);
        Debug.Log("Orange Zone:" + orangeZone);
        Debug.Log("Red Zone:" + redZone);
    }

    void InitializeZones() 
    {
        dangerZoneGreen.transform.localScale = defaultScale;
        dangerZoneYellow.transform.localScale = defaultScale;
        dangerZoneOrange.transform.localScale = defaultScale;
        dangerZoneRed.transform.localScale = defaultScale;
    }
}
