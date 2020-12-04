using UnityEngine;

public class TestQBE : MonoBehaviour
{
    public bool testFunction;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (testFunction)
        {
            FindObjectOfType<FireExtinguisher>().toggle();
            testFunction = false;
        }
    }
}
