using System;
using UnityEngine;

public enum SoundName
{
    ChandelierAudio,
    DrawerPoemAudio,
    EndAudio,
    PaintingAudio,
    WelcomeAudio
}

[Serializable]
public class AudioAsset
{
    [Header("Key")] public SoundName key;

    [Header("Sound")] public AudioClip audioClip;
}

[Serializable]
public class FeedbackAsset
{
    [Header("Key")] public SoundName key;

    // [Range(0, 1)] public float intensity;
    // public float hapticDuration;
}