using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound singleSound in sounds)
        {
            singleSound.source = gameObject.AddComponent<AudioSource>();
            singleSound.source.clip = singleSound.clip;
            singleSound.source.volume = singleSound.volume;
            singleSound.source.loop = singleSound.loop;
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound by Name: " + name + "was not found!");
            return;
        }
        s.source.Play();
    }
    private void Start()
    {
        Play("Background Music");
    }
}
