﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private EnemyMovement movement;
    private EnemyFX enemyEffect;

    public float damage = 10.0f;
    public float range = 100.0f;
    RaycastHit hit;

    private void Awake()
    {
        movement = GameObject.FindObjectOfType<EnemyMovement>();
        enemyEffect = GameObject.FindObjectOfType<EnemyFX>();
    }

    public bool FoundPlayer()
    {
        Debug.DrawRay(transform.position, transform.forward * -50, Color.red);
        if (!Physics.Raycast(transform.position, transform.forward * -1, out hit, range))
        {
            return false;
        }
        return hit.transform.name == "Player";
    }

    public IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);
        while (FoundPlayer())
        {
            Debug.Log("Is Called.");
            enemyEffect.ShotsFired();
            PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();
            player.TakeDamage(damage);
            yield return new WaitForSeconds(2f);
        }
        StartCoroutine(movement.Search());
    }

}