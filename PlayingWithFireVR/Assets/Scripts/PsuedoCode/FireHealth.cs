using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHealth : MonoBehaviour //This script would be attached to the Pan
{
    [SerializeField]
    private float startFireHealth = 5;
    [SerializeField]
    private float currentFireHealth = 0;
    [SerializeField]
    private float fireHealthRegen = 10;
    private bool fireTookDamage = false;
    private int damageNumberPerParticle;
    private int numberOfParticleCollisions = 0;

    private FireParticles fireParticles;

    private void Awake()
    {
        fireParticles = GameObject.FindObjectOfType<FireParticles>();
    }

    void Start()
    {
        currentFireHealth = startFireHealth;
    }

    void Update()
    {
        if (fireTookDamage) // stop regen coroutine
        {
            StopCoroutine(FireHealthRegen());
            currentFireHealth -= damageNumberPerParticle * numberOfParticleCollisions * Time.deltaTime;
            fireTookDamage = false;
            numberOfParticleCollisions = 0;

            if (currentFireHealth <= 0)
            {
                StartCoroutine(fireParticles.StopFire());
            }
        }
        else
        {
            StartCoroutine(FireHealthRegen());
        }
    }

    public IEnumerator FireHealthRegen()
    {
        while (currentFireHealth < startFireHealth && currentFireHealth != 0)
        {
            currentFireHealth += Time.deltaTime * fireHealthRegen;
        }
        yield return null;
    }

    private void OnParticleCollision(GameObject other) // particles of fire extiguisher hit the pan particles
    {
        if (other.CompareTag("ExtinguishAll"))
        {
            fireTookDamage = true;
            numberOfParticleCollisions++;
        }
    }
}
