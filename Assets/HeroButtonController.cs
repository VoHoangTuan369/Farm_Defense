using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroButtonController : MonoBehaviour
{
    public Button[] heroButtons; //Tham chiếu tới button level 2

    void Start()
    {
        if (PlayerPrefs.GetInt("FireUnlocked", 0) == 1)
        {
            heroButtons[1].interactable = true;
        }
        else
        {
            heroButtons[1].interactable = false;
        }
        if (PlayerPrefs.GetInt("IceUnlocked", 0) == 1)
        {
            heroButtons[2].interactable = true;
        }
        else
        {
            heroButtons[2].interactable = false;
        }
        if (PlayerPrefs.GetInt("ThunderUnlocked", 0) == 1)
        {
            heroButtons[3].interactable = true;
        }
        else
        {
            heroButtons[3].interactable = false;
        }
        if (PlayerPrefs.GetInt("PoisonUnlocked", 0) == 1)
        {
            heroButtons[4].interactable = true;
        }
        else
        {
            heroButtons[4].interactable = false;
        }
        if (PlayerPrefs.GetInt("AKUnlocked", 0) == 1)
        {
            heroButtons[5].interactable = true;
        }
        else
        {
            heroButtons[5].interactable = false;
        }
    }
}
