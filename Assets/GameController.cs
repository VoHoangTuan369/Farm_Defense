using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool gameEnded = false;
    int totalMaxEnemyCount = 0;
    int totalDefeatedEnemies = 0;

    public GameObject winPanel;

    public int GetTotalDefeatEnemy()
    {
        return totalDefeatedEnemies;
    }
    public void SetTotalDefeatEnemy(int value)
    {
        totalDefeatedEnemies = value;
    }

    public EnemySpawner[] enemySpawners; // Biến chứa mảng các EnemySpawner

    void Start()
    {
        enemySpawners = FindObjectsOfType<EnemySpawner>();

        // Cập nhật totalMaxEnemyCount
        foreach (EnemySpawner spawner in enemySpawners)
        {
            totalMaxEnemyCount += spawner.maxEnemyCount;
        }
    }

    public void EnemyDefeated()
    {
        if (totalDefeatedEnemies >= totalMaxEnemyCount && !gameEnded)
        {
            WinGame();
            gameEnded = true;
        }
    }

    public void WinGame()
    {
        winPanel.SetActive(true);

        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            Destroy(enemySpawner.gameObject);
        }
    }

    void Update()
    {
        // Kiểm tra xem trò chơi đã kết thúc chưa
        if (!gameEnded)
        {
            EnemyDefeated();
        }
    }
}
