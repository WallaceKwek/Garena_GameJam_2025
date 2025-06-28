using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyObject : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector2 destination; // this determines where we want to move the enemy towards
    private Rigidbody2D rb;

    public float moveSpeed;

    public float attackRate = 0.25f;
    private float attackTimer = 0.0f; // this acts as a bounce time for the enemy's attack

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // we use this to flash the enemy white to show that it was damaged
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //destination = new Vector2(GameManager.inst.gpManager.player.transform.localPosition.x, GameManager.inst.gpManager.player.transform.localPosition.y);
        destination = (GameManager.inst.gpManager.player.transform.position - transform.position).normalized;
        rb.linearVelocity = destination * moveSpeed;
    }

    // When enemy collides with player, ensure that there is a cooldown on the attack so that the player doesnt get killed instantly in 1 second
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            attackTimer = attackRate;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
       if(attackTimer >= attackRate)
        {
            attackTimer = 0.0f;

            // get the player health component to deal damage to it
            HealthComponent playerhp = GameManager.inst.gpManager.player.GetComponent<HealthComponent>();
            playerhp.currentHealth = playerhp.currentHealth - 1;

            // Update the UI (number of hearts)

            // Play audio of player being damaged
        }
    }
}
