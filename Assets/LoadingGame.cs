using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingGame : MonoBehaviour
{
    public Image loadingBar;

    void Start()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        loadingBar.fillAmount = 0f;

        float timer = 0f;
        while (timer < 5f)
        {
            timer += Time.deltaTime;
            loadingBar.fillAmount = timer / 5f;
            yield return null;
        }
        if (loadingBar.fillAmount >= 1f) 
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("HomeScene");
        }
    }
}
