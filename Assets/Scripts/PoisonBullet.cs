using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Health enemy = col.gameObject.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.Poison(damageAmount, 2f);
            }
            Enemy ene = col.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                ene.StartCoroutine(ene.SlowDown(0.3f, 1f));
            }

            // Hủy đối tượng bullet của bạn.
            Destroy(gameObject);
        }
    }
}
