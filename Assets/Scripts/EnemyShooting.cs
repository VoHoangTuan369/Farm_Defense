using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    float shootTimer;

    public float shootDelay;
    public int bulletCount;
    public float delayBetweenBullets;

    public GameObject bullet;
    public Transform shootingPoint;
    public AudioClip soundAttack;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundAttack;
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("PauseGame", 0) == 1)
        {
        }
        else
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (bullet && shootingPoint)
        {
            this.shootTimer += Time.deltaTime;

            // Kiểm tra xem đã hết thời gian delay giữa các lần bắn hay chưa
            if (this.shootTimer <= this.shootDelay)
                return;

            this.shootTimer = 0;
            StartCoroutine(ShootBullets());
        }
    }
    IEnumerator ShootBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            if (audioSource && soundAttack)
            {
                audioSource.PlayOneShot(soundAttack);
            }
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(delayBetweenBullets); // Delay để tạo ra viên đạn tiếp theo
        }
    }
}
