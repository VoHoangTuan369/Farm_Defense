using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    public Transform slot;
    public void OnClick()
    {
        Transform child = slot.GetChild(0);
        Destroy(child.gameObject);
    }
}
