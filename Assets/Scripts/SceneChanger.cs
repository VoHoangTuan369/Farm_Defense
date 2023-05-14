using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
