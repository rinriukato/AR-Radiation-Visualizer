using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldHandler : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public void UpdateText(float value) 
    {
        textMeshPro.text = "Intensity: " + value.ToString("F2") + " mSv";
    }

}