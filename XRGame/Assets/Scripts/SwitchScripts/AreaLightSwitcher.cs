using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLightSwitcher : MonoBehaviour
{
    public GameObject areaLightSet1;
    public GameObject areaLightSet2;

    public void SetAreaToDay()
    {
        areaLightSet1.SetActive(true);
        areaLightSet2.SetActive(false);
    }
    public void SetAreaToNight()
    {
        areaLightSet1.SetActive(false);
        areaLightSet2.SetActive(true);
    }
}
