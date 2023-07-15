using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fence : MonoBehaviour
{
    public float maxHealth; // Máu tối đa của đối tượng.
    private float currentHealth; // Máu hiện tại của đối tượng.

    public GameObject gameOverPanel;
    public GameController gameController;
    public Image hpBar;

    void Start()
    {
        currentHealth = maxHealth; // Thiết lập máu ban đầu.
        hpBar.fillAmount = 1f; // Set fill amount to 1 at start
    }

    public void TakeDamage(float damageAmount)
    {
        if (PlayerPrefs.GetInt("PauseGame", 0) == 1)
        {
        }
        else
        {
            currentHealth -= damageAmount; // Giảm máu của đối tượng.
            hpBar.fillAmount = currentHealth / maxHealth; // Update fill amount

            if (currentHealth <= 0)
            {
                Die();
                gameOverPanel.SetActive(true);
            }
        }
    }

    void Die()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            Destroy(enemySpawner.gameObject);
        }

        Hero[] heroes = FindObjectsOfType<Hero>();
        foreach (Hero hero in heroes)
        {
            Destroy(hero.gameObject);
        }
        gameController.gameEnded = true;
        gameController.BackToLevelSceneAfter5seconds();
        Destroy(gameObject);
    }
}
