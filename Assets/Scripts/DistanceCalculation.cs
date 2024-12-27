using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;


public class DistanceCalculation : MonoBehaviour
{
    [SerializeField] 
    Camera camera;
    [SerializeField] 
    ObjectSpawner m_ObjectSpawner;

    /// <summary>
    /// The behavior to use to spawn objects.
    /// </summary>
    public ObjectSpawner objectSpawner
    {
        get => m_ObjectSpawner;
        set => m_ObjectSpawner = value;
    }

    private ZoneDetection zoneDectector;
    private float logInterval = 3f;
    private float timeSinceLastLog = 0f;
    private Radiate radiateComponent;

    void Start() 
    {
        if (camera != null) 
        {
            zoneDectector = camera.GetComponent<ZoneDetection>();
        }
        else 
            Debug.LogWarning("Zone Dectector not initialized, is ZoneDetectionScript set on the Camera?");
    }

    void Update() 
    {
        if (objectSpawner.m_object == null)
        {
            return;
        }

        // Get Radiation Component before doing anything for calculations
        if (radiateComponent == null) 
        {
            radiateComponent = objectSpawner.m_object.GetComponent<Radiate>();
        }
        else 
        {
            timeSinceLastLog += Time.deltaTime;
            if (timeSinceLastLog >= logInterval) 
            {
                UpdateGeigerCounter();
                timeSinceLastLog = 0f;
            }    
        }
        

    }


    void UpdateGeigerCounter() 
    {
        if (objectSpawner.m_object == null || radiateComponent == null)
            return;
        
        // Only report radiation if we're in a radiation zone
        if (zoneDectector.getCurrentZone() != "None") 
        {
            float distance = Vector3.Distance(camera.transform.position, objectSpawner.m_object.transform.position);
            float intensity = radiateComponent.getRadiationIntensity();
            float radiation = intensity/Mathf.Pow(distance, 2);
            Debug.Log("Radiation: " + radiation);
        }
        else
        {
            Debug.Log("Not in a zone, only experience background radiation");
        }
    }
}
