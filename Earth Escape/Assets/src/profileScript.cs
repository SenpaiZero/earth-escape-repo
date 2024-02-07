using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class profileScript : playerPrefScript
{
    [SerializeField]
    TextMeshProUGUI currentUser, newUser, menuUser;
    public Button button;
    public void changeUser()
    {
        string user = newUser.text;
        setUsername(user);
        setMenuUser();
        setUserPopup(); 
        
        if (checkReward())
        {
            string lastClaimDateString = getReward();
            DateTime lastClaimDate = DateTime.Parse(lastClaimDateString);
            Debug.Log(lastClaimDate);
            if (DateTime.Today == lastClaimDate)
            {
                button.interactable = false;
                button.GetComponentInChildren<TextMeshProUGUI>().text = "CLAIMED";
            }
            else
            {
                button.interactable = true;
                button.GetComponentInChildren<TextMeshProUGUI>().text = "CLAIM";
            }
        }
        else
        {
            button.interactable = true;
            button.GetComponentInChildren<TextMeshProUGUI>().text = "CLAIM";
        }
    }

    public void setUserPopup()
    {
        if (currentUser != null)
            currentUser.text = "CURRENT USERNAME: " + getUsername();
    }

    void setMenuUser()
    {
        if(menuUser != null)
            menuUser.text = getUsername();
    }
    private void Start()
    {
        setMenuUser();
        setUserPopup();
    }
}
