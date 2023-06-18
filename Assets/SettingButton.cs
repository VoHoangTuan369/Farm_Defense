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
            panel.SetActive(false);
            canvasPlay.SetActive(true);
        }
        else
        {
            panel.SetActive(true);
            canvasPlay.SetActive(false);
        }
    }
}
