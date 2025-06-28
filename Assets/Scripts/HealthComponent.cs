using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 1;
    //[HideInInspector]
    public int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            // Coroutine so that the effects above can finishing playing before we disable this gameobject, to add below, this is only applied to enemyobjects
            //StartCoroutine(Kill());
            gameObject.SetActive(false);
        }

        // Clamp the health to be between 0 and the max health
        UnityEngine.Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
