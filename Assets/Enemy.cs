using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isTouchingFence = false;

    public float speed;
    public float damageAmount;
    Rigidbody2D m_rb;

     // Prefab của đồng vàng
    //public int goldValue = 0;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouchingFence == false) m_rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fence"))
        {
            Debug.Log("Enemy hits the fence.");
            if (!isTouchingFence)
            {
                isTouchingFence = true;
                m_rb.velocity = Vector2.left * 0;
                StartCoroutine(TakeDamageOverTime(col.gameObject.GetComponent<Fence>(), damageAmount));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fence"))
        {
            Debug.Log("Enemy leaves the fence.");
            isTouchingFence = false;
        }
    }
    IEnumerator TakeDamageOverTime(Fence fence, float damagePerSecond)
    {
        while (isTouchingFence == true)
        {
            float damagePerFrame = damagePerSecond * Time.deltaTime;
            fence.TakeDamage(damagePerFrame);
            yield return null;
        }
    }
}
