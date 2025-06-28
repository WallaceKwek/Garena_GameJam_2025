using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Projectile Projectile;
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
        rb.linearVelocity = Projectile.movement * Projectile.speed;
        if (Vector3.Distance(transform.localPosition, initialLocation) > Projectile.distance)
        {
            Destroy(gameObject);
        }
    }
}
