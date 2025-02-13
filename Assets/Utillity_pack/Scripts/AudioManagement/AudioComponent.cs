using UnityEngine;

public class AudioComponent : MonoBehaviour
{
    [SerializeField] private SoundName soundClip;
    [SerializeField] private AudioLocation soundLocation;
    [SerializeField] private float secondsDelay;

    public void PlaySoundDelayedFromButton()
    {
        // StartCoroutine(PlayAfterSeconds());
        Invoke(nameof(PlayDelayed), secondsDelay);
    }
    public void PlaySoundDelayedFromToggle(bool toggleVal)
    {
        if (!toggleVal)
        {
            Debug.Log($"toggled to {toggleVal}");
            return;
        }

        // StartCoroutine(PlayAfterSeconds());
        Invoke(nameof(PlayDelayed), secondsDelay);
    }

    private void PlayDelayed()
    {
        AudioManager.Instance.ImpulseSound(soundClip, soundLocation);
    }

    /*
    private IEnumerator PlayAfterSeconds()
    {
        float time = 0;
        while (time < secondsDelay)
        {
            time += Time.deltaTime;
            yield return null;
        }

        AudioManager.Instance.ImpulseSound(soundClip, soundLocation);
    }*/
}