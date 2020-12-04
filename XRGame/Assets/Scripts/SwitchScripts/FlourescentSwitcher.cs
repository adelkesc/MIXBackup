using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourescentSwitcher : MonoBehaviour
{
    public Material materialSwap1;
    public Material materialSwap2;

    //[SerializeField]
    //private MeshRenderer original; //need to get it at element 1 in the light prefab

    GameObject[] fluorescentLights;
    [SerializeField]
    private MeshRenderer originalMeshes;

    private void Start()
    {
        fluorescentLights = GameObject.FindGameObjectsWithTag("FluorLight");
        Debug.Log("Object Number: " + fluorescentLights.Length);
    }
    public void SetToOn()
    {
        foreach (GameObject l in fluorescentLights)
        {
            originalMeshes = l.GetComponent<MeshRenderer>();
            Material[] materials = originalMeshes.materials;
            materials[1] = materialSwap1;
        }
        //original.material = materialSwap1;
        //originalMeshes.material = materialSwap1;
    }
    public void SetToOff()
    {
        foreach (GameObject l in fluorescentLights)
        {
            originalMeshes = l.GetComponent<MeshRenderer>();
            Material[] materials = originalMeshes.materials;
            materials[1] = materialSwap2;
        }
        //original.material = materialSwap2;
        //originalMeshes.material = materialSwap2;
    }
}
