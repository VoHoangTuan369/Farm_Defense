using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaringPanel : MonoBehaviour
{
    public float startOpacity = 0.5f;
    public float endOpacity = 0.8f;
    public float duration = 2f;

    private Image panelImage;

    private void Start()
    {
        panelImage = GetComponent<Image>();
        StartCoroutine(ChangeOpacityRoutine());
    }

    private IEnumerator ChangeOpacityRoutine()
    {
        Color startColor = panelImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, endOpacity);

        while (true)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                panelImage.color = Color.Lerp(startColor, endColor, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Đảo chiều startColor và endColor để lặp lại từ chế độ opacity cao về opacity thấp
            Color temp = startColor;
            startColor = endColor;
            endColor = temp;
        }
    }
}
