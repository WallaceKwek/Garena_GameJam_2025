using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Projectile Projectile;
    public Vector3 initialLocation;

    void Start()
    {
        initialLocation = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Projectile.movement * Projectile.speed * Time.deltaTime);
        if (Vector3.Distance(transform.localPosition, initialLocation) > Projectile.distance)
        {
            Destroy(gameObject);
        }
    }
}
