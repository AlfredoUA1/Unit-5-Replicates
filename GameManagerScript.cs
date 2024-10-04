using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text gameText;
    public float score;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
        timerText = GameObject.Find("Timer Text").GetComponent<TMP_Text>();
        gameText = GameObject.Find("Game Text").GetComponent<TMP_Text>();

        gameText.text = "";

        score = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Timer: " + (int)timer;
        scoreText.text = "Score: " + score;

        if(timer >= 30)
        {
            if(score == 3)
            {
                gameText.text = "You Win!";
                timerText.text = "";
            }
            else
            {
                gameText.text = "You Lose!";
                timerText.text = "";
            }
        }
    }
}
