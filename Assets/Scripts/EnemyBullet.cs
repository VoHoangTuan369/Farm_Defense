using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    public float damageAmount;
    public float directionY;
    Rigidbody2D m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = new Vector2(-1, directionY) * speed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fence"))
        {
            Debug.Log("take dame fence");
            // Giảm máu của enemy đi một giá trị nào đó.
            col.gameObject.GetComponent<Fence>().TakeDamage(damageAmount);

            // Hủy đối tượng bullet của bạn.
            Destroy(gameObject);
        }
    }
}
