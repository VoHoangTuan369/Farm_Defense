using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBullet : MonoBehaviour
{
    public float timeToDestroy;
    public float damageAmount;
    public AudioClip soundHit;
    Rigidbody2D m_rb;

    private AudioSource audioSource;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundHit;
        if (audioSource && soundHit)
        {
            audioSource.PlayOneShot(soundHit);
        }
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("take dame");
            // Giảm máu của enemy đi một giá trị nào đó.
            col.gameObject.GetComponent<Health>().TakeDamage(damageAmount);
        }
    }
}
