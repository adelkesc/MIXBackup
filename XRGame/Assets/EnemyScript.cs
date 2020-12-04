using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public int maxHealth;
    private int currentHealth;
    public float force;
    public GameObject scoreBoard;
    double savedTime;
    public GameObject head;
    public float maxForce;
    public float maxSpeed;
    public float floatForce;

    private void chasePlayer()
    {
        transform.LookAt(player.transform.position);

        if (Vector3.Distance(transform.position, player.transform.position) >= 0.5f) //if distance between is greater than 
        {

            //transform.position += transform.forward * speed * Time.deltaTime;
            //head.transform.LookAt(player.transform.position);
            if (GetComponent<Rigidbody>().velocity.magnitude <= maxSpeed)
            {
                GetComponent<Rigidbody>().AddForce(transform.forward * force * Time.deltaTime);
            }
            float mass = GetComponent<Rigidbody>().mass;
            GetComponent<Rigidbody>().AddForce(Vector3.up * floatForce * Time.deltaTime * Random.Range(0.9f, 1.1f));
        }
    }

    private void getHurt()
    {
        currentHealth--;
        scoreBoard.GetComponent<Scoreboard>().addScore(50);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MainCamera"))
        {
            if (other.gameObject.GetComponent<PlayerHeadScript>().damagePlayer() <= 0) //if the player is killed, kill the monster. Calling this function reduces the hp of the player by 1
            {
                currentHealth = 0;
            }
            GetComponent<Rigidbody>().AddExplosionForce(force * 5, player.transform.position, 100);//push the monster away from the player

        }
        if (other.gameObject.CompareTag("Bonk"))
        {
            getHurt();
            Destroy(other.gameObject);
            GetComponent<Rigidbody>().AddExplosionForce(force * 2, other.gameObject.transform.position, 100);//push the monster away from the player

        }
        //Debug.Log(other.gameObject.ToString());

    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        savedTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(head);


            player.GetComponentInChildren<PlayerHeadScript>().playerWin();


            Destroy(this,5);
            // do something to tell player he won and killed the baddie I guess
        }
        else
        {
            chasePlayer();
            if(force < maxForce || maxForce <= 0) // if maxSpeed is 0 or less theres no limit
            {

                force += (float)(force * 0.05 * Time.deltaTime); //the boi gets faster
            }
            

            if(savedTime - Time.fixedTime <= -10) // every 10 seconds
            {
                scoreBoard.GetComponent<Scoreboard>().addScore(10); // add 10 to score

                GetComponent<Rigidbody>().AddExplosionForce(force * 2, transform.position - transform.forward * 2, 10);//gets a forward boost

                GetComponent<Rigidbody>().AddExplosionForce(force * 2, transform.position - transform.up * 1.2f, 10);

                savedTime = Time.fixedTime;
            }
        }
    }
}
