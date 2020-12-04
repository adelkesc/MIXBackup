using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeImpactFX : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject && collision.gameObject.tag != "Floor")
        {
            //Debug.Log("LARGE COLLISION DETECTED!");
            AudioManagerScript.instance.Play("LargeObjectHit");
        }
    }
}
