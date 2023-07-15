using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reward : MonoBehaviour
{
    private TMP_Text moneyText;
    public GameController gameController;
    void Start()
    {
        moneyText = GetComponent<TMP_Text>();
        UpdateMoneyDisplay();
    }

    private void UpdateMoneyDisplay()
    {
        moneyText.text = "" + gameController.GetMoneyText();
    }
}
