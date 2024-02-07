using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class rewardScript : playerPrefScript
{
    public int rewardAmount = 250;
    public Button button;
    private TextMeshProUGUI text;
    private void Start()
    {
        text = button.GetComponentInChildren<TextMeshProUGUI>();
        if (checkReward())
        {
            string lastClaimDateString = getReward();
            DateTime lastClaimDate = DateTime.Parse(lastClaimDateString);
            if (DateTime.Today == lastClaimDate)
            {
                text.text = "CLAIMED";
                button.interactable = false;
            }
        }
        else
        {
            text.text = "CLAIM";
            button.interactable = true;
        }
    }

    public void ClaimReward()
    {
        setReward();
        StoragePrefs.AddCoin(250);
        text.text = "CLAIMED";
        button.interactable = false;
    }

}
