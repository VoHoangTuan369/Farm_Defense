using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool gameEnded = false;
    int totalMaxEnemyCount = 0;
    int totalDefeatedEnemies = 0;
    public int finalWaveEnemyAmount;
    public float minSpawnTimeNew;
    public float maxSpawnTimeNew;

    public GameObject winPanel;
    public GameObject warningPanel;
    public string levelUnclocked;
    public int moneyGet;
    private int moneyText = 0;
    public int GetMoneyText() 
    {
        return moneyText;
    }

    public int GetTotalDefeatEnemy()
    {
        return totalDefeatedEnemies;
    }
    public int GetTotalMaxEnemyCount()
    {
        return totalMaxEnemyCount;
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
        if (totalDefeatedEnemies >= finalWaveEnemyAmount && !gameEnded) 
        {
            foreach (EnemySpawner spawner in enemySpawners)
            {
                spawner.minSpawnTime = minSpawnTimeNew;
                spawner.maxSpawnTime = maxSpawnTimeNew;
            }
            warningPanel.SetActive(true);
        }
        if (totalDefeatedEnemies >= totalMaxEnemyCount && !gameEnded)
        {                       
            if (PlayerPrefs.GetInt(levelUnclocked, 0) == 1)
            {
                moneyText = moneyGet / 2;
                Money.AddMoney(moneyGet / 2);
            }
            else
            {
                moneyText = moneyGet;
                Money.AddMoney(moneyGet);
            }
            WinGame();
            gameEnded = true;
        }
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        if (warningPanel.activeSelf == true)
        {
            warningPanel.SetActive(false);
        }       

        PlayerPrefs.SetInt(levelUnclocked, 1);

        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            Destroy(enemySpawner.gameObject);
        }
        //BackToLevelSceneAfter5seconds();
    }
    public void BackToLevelSceneAfter5seconds() => StartCoroutine(LoadSceneAfterDelay("LevelScene", 5f));

    IEnumerator LoadSceneAfterDelay(string sceneName, float delayTime)
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
        else warningPanel.SetActive(false);
    }
}
