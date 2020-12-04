using UnityEngine;

public class FireScript : MonoBehaviour
{

    public int fireHealth;              // the fire system has health. This way it will kinda reignite if left alone. Currently just the sound of the fire is dying down as the health goes down, but I guess the particles themselves could be limited to give a cool effect. Oh well
    private float currentHealth;        /* current health of the fire. Self explanatory */
    public int fireRegenRate;           // the regen rate of the fire. Don't make it immortal now, or there is no fun
    private bool takenDamage;           // if the fire has recently taken damage. If yes, then the regen is paused for one tick.
    public int damageNumberPerParticle; // how much damage the fire takes on collision with one 
    private int particlesHit = 0;       // how many fire extinguishing particles hit the fire between updates. I didn't have problems with how the interaction behaves, but I think it's a good idea to have this in case it's running on a slower machine
    private ParticleSystem[] particleSystems;       // this array will be filled with all the particle systems that are added to the root of this script. In this case the pan.

    public ParticleSystem externalSmoke;            // a particle system that is not parented to the fire. Could be parented and then just moved somewhere else, but I feel like it's better this way

    public GameObject fireAlarm;                    // the fire alarm object. It's referenced here to interact with the sound it makes. Should change this to be handled by the sound manager.

    public bool enabledOnStart = false;             // if the fires are enabled on start. 

    public bool test = false;      //I use this bool to kill/revive the fire from the editor while in game. Won't/can't be used in game


    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("ExtinguishAll"))  // here is where we check the tag for whatever is coliding with the game object. We could have different types of fire extinguishers, and different interactions depending on what was used
        {
            //Debug.Log("Works");
            takenDamage = true;
            particlesHit++; // counting how many particles hit the game object. On low fps there could be multiple particles hitting it. 

        }
    }

    private void killAllParticles() // self explanatory. Goes trough all the particle systems in the array and murders them in cold blood. Heh, cold. Fire jokes. | also handles the fire alarm and external smoke
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Stop(); //disables any new particles that might be generated
            //Debug.Log(particleSystems[i] + "has been stopped");
        }
        externalSmoke.Stop(); // also stop the external particle system of course
        //fireAlarm.GetComponent<AudioSource>().loop = false; //hm, maybe shouldn't kill the fire alarm instantly. But to be merciful on the ears of the player, it must be done.
        //changed this for immersion =)
        Invoke("StopLoopingFireAlarm", 5);  //stop the loop of the fire alarm after 5 seconds. Unrealistic since a real one would scream forever, but see comment on line 42

    }

    private void startAllParticles() //does what the kill method does but the opposite. | also handles the fire alarm and external smoke
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Play(); //starts all particle effects
            //Debug.Log(particleSystems[i] + "has been started");
        }
        externalSmoke.Play();

        //fireAlarm.GetComponent<AudioSource>().Play(); // gotta change these method calls to call on the audio manager. It's not urgent but would more profesh that way
        //fireAlarm.GetComponent<AudioSource>().loop = true;
        Invoke("StartFireAlarm", 5);        //start the fire alarm after 5 seconds of the fire starting. Yay for immersion
    }
    private void StopLoopingFireAlarm()
    {
        fireAlarm.GetComponent<AudioSource>().loop = false; //stops the looping for the fire alarm. Doing it like this so it doesn't suddenly cut off.
    }

    private void StartFireAlarm()
    {
        fireAlarm.GetComponent<AudioSource>().Play();
        fireAlarm.GetComponent<AudioSource>().loop = true;
        //AudioManager.instance.Play("");
    }

    // Start is called before the first frame update

    public void ToggleThePanFire() // public methods for toggling the pan fire. Using the test boolean I made for simplicity/ time efficiency
    {
        test = true;
    }

    public void TogglePanFireAfterxSeconds(int x)
    {
        if (x > 0)       //don't know what would happen if you invoke with a negative time. Don't wanna know... time travel ?
        {
            Invoke("ToggleThePanFire", x);
        }

        else
            Invoke("ToggleThePanFire", 0);
    }

    public void StartPanFire()
    {
        if (currentHealth <= 0)
        {
            test = true;
        }
    }

    public void StopPanFire()
    {
        if (currentHealth > 0)
        {
            test = true;
        }
    }

    void Start()
    {
        currentHealth = fireHealth;   //set the current health to whatever was chosen in the editor as the hp of the fire
        particleSystems = GetComponentsInChildren<ParticleSystem>(true);  //get all the particle systems that are sired by the root (the object with this script)
        for (int i = 0; i < particleSystems.Length; i++)
        {
            //Debug.Log(particleSystems[i].gameObject.name);
        }
        if (enabledOnStart) //this wont be used except for testing
        {
            startAllParticles();
        }
        else
        {
            killAllParticles();
            currentHealth = -100;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (test) //using the test boolean for toggling the pan fire remotely (from UI). I won't rename it because it started as a test.
        {
            if (currentHealth <= 0)
            {
                currentHealth = 5;
                startAllParticles();
            }

            else
                currentHealth = -100;

            test = false;
        }

        if (takenDamage)
        {
            currentHealth -= damageNumberPerParticle * particlesHit * Time.deltaTime;
            takenDamage = false;
            particlesHit = 0;
        }
        else
        {
            if (currentHealth <= fireHealth)
                currentHealth += fireRegenRate * Time.deltaTime;
        }
        //Debug.Log("Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            //fireRegenRate = 0;    
            takenDamage = true;         //i don't want to change the fire regen rate anymore, because I can revive the fire when needed.
            //Debug.Log("Fire iz ded");
            killAllParticles();         //this might impact performance without a bool. OH WELL
        }

        GetComponent<AudioSource>().volume = currentHealth / 120; // the current max health is 100, and I don't want the fire sound to blast at 100% volume even if the fire is at max health. This way the max volume will be a bit lower
    }
}
