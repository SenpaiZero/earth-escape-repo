using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameMenuLogic : MonoBehaviour
{
    private void Start()
    {
        if (playerPrefScript.getUsername().Replace("\u200B", "").Equals("ADMIN"))
        {
            if (StoragePrefs.GetCoin() >= 100000) return;
            // for debugging purpose only
            playerPrefScript.setProfileHighScore(500000);
            playerPrefScript.setLeaderboard(500000, playerPrefScript.getUsername());
            StoragePrefs.AddCoin(500000);

            Debug.Log("Admin debug activated");
        }

    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
        Scorer.currentMaxHeight = 0;
        Input.ResetInputAxes();
    }

    public void OnClickShop()
    {
        SceneManager.LoadScene(3);
    }
    public void OnClickQuit()
    {
        Application.Quit();
        
    }


}
