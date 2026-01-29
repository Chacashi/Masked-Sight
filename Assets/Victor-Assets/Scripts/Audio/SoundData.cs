using UnityEngine;

public enum SoundType { Music, SFX }

[CreateAssetMenu(menuName = "Audio/Sound")]
public class SoundData : ScriptableObject
{
    public SoundType type;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
    public bool loop;
}
