using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject[] mapGame;
    public GameObject[] setUpGame;
    public Transform[] slots;
    public void OnClick()
    {
        bool allSlotsHaveChild = true;
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0)
            {
                allSlotsHaveChild = false;
                break;
            }
        }

        if (allSlotsHaveChild)
        {
            foreach (GameObject obj in mapGame)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in setUpGame)
            {
                obj.SetActive(false);
            }
        }
    }
}
