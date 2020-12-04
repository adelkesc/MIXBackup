using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFX : MonoBehaviour
{
    public ParticleSystem shootParticle;
    public GameObject enemyGun;

    public void ShotsFired()
    {
        Instantiate(shootParticle, enemyGun.transform.position, Quaternion.identity);
    }
}
