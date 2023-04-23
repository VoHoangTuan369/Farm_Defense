using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    // Start is called before the first frame update
    float shootTimer;
    float startPosX;
    float startPosY;
    bool isBeingHeld = false;

    public float shootDelay;
    
    public GameObject bullet;
    public Transform shootingPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld == true)
        {            
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
        Shoot();
    }
    public void Shoot() 
    {
        if (bullet && shootingPoint) 
        {
            this.shootTimer += Time.deltaTime;
            if (this.shootTimer <= this.shootDelay) return;
            this.shootTimer = 0;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }
    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
