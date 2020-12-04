using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public TextMeshPro scoreboard;
    private int score=0;
    // Start is called before the first frame update
    public void addScore(int score)
    {
        this.score += score;
        scoreboard.text = "" + this.score;
    }
    void Start()
    {
        scoreboard.text = "doot";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
