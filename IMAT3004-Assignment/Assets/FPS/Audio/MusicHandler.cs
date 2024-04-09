using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    //a list of enemies in combat
    // public List<GameObject> enemiesInCombat = new List<GameObject>();
    public GameObject[] enemiesInCombat;
    //an array of enemies in combat which 
    // GameObject[] EnmiesInCombat => enemiesInCombat.ToArray();

    // private GameObject[] EnmiesInCombat;
    
    // enum MusicState { Explore, Combat };
    // MusicState currentMusicState = MusicState.Explore;
    bool combatState = false;
    private int currentEnemyCount = 0;
    /// <summary>
    /// Add an enemy to the list of enemies in combat
    /// </summary>
    /// <param name="enemy"></param>
    public void AddEnemy(GameObject enemy)
    {
        // if (!enemiesInCombat.Contains(enemy))
        // {
        //     enemiesInCombat.Add(enemy);
        // }

        if (!enemiesInCombat.Contains(enemy) && currentEnemyCount < enemiesInCombat.Length) 
        {
            enemiesInCombat[currentEnemyCount] = enemy;
            currentEnemyCount++;
        }

    }
    
    /// <summary>
    /// remove an enemy from the list of enemies in combat
    /// make sure the enemy is in the list before removing it
    /// </summary>
    /// <param name="enemy"></param>
    public void RemoveEnemy(GameObject enemy)
    {
        // if (enemiesInCombat.Contains(enemy))
        // {
        //     enemiesInCombat.Remove(enemy);
        // }
        
        var index = Array.IndexOf(enemiesInCombat, enemy);
        if (index != -1)
        {
            // Shift elements to fill the gap (less efficient)
            for (int i = index; i < currentEnemyCount - 1; i++)
            {
                enemiesInCombat[i] = enemiesInCombat[i + 1];
            }
            enemiesInCombat[currentEnemyCount - 1] = null; // Clear last slot
            currentEnemyCount--; 
        }
    }
    
    void Start()
    {
        //play explore music when the game starts
        AkSoundEngine.PostEvent("Play_Explore", gameObject);
        int maxEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesInCombat = new GameObject[maxEnemyCount];
    }
    void Update()
    {
        //check if any gameobject in the list is missing and remove it if it is
        // enemiesInCombat = enemiesInCombat.Where(enemy => enemy != null).ToList();
        // EnmiesInCombat = enemiesInCombat.ToArray();

        //if any gameobject in the list is missing, remove it
        // for (int i = 0; i < enemiesInCombat.Count; i++)
        // {
        //     if (enemiesInCombat[i] == null)
        //     {
        //         enemiesInCombat.RemoveAt(i);
        //     }
        // }
        for (int i = 0; i < currentEnemyCount; i++) 
        {
            if (enemiesInCombat[i] == null)
            {
                for (int j = i; j < currentEnemyCount - 1; j++)
                {
                    enemiesInCombat[j] = enemiesInCombat[j + 1];
                }
                enemiesInCombat[currentEnemyCount - 1] = null; // Clear last slot
                currentEnemyCount--;
            }
        }
        //if there are enemies in combat play combat music
        if (enemiesInCombat.Length > 0)
        {
            //if the current music state is not combat, play combat music
            if (!combatState)
            {
                combatState = true;
                // currentMusicState = MusicState.Combat;
                Debug.Log("Combat");
                AkSoundEngine.PostEvent("Play_Combat", gameObject);
                //stop the invoke
                CancelInvoke("PlayExploreMusic");
            }
        }
        else
        {
            if (combatState)
            {
                //if the current music state is combat, play explore music
                Invoke("PlayExploreMusic", 7.5f);
            }
        }
    }

    /// <summary>
    /// Play explore music if there are no enemies in combat and the current music state is not explore
    /// </summary>
    void PlayExploreMusic()
    {
        if (enemiesInCombat.Length > 0)
        {
            return;
        }

        if (combatState)
        {
            combatState = false;
            // currentMusicState = MusicState.Explore;
            Debug.Log("Explore");
            AkSoundEngine.PostEvent("Play_Explore", gameObject);
        }
    }
}
