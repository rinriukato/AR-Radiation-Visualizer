using UnityEngine;

public class ShieldingBehavior : MonoBehaviour
{
    void OnParticleCollision(GameObject other) 
    {
        if (other.CompareTag("Shielding")) 
        {
            Debug.Log("Hit Shielding???");
        }
    }
}
