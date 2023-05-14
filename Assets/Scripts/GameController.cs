using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        BackToLevelSceneAfter5seconds();
    }

    public void BackToLevelSceneAfter5seconds() => StartCoroutine(LoadSceneAfterDelay("LevelScene", 5f));

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delayTime)
    {
        // Đợi một khoảng thời gian delayTime 
        yield return new WaitForSeconds(delayTime);

        // Load một scene với tên sceneName
        SceneManager.LoadScene(sceneName);
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
