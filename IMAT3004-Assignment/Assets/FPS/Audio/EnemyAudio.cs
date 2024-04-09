using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    //assign the sound event to this variable
    public AK.Wwise.Event Loop;
    // Start is called before the first frame update
    
    /// <summary>
    /// play the loop sound when the game starts
    /// </summary>
    void Start()
    {
        // AkSoundEngine.PostEvent("Drone_hover_loop", gameObject);
        Loop.Post(gameObject);
    }

    /// <summary>
    /// Destroy the game object and stop the sound when the game object is destroyed
    /// </summary>
    void OnDestroy()
    {
        AkSoundEngine.StopAll(gameObject);
        // AkSoundEngine.PostEvent("Drone_hover_stop", gameObject);
    }
}
