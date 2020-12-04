using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDespawn : MonoBehaviour
{
    //This script doesn't work for some reason.
    public void CheckPerch(string tapHit, RaycastHit hit)
    {
        Debug.Log("Method Called");
        switch (tapHit)
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

    public void DespawnTimer()
    {
        //StartCoroutine(Despawn());
    }   
    
    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5f);
        //Access GameObject instance from another script to destroy it?
        //May have to move CheckCube method to have access to instances...
    }
}
