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

    private Radiate radiateComponent;

    void Update() 
    {
        if (objectSpawner.m_object == null)
            return;

        //Debug.Log("Position of Object: " + objectSpawner.m_object.transform.position);
        // Debug.Log("Position: " + camera.transform.position);
        float distance = Vector3.Distance(camera.transform.position, objectSpawner.m_object.transform.position);
        Debug.Log("Distance from Object:" + distance);
    }
}
