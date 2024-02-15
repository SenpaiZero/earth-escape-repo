using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject confirmation;
    enum Items
    {
        JumpingBoots,
    }

    public GameObject[] items;
    
    public GameObject coinText;
    public static int coins;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GameObject.FindGameObjectWithTag("CoinText");
        int _coins = StoragePrefs.GetCoin();
        coinText.GetComponent<TextMeshProUGUI>().text = _coins.ToString();
        coins = _coins;

        
    }

    
    public void OnBuyItem(string priceAndName)
    {
        // split price and name
        string[] priceAndNameArray = priceAndName.Split(',');

        int price = int.Parse(priceAndNameArray[0]);
        string name = priceAndNameArray[1];

        // check if player has enough coins
        if (coins >= price)
        {
            GameObject confirm = Instantiate(confirmation);
            confirm.GetComponentInChildren<confirmation>().title = "Are you sure you want to buy the item?";
            confirm.GetComponentInChildren<confirmation>().negativeDesc = "NO";
            confirm.GetComponentInChildren<confirmation>().positiveDesc = "YES";

            StartCoroutine(isBuy(confirm, price));

        }
    }

    bool isRunning;
    IEnumerator isBuy(GameObject popup, int price)
    {
        if (isRunning) yield return null;

        isRunning = true;
        bool isBuys = popup.GetComponent<confirmation>().getIsPositive;
        if (!popup.activeInHierarchy) yield return null;

        if (isBuys)
        {
            // reduce coins
            coins -= price;
            coinText.GetComponent<TextMeshProUGUI>().text = coins.ToString();
            StoragePrefs.ReduceCoin(price);
            // buy item
            StoragePrefs.BuyItem(name);
        }
        else
        {
            StartCoroutine(isBuy(popup, price));
        }

        yield return new WaitForSeconds(0.1f);
        isRunning = false;
    }

}


