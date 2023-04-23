using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    float shootTimer;

    public float shootDelay;
    
    public GameObject bullet;
    public Transform shootingPoint;
    public int goldToBuy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    public void Shoot() 
    {
        if (bullet && shootingPoint)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Tìm tất cả các enemy trong scene
            foreach (GameObject enemy in enemies)
            {
                Vector3 enemyViewportPosition = Camera.main.WorldToViewportPoint(enemy.transform.position); //Chuyển vị trí của enemy sang viewport position

                if (enemy.activeSelf && enemyViewportPosition.x > 0 && enemyViewportPosition.x < 1 && enemyViewportPosition.y > 0 && enemyViewportPosition.y < 1 && Mathf.Approximately(enemy.transform.position.y, shootingPoint.position.y)) //Kiểm tra xem enemy có nằm trong khu vực viewport của camera hay không và có nằm trên cùng một đường thẳng ngang với hero hay không
                {
                    this.shootTimer += Time.deltaTime;
                    if (this.shootTimer <= this.shootDelay)
                        return;

                    this.shootTimer = 0;
                    Instantiate(bullet, shootingPoint.position, Quaternion.identity);
                    break; // Nếu đã bắn vào một enemy nằm trên màn hình rồi thì thoát khỏi vòng lặp
                }
            }
        }
    }
    private void OnMouseDown()
    {
    }
    private void OnMouseUp()
    {
    }

}
