using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHeroButton : MonoBehaviour
{
    public HeroButton heroButton;
    public string keyHeroButton;
    public GameObject failedPanel;
    public GameObject successedPanel;
    public GameObject tickImage;
    public GameObject paySound;
    private void Start()
    {
        successedPanel.SetActive(false);
        failedPanel.SetActive(false);
        tickImage.SetActive(false);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt(keyHeroButton) == 1)
        {
            tickImage.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void OnClick() 
    {
        if (Money.GetMoney() >= heroButton.price)
        {
            PlayerPrefs.SetInt(keyHeroButton, 1);
            Money.RemoveMoney(heroButton.price);
            Instantiate(paySound);
            successedPanel.SetActive(true);           
        }
        else failedPanel.SetActive(true);
    }
}
