using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{
    public Material materialSwap1;
    public Material materialSwap2;

    [SerializeField]
    private MeshRenderer original;
    private bool swapped = false;

    private LightmapSwitcher lightmapSwitcher;
    private FlourescentSwitcher flourescentSwitcher;
    private PointLightSwitcher pointLightSwitcher;
    private AreaLightSwitcher areaLightSwitcher;

    // Start is called before the first frame update
    void Awake()
    {
        lightmapSwitcher = GameObject.FindObjectOfType<LightmapSwitcher>();
        flourescentSwitcher = GameObject.FindObjectOfType<FlourescentSwitcher>();
        pointLightSwitcher = GameObject.FindObjectOfType<PointLightSwitcher>();
        areaLightSwitcher = GameObject.FindObjectOfType<AreaLightSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("XRI_Left_TriggerButton"))
        {
            if (!swapped)
            {
                original.material = materialSwap1;

                lightmapSwitcher.SetToNight();
                flourescentSwitcher.SetToOff();
                pointLightSwitcher.SetPointsToOff();
                areaLightSwitcher.SetAreaToNight();

                swapped = true;
            }
            else if (swapped)
            {
                original.material = materialSwap2;

                lightmapSwitcher.SetToDay();
                flourescentSwitcher.SetToOn();
                pointLightSwitcher.SetPointsToOn();
                areaLightSwitcher.SetAreaToDay();

                swapped = false;
            }
        }
    }
}
