using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnFX : MonoBehaviour
{
    public ParticleSystem spawnParticle;
    public ParticleSystem despawnParticle;
    public ParticleSystem featherFall;

    public void SpawnFX(Transform transform)
    {
        Instantiate(spawnParticle, transform.position, Quaternion.identity);
    }

    public void DespawnFX(GameObject instance)
    {
        Instantiate(despawnParticle, instance.transform.position, Quaternion.identity);
        ParticleSystem clone = Instantiate(featherFall, instance.transform.position, Quaternion.identity);
        Destroy(clone, 5f);
    }

    public void Hello()
    {
        Debug.Log("Called successful, hello world.");
    }    
}
