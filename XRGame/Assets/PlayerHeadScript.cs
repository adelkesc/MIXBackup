using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadScript : MonoBehaviour
{

    public GameObject gameOverText;
    public GameObject soundManager;
    public int maxHealth;
    private int health;

    public void playerWin()
    {
        if(health > 0)
        {
            gameOverText.GetComponent<MeshRenderer>().enabled = true; // makes that text visible
            gameOverText.GetComponent<TextMesh>().text = "YOU WIN";
            gameOverText.GetComponent<TextMesh>().color = Color.green;
        }
        
    }

    public int damagePlayer()
    {
        health--;
        return health;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            soundManager.GetComponent<AudioManagerScript>().Stop("Background Music(Calm)");
            gameOverText.GetComponent<MeshRenderer>().enabled = true; // makes that text visible
            gameOverText.GetComponent<AudioSource>().enabled = true;

        }
    }
}
