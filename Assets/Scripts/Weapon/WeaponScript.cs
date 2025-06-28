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
        GameObject newProjectile = Instantiate(weapon.projectileSpawned, transform.position, Quaternion.identity);
        ProjectileScript projectileScript = newProjectile.GetComponent<ProjectileScript>();
        projectile = ScriptableObject.CreateInstance<Projectile>();
        projectile.Initialize(weapon.damage, weapon.distance, direction);
        projectileScript.Projectile = projectile;
    }
}
