using UnityEngine;

public class EnableFireExtinguisher : MonoBehaviour
{
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
