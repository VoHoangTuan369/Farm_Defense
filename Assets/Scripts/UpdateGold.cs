using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGold : MonoBehaviour
{
    private Gold gold;

    public int goldValue; // Số vàng của đồng tiền này.
    public Transform goldPoint;
    public GameObject sound;
    private void Start()
    {
        // Lấy reference tới đối tượng chứa script Gold.
        gold = FindObjectOfType<Gold>();
    }

    private IEnumerator MoveToGoldPoint()
    {
        while (transform.position != goldPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, goldPoint.position, 10f * Time.deltaTime);
            yield return null;
        }
        // Tăng giá trị vàng
        if (transform.position == goldPoint.position)
        {
            gold.AddGold(goldValue);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        GameObject soundInstance = Instantiate(sound);
        Destroy(soundInstance, 1f);
        StartCoroutine(MoveToGoldPoint());
    }
}
