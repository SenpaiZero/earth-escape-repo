using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrefScript : MonoBehaviour
{
    static void save() { PlayerPrefs.Save(); }
    public static void setUsername(string user)
    {
        PlayerPrefs.SetString("username", user.ToUpper());
        save();
    }

    public static string getUsername()
    {
        return PlayerPrefs.GetString("username", "USERNAME");
    }

    public static void setProfileHighScore(int score)
    {
        PlayerPrefs.SetInt(getUsername() + "_Score", score);
        save();
    }

    public static int getProfileHighScore()
    {
        Debug.Log(getUsername());
        return PlayerPrefs.GetInt(getUsername() + "_Score", 0);
    }

    public static void setLeaderboard(float newScore, string newName)
    {
        float[] list = getLeaderboardScore();
        string[] nameList = getLeaderboardName();

        for (int i = 0; i < list.Length; i++)
        {
            if (newScore > list[i])
            {
                for (int j = list.Length - 1; j > i; j--)
                {
                    list[j] = list[j - 1];
                    nameList[j] = nameList[j - 1];
                }

                list[i] = newScore;
                nameList[i] = newName;

                for (int j = 0; j < list.Length; j++)
                {
                    PlayerPrefs.SetFloat("lbScore" + j, list[j]);
                    PlayerPrefs.SetString("lbName" + j, nameList[j]);
                }

                save();
                return; 
            }
        }
        save();
    }

    public static float[] getLeaderboardScore()
    {
        float[] list = new float[10];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = PlayerPrefs.GetFloat("lbScore"+i, 0);
        }

        return list;
    }

    public static string[] getLeaderboardName()
    {
        string[] list = new string[10];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = PlayerPrefs.GetString("lbName" + i, "");
        }

        return list;
    }

    public static void setReward()
    {
        PlayerPrefs.SetString(getUsername() + "_reward", DateTime.Today.ToString());
        save();
    }

    public static string getReward()
    {
        return PlayerPrefs.GetString(getUsername() + "_reward");
    }

    public static bool checkReward()
    {
        return PlayerPrefs.HasKey(getUsername() + "_reward");
    }

    public static void setCharacter(int index)
    {
        PlayerPrefs.SetInt(getUsername() + "_char", index);
        save();
    }

    public static int getCharacter()
    {
        Debug.Log(PlayerPrefs.GetInt(getUsername() + "_char", 0));
        return PlayerPrefs.GetInt(getUsername() + "_char", 0);
    }

    public static void setBossCount(int count)
    {
        PlayerPrefs.SetInt(getUsername() + "_bossCount", count);
        save();
    }

    public static int getBossCount()
    {
        return PlayerPrefs.GetInt(getUsername() + "_bossCount", 0);
    }
}
