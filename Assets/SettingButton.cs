using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject canvasPlay;
    void Start()
    {
        panel.SetActive(false);
    }
    public void OnClick()
    {
        if (panel.activeSelf)
        {
            PlayerPrefs.DeleteKey("PauseGame");
            panel.SetActive(false);
            if (canvasPlay)
            {
                canvasPlay.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("PauseGame", 1);
            panel.SetActive(true);
            if (canvasPlay)
            {
                canvasPlay.SetActive(false);
            }
        }
    }
}
