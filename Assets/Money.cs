using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private static int moneyValue = 0;
    private static TMP_Text moneyText;

    void Start()
    {
        moneyText = GetComponent<TMP_Text>();
        moneyValue = PlayerPrefs.GetInt("MoneyValue");
        UpdateMoneyDisplay();
    }
    public static void SetMoney(int money) 
    {
        moneyValue = money;
    }
    public static int GetMoney() 
    {
        return moneyValue;
    }
    public static void AddMoney(int amount)
    {
        moneyValue += amount;
        UpdateMoneyDisplay();
    }

    public static void RemoveMoney(int amount)
    {
        moneyValue -= amount;
        UpdateMoneyDisplay();
    }

    private static void UpdateMoneyDisplay()
    {
        PlayerPrefs.SetInt("MoneyValue", moneyValue);
        moneyText.text = "" + moneyValue;
    }
}
