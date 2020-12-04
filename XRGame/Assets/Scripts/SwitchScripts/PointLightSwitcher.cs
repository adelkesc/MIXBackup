using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightSwitcher : MonoBehaviour
{
    public GameObject pointLightGroup;

    public void SetPointsToOn()
    {
        pointLightGroup.SetActive(true);
    }
    public void SetPointsToOff()
    {
        pointLightGroup.SetActive(false);
    }
}
