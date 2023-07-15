using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOffButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject canvasPlay;
    public void OnClick() 
    {
        PlayerPrefs.DeleteKey("PauseGame");
        panel.SetActive(false);
        HeroInforButton.isPanelOpen = false;
        if (canvasPlay)
        {
            canvasPlay.SetActive(true);
        }
    }
}
