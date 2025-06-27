using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Instantiated in GPManager
 * Handles scaling difficulty of the AI (Health, Damage, Frequency)
 * Handles all the spawners (Will be spawners at different locations)
 * Spawners will be placed at different areas (maybe can prioritise spawners which are further from the player)
 */

// this script will call the correct spawn function depending on the enemy type that needs to be spawned
public class WaveManager : MonoBehaviour
{
    public List<SpawnPoint> spawnPoints; // contains all possible spawn locations

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
