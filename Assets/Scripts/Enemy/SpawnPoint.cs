using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // this script is attached to an empty GO that is pre-placed in the level manually
    // te wave manager has a list of all these spawn points and will randomly select from them to spawn the enemies

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(int enemyCount, float health)
    {
        GameObject temp = null;
        EnemyObject tempEnemyObj = null;

        for(int i = 0; i < enemyCount; ++i)
        {
            temp = GameManager.inst.gpManager.enemyObjectPool.GetPooledEnemy();
            tempEnemyObj = temp.GetComponent<EnemyObject>();
            temp.transform.position = this.transform.position;

            // TO ADD enemy hp stats depending on type of enemy

            // TO ADD change sprite depending on type of enemy


            temp.SetActive(true);
        }
    }
}