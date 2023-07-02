using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHero : MonoBehaviour
{
    private Gold gold;
    private SoundClick soundClick;

    public GameObject oldHero;
    public GameObject newHero;
    public GameObject popupWindow;
    public Hero hero;
    public GameObject sound;
    private void Start()
    {
        gold = FindObjectOfType<Gold>();
        soundClick = FindObjectOfType<SoundClick>();
    }

    public void OnClick()
    {
        if (gold.goldValue >= hero.goldToBuy)
        {
            Destroy(oldHero);
            Instantiate(newHero, oldHero.transform.position, Quaternion.identity);
            GameObject soundInstance = Instantiate(sound);
            Destroy(soundInstance, 1f);
            Destroy(popupWindow, 1f);
            gold.RemoveGold(hero.goldToBuy);
            ObjectClickHandler.isPopupOpen = false;
            soundClick.TurnOnSound();
        }
    }
}
