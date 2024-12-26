using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ToggleRadiationTypeHandler : MonoBehaviour
{
    private Radiate radiateComponent;
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

    public void SetRadiationType(int type) {
        if (objectSpawner == null)
            return;
        
        // Find radiate script once
        if (radiateComponent == null) {
            radiateComponent = objectSpawner.m_object.GetComponent<Radiate>();
            radiateComponent.SetRadiationType(type);
        }
        else {
            radiateComponent.SetRadiationType(type);
        }

    }
}
