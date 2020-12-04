using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private GameObject spawnedController;
    
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            // NOTE DEVICE NAME MUST MATCH 3D MODEL NAME FOR CONTROLLER FOR THIS TO WORK
            GameObject prefab = controllerPrefabs.Find(
                controller => controller.name == targetDevice.name);
            //instantiating and storing as a child of our current hand
            spawnedController = Instantiate(prefab, transform);
        }
        else
        {
            Debug.LogError("Did not find hand controller model");
        }
        // // writing all devices into device list
        // InputDevices.GetDevices(devices);
        // foreach (var device in devices)
        // {
        //     // what to do with each device
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // LEFT HAND
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue)
            && primaryButtonValue)
            Debug.Log("Pressing left hand primary button");
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) &&
            triggerValue > 0.1f)
            Debug.Log("Left hand trigger button value: " + triggerValue);
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axis2DValue) &&
            axis2DValue != Vector2.zero)
            Debug.Log("Left hand touch pad " + axis2DValue);
    }
}