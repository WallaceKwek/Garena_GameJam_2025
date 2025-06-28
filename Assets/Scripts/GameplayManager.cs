using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    // this script handles all events that happen during the game
    // this can range from UI events (when to show the prayer input field etc) to other backend stuff such as updating game states (game over etc)

    public GameObject player; // reference to the gameobject that represents the player

    [HideInInspector]
    public EnemyObjectPool enemyObjectPool;
    [HideInInspector]
    public WaveManager waveManager;
    [HideInInspector]
    public ScalingManager scalingManager;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameManager.inst != null)
        {
            GameManager.inst.gpManager = this;
        }

        enemyObjectPool = GetComponent<EnemyObjectPool>();
        waveManager = GetComponent<WaveManager>();
        scalingManager = GetComponent<ScalingManager>();

        enemyObjectPool.Init();
        waveManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
