using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectileSpawned;
    Projectile projectile;
    private Vector2 direction;
    private Vector2 facing = Vector2.right;

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();
        if (direction.magnitude > 0)
        {
            facing = direction;
        }
        if (Input.GetKeyDown("q"))
        {
            GameObject newProjectile = Instantiate(projectileSpawned, transform.position, Quaternion.identity);
            ProjectileScript projectileScript = newProjectile.GetComponent<ProjectileScript>();
            projectile = ScriptableObject.CreateInstance<Projectile>();
            projectile.Initialize(1, 2, facing);
            projectileScript.Projectile = projectile;


        }
    }
}
