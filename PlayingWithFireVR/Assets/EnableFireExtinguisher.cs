using UnityEngine;

public class EnableFireExtinguisher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExtinguishAll"))
            other.gameObject.GetComponent<FireExtinguisher>().toggle();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ExtinguishAll"))
            other.gameObject.GetComponent<FireExtinguisher>().toggle();
    }
}
