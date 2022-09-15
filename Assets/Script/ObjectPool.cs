using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyGO;
    [SerializeField] [Range(0f,30f)] float spawnTime;
    [SerializeField] [Range(0,50)] int poolSize;

    GameObject[] pool;

    private void Start()
    {
        PopulatePool();
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyGO, transform);
            pool[i].SetActive(false);
        }
    }

    private void EnableObjectInPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTime);
        }
        
    } 
}