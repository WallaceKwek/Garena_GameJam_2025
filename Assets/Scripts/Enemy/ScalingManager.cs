using UnityEngine;

public class ScalingManager : MonoBehaviour
{
    public float scalingFrequency = 35.0f; // how often we should increase the difficulty
    public float waveFrequency = 5.0f; // how often to spawn a new wave
    public int groupSpawnCount = 1; // how many spawners we should activate
    public int enemyCount = 3;

    public float hpIncreaseMultiplier = 1.0f; // starts at 1 and will be increased overtime
    public float enemyCountMultiplier = 1.0f; // starts at 1 and will be increased overtime

    public float timeElapsed = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    private void IncreaseDifficultyScale()
    {
        if (timeElapsed >= 45.0f)
        {
            groupSpawnCount = 3;
        }
    }
}
