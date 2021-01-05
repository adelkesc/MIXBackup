using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherPsuedo : MonoBehaviour
{
    private bool spewing;
    private ExtinguisherEffects extinguisherEffects;

    private void Awake()
    {
        extinguisherEffects = GameObject.FindObjectOfType<ExtinguisherEffects>();
    }

    void Start()
    {
        if (true) //Input.GetButtonDown("XRI_Left_TriggerButton") <-- Use VR controller input
        {
            spewing = !spewing;

            if (spewing)
            {
                extinguisherEffects.ExtinguisherFoamStart();
                extinguisherEffects.ExtinguisherSoundStart();
            }
            else
            {
                extinguisherEffects.ExtinguisherSoundStop();
                extinguisherEffects.ExtinguisherFoamStart();
            }
        }
    }
}
