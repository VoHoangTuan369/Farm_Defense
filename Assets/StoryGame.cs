using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGame : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("UnlockGame", 0) == 1) 
        {
            gameObject.SetActive(false);
        }
        else StartCoroutine(Story());
    }

    IEnumerator Story() 
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("UnlockGame", 1);
    }
}
