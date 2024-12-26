using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class InputFieldHandler : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private Radiate radiateComponent;

    [SerializeField]
    [Tooltip("The behavior to use to spawn objects.")]
    ObjectSpawner m_ObjectSpawner;

    /// <summary>
    /// The behavior to use to spawn objects.
    /// </summary>
    public ObjectSpawner objectSpawner
    {
        get => m_ObjectSpawner;
        set => m_ObjectSpawner = value;
    }

    public void UpdateText(float value) 
    {
        textMeshPro.text = "Intensity: " + value.ToString("F2") + " mSv";

        if (objectSpawner.m_object != null) {
            // Debug.Log("object avaliable?");
            //Debug.Log(objectSpawner.m_object);

            if (radiateComponent == null) {
                radiateComponent = objectSpawner.m_object.GetComponent<Radiate>();
                radiateComponent.SetRadiationIntensity(value);
            }
            else {
                radiateComponent.SetRadiationIntensity(value);
            }
        }
        else 
        {
            //Debug.Log("Not avaliable?");
        }
    }

}