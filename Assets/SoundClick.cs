using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClick : MonoBehaviour
{
    public GameObject sound;
    public void TurnOnSound() 
    {
        Instantiate(sound);
        Destroy(sound, 1f);
    }
}
