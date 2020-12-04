using UnityEngine;


[ExecuteInEditMode]
public class ProperFloor : MonoBehaviour
{
    public int size = 0;
    public GameObject floorSample;

    public float gridSpacingOffset;
    private float spacingWithSize;

    public int sizeX;
    public int sizeY;

    private int floorPieces = 0;

    private GameObject[] floor;

    public bool run = false;
    public bool reset = false;

    private void spawnGrid()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Vector3 spawnPosition = new Vector3(x * spacingWithSize, 0, y * spacingWithSize) + transform.position;
                PickAndSpawn(spawnPosition, transform.rotation);
            }
        }
    }

    private void PickAndSpawn(Vector3 spawnPosition, Quaternion identity)
    {
        GameObject clone = Instantiate(floorSample, spawnPosition, identity);
        floor[floorPieces] = clone;

        floorPieces++;
    }

    private void deletePreviousFloors()
    {
        for (int i = 0; i < floor.Length; i++)
        {
            DestroyImmediate(floor[i]);
        }
    }

    void Awake()
    {
    }

    private void runScript()
    {
        floorPieces = 0;
        deletePreviousFloors();

        spacingWithSize = gridSpacingOffset;

        spacingWithSize += floorSample.GetComponent<MeshRenderer>().bounds.size.x;

        spawnGrid();
    }

    private void resetArray()
    {
        floor = new GameObject[100];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            run = false;
            runScript();
        }

        if (reset)
        {
            reset = false;
            resetArray();
        }
    }
}
