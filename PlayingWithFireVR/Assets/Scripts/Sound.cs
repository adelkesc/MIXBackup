using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    public bool loop;

    [Range(0f, 256f)]
    public float priority;
    [Range(0f, 1f)]
    public float spatialBlend;
    [Space]
    public float minDistance;
    [Space]
    public float maxDistance = 500;

    [HideInInspector]
    public AudioSource source;

}
