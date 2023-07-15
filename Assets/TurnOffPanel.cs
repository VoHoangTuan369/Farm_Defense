using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPanel : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.activeSelf == true)
        {
            StartCoroutine(ActivePanel());
        }
    }
    IEnumerator ActivePanel() 
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
