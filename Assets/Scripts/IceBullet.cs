using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    public float damageAmount;
    public bool isEggs = true;
    public GameObject hitSound;
    Rigidbody2D m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        if (isEggs)
        {
            m_rb.angularVelocity = (Random.value < 0.5) ? 90f : -90f;
        }
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("PauseGame", 0) == 1)
        {
            m_rb.velocity = Vector2.zero;
        }
        else
        {
            m_rb.velocity = Vector2.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // Giảm máu của enemy đi một giá trị nào đó.
            col.gameObject.GetComponent<Health>().TakeDamage(damageAmount);
            Instantiate(hitSound, this.transform.position, Quaternion.identity);

            // Thay đổi màu của enemy sang màu xanh dương trong vòng 1 giây.
            Renderer enemyRenderer = col.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                // Lưu trữ màu gốc của enemy.
                Color originalColor = enemyRenderer.material.color;

                // Đặt màu xanh dương cho enemy.
                enemyRenderer.material.color = new Color(0, 1, 1);

                // Sử dụng Coroutine để chờ 1 giây rồi khôi phục màu gốc của enemy.
                StartCoroutine(ResetColor(enemyRenderer, originalColor, 1f));
            }

            // Nếu enemy là một instance của class Enemy, gọi hàm coroutine SlowDown để chậm enemy trong thời gian nhất định.
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.StartCoroutine(enemy.SlowDown(0.5f, 1f)); // Chậm 50% trong 3 giây.
            }

            // Hủy đối tượng bullet của bạn.
            Destroy(gameObject);
        }
    }

    private IEnumerator ResetColor(Renderer renderer, Color originalColor, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        renderer.material.color = originalColor;
    }
}
