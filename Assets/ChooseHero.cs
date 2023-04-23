using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseHero : MonoBehaviour
{
    public GameObject objectToCreate;
    private GameObject currentObject;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Clickable"))
            {
                CreateObject(hit.point);
            }
        }

        if (currentObject != null)
        {
            currentObject.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0) && currentObject != null)
        {
            currentObject = null;
        }
    }

    void CreateObject(Vector3 position)
    {
        GameObject currentObject = Instantiate(objectToCreate, this.gameObject.transform.position, Quaternion.identity);
        currentObject.transform.position = new Vector3(position.x, position.y, 0);
        Debug.Log("Position Z of the instance: " + currentObject.transform.position.z);
    }
}
