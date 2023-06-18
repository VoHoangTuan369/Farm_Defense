using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float slowedTime = 0f;
    IEnumerator currentSlowCoroutine;

    private bool isTouchingFence = false;
    private float originalSpeed; // Tốc độ ban đầu của enemy.
    private Animator anim;

    public float speed;
    public float damageAmount;
    public Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalSpeed = speed; // Lưu tốc độ ban đầu của enemy.
    }

    void Update()
    {
        if (isTouchingFence == false)
        {
            // Nếu không bị chậm thì di chuyển với tốc độ ban đầu.
            m_rb.velocity = Vector2.left * speed;
        }
        if (slowedTime <= 0f)
        {
            return;
        }
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
                anim.SetBool("Attack", true);
                StartCoroutine(TakeDamageOverTime(col.gameObject.GetComponent<Fence>(), damageAmount));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fence"))
        {
            Debug.Log("Enemy leaves the fence.");
            anim.SetBool("Attack", false);
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

    public IEnumerator SlowDown(float percent, float duration)
    {
        if (currentSlowCoroutine != null)
        {
            StopCoroutine(currentSlowCoroutine);
        }
        float originalSpeed = speed; // or any other variable representing the speed of the enemy
        slowedTime += duration;
        speed *= (1f - percent);
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
        slowedTime -= duration;
    }
}
