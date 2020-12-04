using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public bool spewing;

    public void toggle()
    {
        spewing = !spewing;

        if (spewing)
        {
            enableTheExtinguisher();
        }
        else
        {
            disableTheExtinguisher();
        }
    }

    private void disableTheExtinguisher()
    {
        GetComponentInChildren<ParticleSystem>().Stop();

        GetComponent<AudioSource>().Stop();
    }
    private void enableTheExtinguisher()
    {
        GetComponentInChildren<ParticleSystem>().Play();

        GetComponent<AudioSource>().Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (spewing)
        {
            enableTheExtinguisher();
        }
        else
        {
            disableTheExtinguisher();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
