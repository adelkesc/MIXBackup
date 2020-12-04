using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject openHand;
    public GameObject closedHand;
    public bool isLeftHand;

    SphereCollider openHandInteractionSphere;

    bool handOpenBool = true;

    void Start()
    {
        closedHand.GetComponent<Renderer>().enabled = false;
        closedHand.GetComponent<MeshCollider>().enabled = false;

        openHandInteractionSphere = openHand.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if( (isLeftHand == false && Input.GetButton("XRI_Right_GripButton"))    || 
            (isLeftHand == true && Input.GetButton("XRI_Left_GripButton"))      ||  //gets input from left or right hand
            Input.GetMouseButton(1)) //debug
        {
            //handOpenBool = true;
            closedHand.GetComponent<Renderer>().enabled = true;
            closedHand.GetComponent<MeshCollider>().enabled = true;
            openHand.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            closedHand.GetComponent<Renderer>().enabled = false;
            closedHand.GetComponent<MeshCollider>().enabled = false;
            openHand.GetComponent<Renderer>().enabled = true;
        }
        /*
        if (!handOpenBool)
        {
            closedHand.GetComponent<Renderer>().enabled = true;
            closedHand.GetComponent<MeshCollider>().enabled = true;
            openHand.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            closedHand.GetComponent<Renderer>().enabled = false;
            closedHand.GetComponent<MeshCollider>().enabled = false;
            openHand.GetComponent<Renderer>().enabled = true;
        }   */
    }
}
