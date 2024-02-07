using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Camera;
    public GameObject Player;
    public GameObject deadPopup;
    public TextMeshProUGUI scoreTxt;
    public GameObject insufficientMoney;
    void Start()
    {
        if (Camera == null)
        {
            Camera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float score = Scorer.score;
        // check if the player is dead
        if (Camera.transform.position.y - 20 > Player.transform.position.y)
        {
            Time.timeScale = 0f;
            //popup
            scoreTxt.text = score.ToString("0");
            deadPopup.SetActive(true);
        }
    }
    public static void dead()
    {

    }

    public void reviveBtn(bool isGiveup)
    {
        float score = Scorer.score;
        if (isGiveup)
        {
            //Highscore
            if (score > playerPrefScript.getProfileHighScore())
            {
                playerPrefScript.setProfileHighScore((int)score);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if(StoragePrefs.GetCoin() >= 100)
            {
                StoragePrefs.ReduceCoin(100);
                Player.transform.position = new Vector2(0, Camera.transform.position.y+10);
                deadPopup.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                //popup unsuficient
                GameObject obj = (GameObject) Instantiate(insufficientMoney);
                Destroy(obj, 3.0f);
            }
        }
    }
}
