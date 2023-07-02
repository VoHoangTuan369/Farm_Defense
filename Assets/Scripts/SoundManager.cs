using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundId
{
    Click = 0,
    Hit = 1,
    NorAttack = 2,
}

[Serializable]
public class SoundMapper
{
    public SoundId Id;
    public AudioSource Audio;
}

public class SoundManager : SingletonMono<SoundManager>
{
    [SerializeField] private SoundMapper[] _mappers;

    public override void Init()
    {
    }

    public void PlaySound(SoundId id)
    {
        AudioSource audio = GetAudio(id);
        audio.Play();
    }

    private AudioSource GetAudio(SoundId id) => Array.Find(_mappers, x => x.Id == id)?.Audio;
}
