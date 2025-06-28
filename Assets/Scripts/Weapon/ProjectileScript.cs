using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Projectile projectile;
    public Vector3 initialLocation;
    private Rigidbody2D rb;

    void Start()
    {
        initialLocation = transform.localPosition;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = projectile.movement * projectile.speed;
        if (Vector3.Distance(transform.localPosition, initialLocation) > projectile.distance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // deal damage to the enemy
            HealthComponent hpcomponent = collision.gameObject.GetComponent<HealthComponent>();
            hpcomponent.currentHealth -= projectile.damage;
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) {
            Destroy(gameObject);
        }
    }
}
