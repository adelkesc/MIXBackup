using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumImpactFX : MonoBehaviour
{
    // && collision.gameObject.tag != "Floor"
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject && collision.gameObject.tag != "Floor")
        {
            //Debug.Log("MEDIUM COLLISION DETECTED!");
            AudioManagerScript.instance.Play("MediumObjectHit");
        }
    }
}
