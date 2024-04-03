using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Footstep_change : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("MetalPlatform") || other.gameObject.name.StartsWith("CrashedShip"))
        {
            AkSoundEngine.SetSwitch("Footsteps", "Metal", gameObject);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.StartsWith("MetalPlatform") || other.gameObject.name.StartsWith("CrashedShip"))
        {
            AkSoundEngine.SetSwitch("Footsteps", "Sand", gameObject);
        }
    }
}
