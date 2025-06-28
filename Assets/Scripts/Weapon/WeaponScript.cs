using UnityEngine;

public class WeaponScript : MonoBehaviour
{   
    Projectile projectile;
    public GameObject projectileSpawned;

    public void Attack(Vector2 direction)
    {
        GameObject newProjectile = Instantiate(projectileSpawned, transform.position, Quaternion.identity);
        ProjectileScript projectileScript = newProjectile.GetComponent<ProjectileScript>();
        projectile = ScriptableObject.CreateInstance<Projectile>();
        projectile.Initialize(1, 2, direction);
        projectileScript.Projectile = projectile;
    }
}
