using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    // this script handles all events that happen during the game
    // this can range from UI events (when to show the prayer input field etc) to other backend stuff such as updating game states (game over etc)

    public GameObject player; // reference to the gameobject that represents the player

    [HideInInspector]
    public EnemyObjectPool enemyObjectPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
