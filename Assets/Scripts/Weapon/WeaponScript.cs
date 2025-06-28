using UnityEngine;

public class WeaponScript : MonoBehaviour
{   
    Projectile projectile;
    public Weapon weapon;
    private float time = 0;

    void Update()
    {
        time -= Time.deltaTime;
    }

    public void Attack(Vector2 direction)
    {
        if (time > 0) {
            return;
        }
        time = weapon.rate;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        GameObject newProjectile = Instantiate(weapon.projectileSpawned, transform.position, rotation);
        ProjectileScript projectileScript = newProjectile.GetComponent<ProjectileScript>();
        projectile = ScriptableObject.CreateInstance<Projectile>();
        projectile.Initialize(weapon.damage, weapon.distance, direction, weapon.projectileSpd);
        projectileScript.projectile = projectile;
    }
}
