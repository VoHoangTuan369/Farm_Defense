using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float targetScale = 1.5f;
    public float duration = 1f;
    public GameObject bombEffect;
    public int goldToBuy;
    public bool isPetrolBomb = false;
    private bool isExploded = false;

    private void Update()
    {
        if (transform.parent != null && isExploded == false)
        {
            StartCoroutine(ScaleOverTime());
            if (isPetrolBomb == false)
            {
                Destroy(gameObject, 1.1f);
            }
            else Destroy(gameObject, 0.1f);
            isExploded = true;
        }
    }

    private IEnumerator ScaleOverTime()
    {
        if (isPetrolBomb == false)
        {
            float time = 0f;
            Vector3 startScale = transform.localScale;

            while (time < duration)
            {
                float t = time / duration;
                transform.localScale = Vector3.Lerp(startScale, startScale * targetScale, t);
                time += Time.deltaTime;
                yield return null;
            }
            transform.localScale = startScale * targetScale;
        }
        Instantiate(bombEffect, this.transform.position, Quaternion.identity);
    }
}
