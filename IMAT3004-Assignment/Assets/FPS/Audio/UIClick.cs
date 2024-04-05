using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClick : MonoBehaviour
{
    public void PlayAudioClick()
    {
        AkSoundEngine.PostEvent("Play_glass_002", gameObject);
    }
    
    public void PlayAudiTick()
    {
        AkSoundEngine.PostEvent("Play_tick_002", gameObject);
    }
}
