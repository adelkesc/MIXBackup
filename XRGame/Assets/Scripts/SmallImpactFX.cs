using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallImpactFX : MonoBehaviour
{
    //GameObject[] smallObjects;

    private void Start()
    {
        //smallObjects = GameObject.FindGameObjectsWithTag("Small");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            //Debug.Log("SMALL COLLISION DETECTED!");
            AudioManagerScript.instance.Play("SmallObjectHit");
        }
        /*
        foreach(GameObject sm in smallObjects)
        {
            if (collision.gameObject)
            {
                Debug.Log("SMALL COLLISION DETECTED!");
                AudioManagerScript.instance.Play("SmallObjectHit");
            }
        }
        */
    }
}
