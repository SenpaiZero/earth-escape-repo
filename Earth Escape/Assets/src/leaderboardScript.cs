using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class leaderboardScript : playerPrefScript
{
    [SerializeField]
    GameObject[] rows;
    void Start()
    {
        string[] usernames = getLeaderboardName();
        float[] scores = getLeaderboardScore();

        for (int i = 0; i < rows.Length; i++)
        {
            TextMeshProUGUI[] txt = rows[i].GetComponentsInChildren<TextMeshProUGUI>();
            txt[0].text = usernames[i];
            if (scores[i] <= 0)
                txt[1].text = "";
            else
                txt[1].text = scores[i].ToString("0");
        }
    }

}
