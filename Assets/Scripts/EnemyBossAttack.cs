using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossAttack : MonoBehaviour
{
    float shootTimer;

    public float shootDelay;
    public int bulletCount;
    public float delayBetweenBullets;

    public GameObject[] bullet;
    public GameObject bulletLaser;
    public Transform shootingPoint;
    public Transform shootingPoint2;
    private Animator anim;

    public AudioClip soundAttack;
    public AudioClip soundLaser;

    private AudioSource audioSource;

    int bulletCounter = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
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
        if (bulletCounter % 2 == 0)
        {
            if (bulletLaser && shootingPoint)
            {
                this.shootTimer += Time.deltaTime;

                // Kiểm tra xem đã hết thời gian delay giữa các lần bắn hay chưa
                if (this.shootTimer <= this.shootDelay)
                    return;

                this.shootTimer = 0;
                anim.SetBool("Shoot", true);
                StartCoroutine(ShootBullets(bulletLaser));
                bulletCounter++;
            }
        }
        else {
            foreach (GameObject b in bullet)
            {
                if (b && shootingPoint)
                {
                    this.shootTimer += Time.deltaTime;

                    // Kiểm tra xem đã hết thời gian delay giữa các lần bắn hay chưa
                    if (this.shootTimer <= this.shootDelay)
                        return;

                    this.shootTimer = 0;
                    // Duyệt qua từng loại đạn và bắn cùng một lúc
                    for (int i = 0; i < bullet.Length; i++)
                    {
                        StartCoroutine(ShootBulletsRocket(bullet[i]));
                    }
                    bulletCounter++;
                }
            }
        }
    }
    IEnumerator ShootBullets(GameObject bullet)
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < bulletCount; i++)
        {
            if (audioSource && soundLaser)
            {
                audioSource.PlayOneShot(soundLaser);
            }
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(delayBetweenBullets); // Delay để tạo ra viên đạn tiếp theo
        }
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Shoot", false);
    }
    IEnumerator ShootBulletsRocket(GameObject bullet)
    {
        anim.SetBool("ShootRocket", true);
        for (int i = 0; i < bulletCount; i++)
        {
            if (audioSource && soundAttack)
            {
                audioSource.PlayOneShot(soundAttack);
            }
            Instantiate(bullet, shootingPoint2.position, Quaternion.identity);
            yield return new WaitForSeconds(delayBetweenBullets); // Delay để tạo ra viên đạn tiếp theo
        }
        anim.SetBool("ShootRocket", false);
    }
}
