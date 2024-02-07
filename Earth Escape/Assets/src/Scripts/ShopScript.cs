using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

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

    // Update is called once per frame
    void Update()
    {
        
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
            // reduce coins
            coins -= price;
            coinText.GetComponent<TextMeshProUGUI>().text = coins.ToString();
            StoragePrefs.ReduceCoin(price);
            // buy item
            StoragePrefs.BuyItem(name);
            // update UI
            //GameObject item = GameObject.Find(name);
            //item.transform.GetChild(0).gameObject.SetActive(false);
            //item.transform.GetChild(1).gameObject.SetActive(true);
            
        }
    }
   
}


