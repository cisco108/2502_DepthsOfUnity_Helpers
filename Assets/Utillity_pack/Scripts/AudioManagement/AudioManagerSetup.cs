using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioManagerSetup", menuName = "AudioManagerSetup", order = 0)]
public class AudioManagerSetup : ScriptableObject
{
    public List<AudioClip> audioClips;
}