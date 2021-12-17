using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 2)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float xPos = Random.Range(-9f, 9f);
        float zPos = Random.Range(0, 5);

        Vector3 spawnPos = Vector3.zero;

        spawnPos.x = xPos;
        spawnPos.z = zPos;

        ObjectPool.instance.SpawnFromPool("Enemy", spawnPos, Quaternion.identity);
    }
}
