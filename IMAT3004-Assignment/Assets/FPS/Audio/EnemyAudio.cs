using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Drone_hover_loop", gameObject);
    }

    void OnDestroy()
    {
        AkSoundEngine.StopAll(gameObject);
        AkSoundEngine.PostEvent("Drone_hover_stop", gameObject);
    }
}
