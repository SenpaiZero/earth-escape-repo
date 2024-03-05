using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TouchPhase = UnityEngine.TouchPhase;

public class gameMenuScript : playerPrefScript
{
    [SerializeField]
    Button troposphere, stratosphere, mesosphere, thermosphere, exosphere;

    void Start()
    {
        troposphere.enabled = true;


        int score = getProfileHighScore();
        Debug.Log("Current highscore: " + score);
        Debug.Log("Boss Count: " + getBossCount());
        troposphere.interactable = true;
        if(score >= 20000)
            stratosphere.interactable= true;
        if(score >= 50000)
            mesosphere.interactable = true;
        if (score >= 85000 && getBossCount() >= 1)
            thermosphere.interactable = true;
        if (score >= 200000 && getBossCount() >= 2)
            exosphere.interactable = true;

    }
    public void openScene(string scene)
    {
        LevelGenerator.mode = scene;
        SceneManager.LoadScene(1);
    }


}
