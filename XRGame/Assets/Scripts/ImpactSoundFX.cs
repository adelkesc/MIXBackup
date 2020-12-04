using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSoundFX : MonoBehaviour
{
    GameObject[] throwableObjs;

    // Start is called before the first frame update
    void Start()
    {
        throwableObjs = GameObject.FindGameObjectsWithTag(" ");
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*
        switch(throwableObjs)
        {
            case "LargeObj":
                //call to audio manager
                break;
            case "MediumObj":
                //call to audio manager
                break;
            case "SmallObj":
                //call to audio manager
                break;
            default:
                break;
        }
        */
    }
}
