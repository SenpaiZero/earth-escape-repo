using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverLogic : playerPrefScript
{
    public Text coins;
    public Text score;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        if (coins == null)
        {
            coins = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();
        }

        if (score == null)
        {
            score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        }

        if (highScore == null)
        {
            highScore = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<Text>();
        }
        float score_ = Scorer.score;
        coins.text = StoragePrefs.GetCoin().ToString();
        score.text = score_.ToString("0");
        highScore.text = getProfileHighScore().ToString();

        setLeaderboard(score_, getUsername());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        // change scene to 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Scorer.currentMaxHeight = 0;
    }
}
