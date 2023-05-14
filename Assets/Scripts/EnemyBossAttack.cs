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

    int bulletCounter = 0;
    void Update()
    {
        Shoot();
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
                        StartCoroutine(ShootBullets(bullet[i]));
                    }
                    bulletCounter++;
                }
            }
        }
    }
    IEnumerator ShootBullets(GameObject bullet)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(delayBetweenBullets); // Delay để tạo ra viên đạn tiếp theo
        }
    }
}
