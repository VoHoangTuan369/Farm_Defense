using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject goldPrefab;
    public delegate void EnemyDestroyEventHandler();
    public static event EnemyDestroyEventHandler OnEnemyDestroy;
    public GameObject animDie;

    public float maxHealth; // Máu tối đa của đối tượng.
    private float currentHealth; // Máu hiện tại của đối tượng.
    private bool isDefeated = false;
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

    public void Poison(float damagePerSecond, float duration)
    {
        StartCoroutine(TakeDamageOverTime(duration, damagePerSecond));
    }

    private IEnumerator TakeDamageOverTime(float duration, float damagePerSecond)
    {
        float timeElapsed = 0;

        // Lấy Renderer component
        Renderer rend = GetComponent<Renderer>();

        while (timeElapsed < duration)
        {
            TakeDamage(damagePerSecond * Time.deltaTime);
            timeElapsed += Time.deltaTime;

            // Thay đổi màu của Enemy khi bị trừ máu
            rend.material.color = Color.green; // hoặc bất kỳ màu nào bạn muốn

            yield return null;
        }

        // Reset lại màu ban đầu của Enemy sau khi hết thời gian trừ máu
        rend.material.color = Color.white;
    }

    void Die()
    {
        if (!isDefeated)
        {
            if (OnEnemyDestroy != null)
            {
                OnEnemyDestroy();
            }
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            isDefeated = true;
            SpawAnimDie();
            SpawGold();         
            gameController.SetTotalDefeatEnemy(gameController.GetTotalDefeatEnemy() + 1);
        }
    }
    private void SpawGold()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 0, -2); // Tạo một vector mới với cùng X,Y như vị trí hiện tại và Z giảm đi 2.
        GameObject gold = Instantiate(goldPrefab, spawnPosition, Quaternion.identity);
    }
    private void SpawAnimDie()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 0, -3);
        GameObject animAlienDie = Instantiate(animDie, spawnPosition, Quaternion.identity);
    }
}
