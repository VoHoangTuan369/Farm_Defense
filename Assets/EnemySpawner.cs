using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnTime;
    public float maxSpawnTime;
    public int maxEnemyCount; //Số lượng enemy tối đa
    private float nextSpawnTime;
    private int currentEnemyCount = 0;

    void Start()
    {
        ResetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime && currentEnemyCount < maxEnemyCount)
        { //Kiểm tra xem số lượng enemy đã đạt tối đa chưa
            SpawnEnemy();
            ResetNextSpawnTime();
        }
    }

    void ResetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position + Vector3.back, Quaternion.identity);
        currentEnemyCount++; //Tăng giá trị biến currentEnemyCount
    }
}
