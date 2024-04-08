using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class WwiseHealth : MonoBehaviour
{
    public AK.Wwise.RTPC HealthRTPC;

    public Health health;
    void Start()
    {
        health = GetComponent<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        HealthRTPC.SetGlobalValue(health.CurrentHealth);
    }
}
