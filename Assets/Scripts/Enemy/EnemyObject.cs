using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyObject : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector2 destination; // this determines where we want to move the enemy towards
    private Rigidbody2D rb;

    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // we use this to flash the enemy white to show that it was damaged
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        destination = new Vector2(GameManager.inst.gpManager.player.transform.localPosition.x, GameManager.inst.gpManager.player.transform.localPosition.y);
        rb.linearVelocity = destination * moveSpeed;
    }
}
