using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound
{
    //Reference to audio clip

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)] // range of volume, between 0 and 1
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;


    [HideInInspector]
    public AudioSource source;
}
