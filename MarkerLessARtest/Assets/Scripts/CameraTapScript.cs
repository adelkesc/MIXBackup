using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTapScript : MonoBehaviour
{
    //BirdDespawn birdData;
    BirdSpawnFX effects;
    Ray ray;
    RaycastHit hit;
    

    // Start is called before the first frame update
    void Awake()
    {
        //birdData = FindObjectOfType<BirdDespawn>();
        effects = FindObjectOfType<BirdSpawnFX>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {

            if (Input.GetButtonDown("Fire1"))
            {
                CheckPerch();
                Debug.Log(hit.transform);
                //string tap = hit.transform.tag;
                //birdData.CheckPerch(tap, hit);

                //This is supposed to access the resources folder in living birds and instantiate the cardinal.
                /*
                GameObject instance = Instantiate(Resources.Load("lb_cardinalHQ"), transform.position,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                
                GameObject instance = Instantiate(Resources.Load("lb_cardinalHQ"), hit.point,
                    Quaternion.identity) as GameObject;
                */

            }
        }

    }

    void CheckPerch()
    {
        string cubeClicked = hit.transform.tag;
        switch (cubeClicked)
        {
            case "cardinal":
                effects.SpawnFX(hit.transform);
                GameObject instanceCard = Instantiate(Resources.Load("lb_cardinalHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                StartCoroutine(Despawn(instanceCard));
                break;
            case "goldfinch":
                Debug.Log("yellow perch");
                GameObject instanceFinch = Instantiate(Resources.Load("lb_goldFinchHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                StartCoroutine(Despawn(instanceFinch));
                break;
            case "bluejay":
                Debug.Log("blue perch");
                GameObject instanceJay = Instantiate(Resources.Load("lb_blueJayHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                StartCoroutine(Despawn(instanceJay));
                break;
            case "robin":
                Debug.Log("rust red perch");
                GameObject instanceRobin = Instantiate(Resources.Load("lb_robinHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                StartCoroutine(Despawn(instanceRobin));
                break;
            case "crow":
                Debug.Log("black perch");
                GameObject instanceCrow = Instantiate(Resources.Load("lb_crowHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                StartCoroutine(Despawn(instanceCrow));
                break;
            case "chickadee":
                Debug.Log("gray perch");
                GameObject instanceChick = Instantiate(Resources.Load("lb_chickadeeHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                StartCoroutine(Despawn(instanceChick));
                break;
            case "sparrow":
                Debug.Log("brown perch");
                GameObject instanceSparrow = Instantiate(Resources.Load("lb_sparrowHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                StartCoroutine(Despawn(instanceSparrow));
                break;
            default:
                Debug.Log("no cube");
                break;
        }

    }

    private IEnumerator Despawn(GameObject instance)
    {
        yield return new WaitForSeconds(30f);
        Debug.Log("Destroying " + instance.name);
        effects.DespawnFX(instance);
        Destroy(instance);

    }

}
