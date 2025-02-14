using UnityEngine;

public class AudioComponent : MonoBehaviour
{
    [SerializeField] private SoundName soundClip;
    [SerializeField] private AudioLocation soundLocation;
    [SerializeField] private float secondsDelay;

    public void PlaySoundDelayedFromButton()
    {
        Invoke(nameof(PlayDelayed), secondsDelay);
    }
    public void PlaySoundDelayedFromToggle(bool toggleVal)
    {
        if (!toggleVal)
        {
            Debug.Log($"toggled to {toggleVal}");
            return;
        }

        Invoke(nameof(PlayDelayed), secondsDelay);
    }

    private void PlayDelayed()
    {
        AudioManager.Instance.ImpulseSound(soundClip, soundLocation);
    }

}