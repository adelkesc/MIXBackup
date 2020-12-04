using System.Collections;
using UnityEngine;

public class FireScenario : MonoBehaviour
{
    public ParticleSystem smokeParticle;
    //public ParticleSystem fireParticle;
    public GameObject fireSource;

    private ParticleSystem smokeObject;
    //private ParticleSystem fireObject;

    public IEnumerator StartFire()  //can only start the fire if it is stopped
    {
        smokeObject = Instantiate(smokeParticle, fireSource.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        //fireObject = Instantiate(fireParticle, fireSource.transform.position, Quaternion.identity);

        FindObjectOfType<FireScript>().StartPanFire();

        smokeObject.Stop();
        Destroy(smokeObject);
    }
    public IEnumerator StopFire() // can only stop if the fire is already started
    {
        //fireObject.Stop();
        //Destroy(fireObject);
        FindObjectOfType<FireScript>().StopPanFire();
        yield return null;
    }
}
