using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoragePrefs : playerPrefScript{

    public static int coinMult { get; set; }
    public static int scoreMult { get; set; }
    public static void AddCoin(int coin)
    {

        int coins = PlayerPrefs.GetInt(getUsername() + "_coins");

        if (coinMult <= 0) coinMult = 1;
        coins += Mathf.Abs(coin * coinMult);
        PlayerPrefs.SetInt(getUsername() + "_coins", coins);
        PlayerPrefs.Save();
    }

    public static int GetCoin()
    {
       return PlayerPrefs.GetInt(getUsername() + "_coins");
    }

    public static bool ReduceCoin(int coin)
    {
        int coins = PlayerPrefs.GetInt(getUsername() + "_coins");
        if (coins > 0)
        {
            coins -= coin;
            PlayerPrefs.SetInt(getUsername() + "_coins", coins);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }

    public static void BuyItem(string name)
    {
        PlayerPrefs.SetInt(getUsername() + name, 1);
    }

    public static bool IsItemSold(string name)
    {
        return PlayerPrefs.GetInt(getUsername() + name, 0) == 1;
    }

    
    public static string GetEquipItem(string name)
    {
        return PlayerPrefs.GetString(getUsername() + "_equipItem_" + name, null);
    }

    public static void EquipItem(string name)
    {
        PlayerPrefs.SetString(getUsername() + "_equipItem_" + name, name);
        PlayerPrefs.Save();
    }
    

}
