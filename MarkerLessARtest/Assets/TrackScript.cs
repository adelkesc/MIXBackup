using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _placeablePrefabs;

    private Dictionary<string, GameObject> _spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager _trackedImageManager;

    private void Awake()
    {
        _trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        //pre spawning each placeable prefabs in our array
        foreach (GameObject prefab in _placeablePrefabs)
        {
            var newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            _spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    private void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged += ImageChanged;
    }


    private void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (var trackedImage in eventArgs.removed)
        {
            _spawnedPrefabs[trackedImage.name].SetActive((false));
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        var referenceImageName = trackedImage.referenceImage.name;
        var position = trackedImage.transform.position;

        var prefab = _spawnedPrefabs[referenceImageName];
        prefab.transform.position = position;
        prefab.SetActive((true));

        foreach (var spawnedPrefab in _spawnedPrefabs.Values.Where(spawnedPrefab => spawnedPrefab.name!=referenceImageName))
        {
            spawnedPrefab.SetActive((false));
        }
    }
    
    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }
}
