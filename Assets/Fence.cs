using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public float maxHealth; // Máu tối đa của đối tượng.
    private float currentHealth; // Máu hiện tại của đối tượng.

    public GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth; // Thiết lập máu ban đầu.
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Giảm máu của đối tượng.

        if (currentHealth <= 0)
        {
            Die();
            gameOverPanel.SetActive(true);
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
        Destroy(gameObject);
    }
}
