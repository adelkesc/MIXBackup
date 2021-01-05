using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherEffects : MonoBehaviour //This script would be attached to the Fire Extinguisher
{
    public ParticleSystem fireExtinguisherFoam;
    public AudioSource fireExtinguisher;

    void Start()
    {
        fireExtinguisher = GetComponent<AudioSource>();
    }

    public void ExtinguisherFoamStart()
    {
        fireExtinguisherFoam.Play();
    }

    public void ExtinguisherFoamStop()
    {
        fireExtinguisherFoam.Stop();
    }

    public void ExtinguisherSoundStart()
    {
        fireExtinguisher.Play();
    }

    public void ExtinguisherSoundStop()
    {
        fireExtinguisher.Stop();
    }
}
