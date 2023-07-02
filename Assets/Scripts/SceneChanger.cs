using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public void OnClick()
    {
        PlayerPrefs.DeleteKey("PauseGame");
        SceneManager.LoadScene(sceneName);
    }
}
