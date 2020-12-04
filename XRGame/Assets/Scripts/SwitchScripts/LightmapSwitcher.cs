using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightmapSwitcher : MonoBehaviour
{
    public Texture2D[] Day_dir;
    public Texture2D[] Day_light;
    public Texture2D[] Night_dir;
    public Texture2D[] Night_light;

    private LightmapData[] dayLightMaps;
    private LightmapData[] nightLightMaps;

    // Start is called before the first frame update
    void Start()
    {
        if ((Day_dir.Length != Day_light.Length) || (Night_dir.Length != Night_light.Length))
        {
            Debug.Log("In order for LightMapSwitcher to work, the Near and Far LightMap lists must be of equal length");
            return;
        }

        // Sort the Day and Night arrays in numerical order, so you can just blindly drag and drop them into the inspector
        Day_dir = Day_dir.OrderBy(t2d => t2d.name, new SortComparer<string>()).ToArray();
        Day_light = Day_light.OrderBy(t2d => t2d.name, new SortComparer<string>()).ToArray();
        Night_dir = Night_dir.OrderBy(t2d => t2d.name, new SortComparer<string>()).ToArray();
        Night_light = Night_light.OrderBy(t2d => t2d.name, new SortComparer<string>()).ToArray();

        // Put them in a LightMapData structure
        dayLightMaps = new LightmapData[Day_dir.Length];
        for (int i = 0; i < Day_dir.Length; i++)
        {
            dayLightMaps[i] = new LightmapData();
            dayLightMaps[i].lightmapDir = Day_dir[i];
            dayLightMaps[i].lightmapColor = Day_light[i];
        }

        nightLightMaps = new LightmapData[Night_dir.Length];
        for (int i = 0; i < Night_dir.Length; i++)
        {
            nightLightMaps[i] = new LightmapData();
            nightLightMaps[i].lightmapDir = Night_dir[i];
            nightLightMaps[i].lightmapColor = Night_light[i];
        }
    }
    public void SetToDay()
    {
        LightmapSettings.lightmaps = dayLightMaps;
    }
    public void SetToNight()
    {
        LightmapSettings.lightmaps = nightLightMaps;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
