using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private List<float> spawnDistFromPlayer;

    public int baseHealth = 20;
    private float spawnBounceTime = 0.0f;
    private ScalingManager sm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Init()
    {
        spawnDistFromPlayer = new List<float>();
        sm = GameManager.inst.gpManager.scalingManager;
        spawnBounceTime = sm.waveFrequency;
        UpdateSpawnDistances(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnBounceTime <= 0.0f)
        {
            Debug.Log("HIT");
            UpdateSpawnDistances(false);
                
            for(int i = 0; i < sm.groupSpawnCount; ++i)
            {
                SpawnPoint temp = ChooseSpawnPoint();

                temp.SpawnEnemy((int)(sm.enemyCount * sm.enemyCountMultiplier), baseHealth * sm.hpIncreaseMultiplier);
            }

            spawnBounceTime = sm.waveFrequency;
        }

        spawnBounceTime -= Time.deltaTime;
    }

    // Finds the furtherst spawnpoint from the player and then sets it so it won't be used again until recalculated
    private SpawnPoint ChooseSpawnPoint()
    {
        float maxDist = Mathf.Max(spawnDistFromPlayer.ToArray());
        int maxDistIndex = spawnDistFromPlayer.FindIndex(x => x.Equals(maxDist));
        spawnDistFromPlayer[maxDistIndex] = 0.0f;
        return spawnPoints[maxDistIndex];
    }

    // Calculates the distance of each spawnpoint to the player
    public void UpdateSpawnDistances(bool init)
    {
        for (int i = 0; i < spawnPoints.Count; ++i)
        {
            if (init)
            {
                spawnDistFromPlayer.Add(Vector3.Distance(GameManager.inst.gpManager.player.transform.position, spawnPoints[i].gameObject.transform.position));
            }
            else
            {
                spawnDistFromPlayer[i] = Vector3.Distance(GameManager.inst.gpManager.player.transform.position, spawnPoints[i].gameObject.transform.position);
            }

        }
    }

}
