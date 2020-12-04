using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{
    public SoundScript[] sounds;
    public static AudioManagerScript instance; 

    private void Awake()
    {
        // If this Game Object does not exist, then create it.  Otherwise destroy any duplicates.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        // Ensures that the Game Object will persist between scenes once instantiated.
        DontDestroyOnLoad(gameObject);

        // For each sound in the SoundScript array
        foreach (SoundScript singleSound in sounds)
        {
            // Expose the necessary attributes here.  Nothing here yet though. :(
            singleSound.source = gameObject.AddComponent<AudioSource>();
            singleSound.source.clip = singleSound.clip;
            singleSound.source.volume = singleSound.volume;
            singleSound.source.loop = singleSound.loop;
        }
    }

    public void Play(string name)
    {
        //Goes through the array of SoundScript and finds the sounds by name.
        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound by Name: " + name + "was not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        //Goes through the array of SoundScript and finds the sounds by name.
        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound by Name: " + name + "was not found!");
            return;
        }
        s.source.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        //We can put background music here and it will play from this Game Object.
        Play("Background Music(Calm)"); 
    }
}
