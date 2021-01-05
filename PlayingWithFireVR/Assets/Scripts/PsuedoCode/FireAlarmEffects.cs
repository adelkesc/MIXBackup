using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarmEffects : MonoBehaviour //This script would be attached to the Fire Alarm
{
    public ParticleSystem roomSmoke;
    public AudioSource fireAlarm;

    void Start()
    {
        fireAlarm = GetComponent<AudioSource>();
    }
    public void AmbientSmokeStart()
    {
        roomSmoke.Play();
    }

    public void AmbientSmokeStop()
    {
        roomSmoke.Stop();
    }

    public void FireAlarmStart()
    {
        fireAlarm.Play();
    }

    public void FireAlarmStop()
    {
        fireAlarm.Stop();
    }
}
