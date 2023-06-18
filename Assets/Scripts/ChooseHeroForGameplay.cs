using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseHeroForGameplay : MonoBehaviour
{
    public GameObject spawnerPrefab;
    public Transform[] slots;
    public void OnClick() 
    {
        Transform emptySlot = null;

        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0)
            {
                emptySlot = slot;
                break;
            }
        }

        if (emptySlot != null)
        {
            GameObject spawner = Instantiate(spawnerPrefab, emptySlot.position + Vector3.back, emptySlot.rotation);
            spawner.transform.SetParent(emptySlot);
        }
    }
}
