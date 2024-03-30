using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Footstep_change : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("MetalPlatform"))
        {
            AkSoundEngine.SetSwitch("Footsteps", "Metal", gameObject);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.StartsWith("MetalPlatform"))
        {
            AkSoundEngine.SetSwitch("Footsteps", "Sand", gameObject);
        }
    }
}
