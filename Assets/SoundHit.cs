using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHit : MonoBehaviour
{
    public AudioClip soundHit;
    private AudioSource audioSource;
    // Update is called once per frame
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundHit;
        if (audioSource && soundHit)
        {
            audioSource.PlayOneShot(soundHit);
        }
        Destroy(gameObject, soundHit.length);
    }
}
