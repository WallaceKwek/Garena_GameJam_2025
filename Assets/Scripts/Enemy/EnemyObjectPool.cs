using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public List<GameObject> enemyPrefabList = new List<GameObject>();
    public int poolSize;

    // For each type of enemy create a list to store those prefabs
    private List<GameObject> enemyPool;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init()
    {
        enemyPool = new List<GameObject>();
        GameObject temp = null;
        for (int i = 0; i < poolSize; ++i)
        {
            temp = Instantiate(enemyPrefabList[0]); // to be replaced to spawn different types of enemies (can just be RNG)
            temp.SetActive(false);
            enemyPool.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < enemyPool.Count; ++i)
        {
            if (enemyPool[i].activeSelf == false)
            {
                return enemyPool[i];
            }
        }
        GameObject temp = null;
        for (int i = 0; i < 10; ++i)
        {
            temp = Instantiate(enemyPrefabList[0]); // to be replaced to spawn different types of enemies
            temp.SetActive(false);
            enemyPool.Add(temp);
        }

        return temp;
    }
}