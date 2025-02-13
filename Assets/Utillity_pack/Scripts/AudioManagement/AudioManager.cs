using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioLocation
{
    PlayerLocation, //default value!
    ChandelierLocation,
    EndLocation,
    PaintingLocation,
    DrawerPoemLocation,
    WelcomeLocation
}

public class AudioManager : Singleton<AudioManager>
{
    // [Header("Static located AudioSources")]
    [SerializeField] private AudioSource welcomeLocation;
    [SerializeField] private AudioSource poemDrawer;
    [SerializeField] private AudioSource chandelier;
    [SerializeField] private AudioSource painting;
    [SerializeField] private AudioSource endLocation;

    [Header("Audio Assets")] [SerializeField]
    private AudioAsset[] audioAssets;

    private Dictionary<SoundName, AudioAsset> _audioAssets = new();


    private void Start()
    {
        foreach (var o in audioAssets)
        {
            var key = o.key;
            _audioAssets.Add(key, o);
        }
    }

    public void ImpulseSound(SoundName soundName, AudioLocation location = default)
    {
        var audioSource = SelectAudioSource(location);
        audioSource.loop = false;
        audioSource.clip = SelectClip(soundName);
        audioSource.Play();
    }

    public void LoopingSound(SoundName soundName, AudioLocation location = default)
    {
        var audioSource = SelectAudioSource(location);
        audioSource.clip = SelectClip(soundName);
        audioSource.loop = true;
        audioSource.Play();
    }

    public void LoopingSoundControlledStop(SoundName soundName, out AudioSource selectedAs,
        AudioLocation location = default)
    {
        var audioSource = SelectAudioSource(location);
        audioSource.clip = SelectClip(soundName);
        audioSource.loop = true;
        audioSource.Play();
        selectedAs = audioSource;
    }

    public void DurationSound(SoundName soundName, float duration, AudioLocation location = default)
    {
        AudioSource selectedAudioSource;
        LoopingSoundControlledStop(soundName, out selectedAudioSource, location);
        StartCoroutine(StopSoundAfterDuration(selectedAudioSource, duration));
    }

    private AudioSource SelectAudioSource(AudioLocation location)
    {
        return location switch
        {
            AudioLocation.ChandelierLocation => chandelier,
            AudioLocation.EndLocation => endLocation,
            AudioLocation.WelcomeLocation => welcomeLocation,
            AudioLocation.PaintingLocation => painting,
            AudioLocation.DrawerPoemLocation => poemDrawer,
            _ => poemDrawer
        };
    }

    private AudioClip SelectClip(SoundName soundName)
    {
        return _audioAssets[soundName].audioClip;
    }

    private IEnumerator StopSoundAfterDuration(AudioSource audioSource, float duration)
    {
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
    }
}