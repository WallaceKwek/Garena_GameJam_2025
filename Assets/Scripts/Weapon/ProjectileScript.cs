using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Projectile projectile;
    public Vector3 initialLocation;

    void Start()
    {
        initialLocation = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(projectile.movement * projectile.speed * Time.deltaTime);
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
        }
    }
}
