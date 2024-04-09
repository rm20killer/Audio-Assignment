using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Footstep_change : MonoBehaviour
{
    /// <summary>
    /// Check if the player is on a metal object and change the footstep sound accordingly
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("MetalPlatform") || other.gameObject.name.StartsWith("CrashedShip"))
        {
            AkSoundEngine.SetSwitch("Footsteps", "Metal", gameObject);
        }
    }
    
    
    /// <summary>
    /// If the player is not on a metal object, change the footstep sound back to sand
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.StartsWith("MetalPlatform") || other.gameObject.name.StartsWith("CrashedShip"))
        {
            AkSoundEngine.SetSwitch("Footsteps", "Sand", gameObject);
        }
    }
}
