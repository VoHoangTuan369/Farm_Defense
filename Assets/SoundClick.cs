using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClick : MonoBehaviour
{
    public GameObject sound;
    public void TurnOnSound() 
    {
        GameObject soundInstance = Instantiate(sound);
        Destroy(soundInstance, 1f);
    }
}
