using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameMenuLogic : MonoBehaviour
{
    public GameObject confirmation;
    public GameObject container;
    public GameObject character;
    public GameObject popup;

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
    public void OnClickCharacter()
    {
        if (!StoragePrefs.GetEquipItem("characterMenu").Equals("characterMenu"))
        {
            GameObject clone = Instantiate(popup);
            clone.GetComponentInChildren<TextMeshProUGUI>().text = "YOU NEED TO UNLOCK CHARACTER FIRST!";
            Destroy(clone, 5f);
            return;
        }

        container.SetActive(true);
        character.SetActive(true);
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
        Scorer.score = 0;
        Scorer.currentMaxHeight = 0;
        Input.ResetInputAxes();

    }

    public void OnClickShop()
    {
        SceneManager.LoadScene(3);
    }
    bool isRunning;

    public void OnClickQuit()
    {
        GameObject confirm = Instantiate(confirmation);
        confirm.GetComponentInChildren<confirmation>().title = "Are you sure you want to quit the game?";
        confirm.GetComponentInChildren<confirmation>().negativeDesc = "NO";
        confirm.GetComponentInChildren<confirmation>().positiveDesc = "YES";

        StartCoroutine(isQuit(confirm));
    }

    IEnumerator isQuit(GameObject popup)
    {
        if (isRunning) yield return null;

        isRunning = true;
        bool isQuits = popup.GetComponent<confirmation>().getIsPositive;
        if (!popup.activeInHierarchy) yield return null;

        if (isQuits)
            Application.Quit();
        else
            StartCoroutine(isQuit(popup));

        yield return new WaitForSeconds(0.1f);
        isRunning = false;
    }


}
