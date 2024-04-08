using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    //create a list of enemies in combat
    public List<GameObject> enemiesInCombat = new List<GameObject>();
    // GameObject[] EnmiesInCombat => enemiesInCombat.ToArray();
    enum MusicState { Explore, Combat };
    public MusicState currentMusicState = MusicState.Explore;
    bool combatState = false;

    public void AddEnemy(GameObject enemy)
    {
        if (!enemiesInCombat.Contains(enemy))
        {
            enemiesInCombat.Add(enemy);
        }
    }
    
    public void RemoveEnemy(GameObject enemy)
    {
        if (enemiesInCombat.Contains(enemy))
        {
            enemiesInCombat.Remove(enemy);
        }
    }
    
    void Start()
    {
        AkSoundEngine.PostEvent("Play_Explore", gameObject);
    }
    void Update()
    {
        //if any gameobject in the list is missing, remove it
        // for (int i = 0; i < enemiesInCombat.Count; i++)
        // {
        //     if (enemiesInCombat[i] == null)
        //     {
        //         enemiesInCombat.RemoveAt(i);
        //     }
        // }
        if (enemiesInCombat.Count > 0)
        {
            if (!combatState)
            {
                combatState = true;
                currentMusicState = MusicState.Combat;
                Debug.Log("Combat");
                AkSoundEngine.PostEvent("Play_Combat", gameObject);
            }
        }
        else
        {
            if (combatState)
            {
                Invoke("PlayExploreMusic", 7.5f);
            }
        }
    }

    void PlayExploreMusic()
    {
        if (enemiesInCombat.Count > 0)
        {
            return;
        }

        if (combatState)
        {
            combatState = false;
            currentMusicState = MusicState.Explore;
            Debug.Log("Explore");
            AkSoundEngine.PostEvent("Play_Explore", gameObject);
        }
    }
}
