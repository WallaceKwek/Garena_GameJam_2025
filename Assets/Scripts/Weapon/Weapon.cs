using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    public int damage = 1;
    public int distance = 10;
    public int weight = 10;
    public float rate = 1.0f;
    public GameObject projectileSpawned;


    public void Initialize(int initDamge, int initDistance, int initWeight, float initRate, GameObject gameObject)
    {
        damage = initDamge;
        distance = initDistance;
        weight = initWeight;
        rate = initRate;
        projectileSpawned = gameObject;
    }
}
