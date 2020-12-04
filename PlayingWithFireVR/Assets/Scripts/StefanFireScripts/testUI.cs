using UnityEngine;

public class testUI : MonoBehaviour
{
    public bool test = false;
    public bool test2 = false;
    public int test2TimeDelay = 0;  //if you want the pan fire to be toggled after a delay
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            test = false;
            FindObjectOfType<FireScript>().ToggleThePanFire(); //these are the method calls. Everything else in this script is just for testing while the game is running
        }

        if (test2)
        {
            test2 = false;
            FindObjectOfType<FireScript>().TogglePanFireAfterxSeconds(test2TimeDelay);  //these are the method calls. Everything else in this script is just for testing while the game is running
        }
    }
}
