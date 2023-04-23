using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int goldValue;
    private TMP_Text goldText;

    void Start()
    {
        goldText = GetComponent<TMP_Text>();
        UpdateGoldDisplay();
    }

    public void AddGold(int amount)
    {
        goldValue += amount;
        UpdateGoldDisplay();
    }

    public void RemoveGold(int amount)
    {
        goldValue -= amount;
        UpdateGoldDisplay();
    }

    private void UpdateGoldDisplay()
    {
        goldText.text = "" + goldValue;
    }
}
