using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHero : MonoBehaviour
{
    private Gold gold;

    public GameObject oldHero;
    public GameObject newHero;
    public GameObject popupWindow;
    public Hero hero;
    private void Start()
    {
        gold = FindObjectOfType<Gold>();
    }

    public void OnClick()
    {
        if (gold.goldValue >= hero.goldToBuy)
        {
            Destroy(oldHero);
            Instantiate(newHero, oldHero.transform.position, Quaternion.identity);
            Destroy(popupWindow);
            gold.RemoveGold(hero.goldToBuy);
        }
    }
}
