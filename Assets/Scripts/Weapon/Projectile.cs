using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Scriptable Objects/Weapon")]
public class Projectile : ScriptableObject
{
    public int damage = 1;
    public int distance = 10;
    public Vector2 movement = new Vector2();
    public int speed = 30;

    public void Initialize(int initDamge, int initDistance, Vector2 initMovement)
    {
        damage = initDamge;
        distance = initDistance;
        movement = initMovement;
    }
}
