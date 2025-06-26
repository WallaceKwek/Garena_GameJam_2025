using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyObject : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector3 destination; // this determines where we want to move the enemy towards

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // we use this to flash the enemy white to show that it was damaged
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
