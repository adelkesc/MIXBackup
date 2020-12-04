using UnityEngine;

public class UIcontrols : MonoBehaviour
{
    private FireScenario fireController;

    void Awake()
    {
        fireController = GameObject.FindObjectOfType<FireScenario>();
    }
    public void BeginScenario()
    {
        StartCoroutine(fireController.StartFire());
    }

    public void EndScenario()
    {
        StartCoroutine(fireController.StopFire());
    }
}
