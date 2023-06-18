using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    public float damageAmount;
    public bool isEggs = true;
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
        m_rb.velocity = Vector2.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Take damage");
            // Giảm máu của enemy đi một giá trị nào đó.
            col.gameObject.GetComponent<Health>().TakeDamage(damageAmount);

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
}
