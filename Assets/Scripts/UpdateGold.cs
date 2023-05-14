using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGold : MonoBehaviour
{
    private Gold gold;

    public int goldValue; // Số vàng của đồng tiền này.
    private void Start()
    {
        // Lấy reference tới đối tượng chứa script Gold.
        gold = FindObjectOfType<Gold>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Gold");
        gold.AddGold(goldValue);
        Destroy(gameObject);
    }
}
