using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform characterPosition;
    public Text scoreText;
    public static int multiplier = 100;
    public static float currentMaxHeight = 0;
    public static float score = 0;
    public static float addScore { get; set; }
    
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        float posY = characterPosition.position.y;

        if (posY > currentMaxHeight)
        {
            currentMaxHeight = posY;
            if (StoragePrefs.scoreMult <= 0) StoragePrefs.scoreMult = 1;
            score = (currentMaxHeight * (multiplier * StoragePrefs.scoreMult)) + addScore;
            scoreText.text = score.ToString("0");
        } 


    }

  
}
