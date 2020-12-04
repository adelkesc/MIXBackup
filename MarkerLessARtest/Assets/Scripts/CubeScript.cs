using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameObject controller;
    //lb_BirdController birdController;
    //lb_Bird bird;

    Ray ray;
    RaycastHit hit;
    

    // Start is called before the first frame update
    void Start()
    {
        //birdController = GameObject.FindObjectOfType<lb_BirdController>();
        //bird = GameObject.FindObjectOfType<lb_Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                CheckCube();

                //This is supposed to access the resources folder in living birds and instantiate the cardinal.
                /*
                GameObject instance = Instantiate(Resources.Load("lb_cardinalHQ"), transform.position,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                
                GameObject instance = Instantiate(Resources.Load("lb_cardinalHQ"), hit.point,
                    Quaternion.identity) as GameObject;
                */
                //Debug.Log(hit.transform.tag);
            }
        }

    }

    void CheckCube()
    {
        string cubeClicked = hit.transform.tag;
        switch (cubeClicked)
        {
            case "cardinal":
                Debug.Log("red perch");
                GameObject instanceCard = Instantiate(Resources.Load("lb_cardinalHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                break;
            case "goldfinch":
                Debug.Log("yellow perch");
                GameObject instanceFinch = Instantiate(Resources.Load("lb_goldFinchHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                break;
            case "bluejay":
                Debug.Log("blue perch");
                GameObject instanceJay = Instantiate(Resources.Load("lb_blueJayHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                break;
            case "robin":
                Debug.Log("rust red perch");
                GameObject instanceRobin = Instantiate(Resources.Load("lb_robinHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                break;
            case "crow":
                Debug.Log("black perch");
                GameObject instanceCrow = Instantiate(Resources.Load("lb_crowHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                break;
            case "chickadee":
                Debug.Log("gray perch");
                GameObject instanceChick = Instantiate(Resources.Load("lb_chickadeeHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                break;
            case "sparrow":
                Debug.Log("brown perch");
                GameObject instanceSparrow = Instantiate(Resources.Load("lb_sparrowHQ"), hit.point,
                    Quaternion.Euler(0, 180, 0)) as GameObject;
                break;
            default:
                Debug.Log("no cube");
                break;
        }

    }
}
