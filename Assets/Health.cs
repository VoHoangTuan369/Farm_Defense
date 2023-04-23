using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject goldPrefab;
    public delegate void EnemyDestroyEventHandler();
    public static event EnemyDestroyEventHandler OnEnemyDestroy;

    public float maxHealth; // Máu tối đa của đối tượng.
    private float currentHealth; // Máu hiện tại của đối tượng.
    private GameController gameController;

    void Start()
    {
        currentHealth = maxHealth; // Thiết lập máu ban đầu.
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Giảm máu của đối tượng.

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (OnEnemyDestroy != null)
        {
            OnEnemyDestroy();
        }
        Destroy(gameObject);
        SpawGold();
        gameController.SetTotalDefeatEnemy(gameController.GetTotalDefeatEnemy() + 1);
    }
    private void SpawGold()
    {
        GameObject gold = Instantiate(goldPrefab, this.gameObject.transform.position, Quaternion.identity);
    }
}
