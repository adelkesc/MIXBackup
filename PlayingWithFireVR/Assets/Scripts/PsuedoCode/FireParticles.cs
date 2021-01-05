using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticles : MonoBehaviour //This script would be attached to the Pan
{
    public ParticleSystem smokeParticle;
    public ParticleSystem fireParticle;
    public GameObject fireSource;

    private ParticleSystem smokeObject;
    private ParticleSystem fireObject;

    private FireHealth fireHealth;
    private FireAlarmEffects fireAlarm;

    private void Awake()
    {
        fireHealth = GameObject.FindObjectOfType<FireHealth>();
        fireAlarm = GameObject.FindObjectOfType<FireAlarmEffects>();
    }

    public IEnumerator StartFire() //effect of fire starting
    {
        smokeObject = Instantiate(smokeParticle, fireSource.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);

        StartCoroutine(fireHealth.FireHealthRegen());
        fireObject = Instantiate(fireParticle, fireSource.transform.position, Quaternion.identity);

        smokeObject.Stop();
        fireAlarm.FireAlarmStart();
        fireAlarm.AmbientSmokeStart();

        yield return null;
    }

    public IEnumerator StopFire() //effect of fire stopping
    {
        smokeObject.Play();
        fireObject.Stop();
        Destroy(fireObject);

        yield return new WaitForSeconds(3f);
        smokeObject.Stop();
        Destroy(smokeObject);

        fireAlarm.AmbientSmokeStop();
        fireAlarm.FireAlarmStop();

        yield return null;
    }
}
