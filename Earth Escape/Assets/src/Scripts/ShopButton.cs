using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour
{

    public string itemName;
    public int itemPrice;
    public GameObject coinText;
    // Start is called before the first frame update
    void Start()
    {
        // get the Button Text
        var tmp = GetComponentInChildren<TextMeshProUGUI>();

        if(itemName == StoragePrefs.GetEquipItem())
        {
            tmp.text = "Equipped";
            // interactable button
            gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;

            return;
        }
        // if already purchased set text to Equip
        if (StoragePrefs.IsItemSold(itemName))
        {
            tmp.text = "Equip";
        }
        else
        {
            tmp.text = "Buy";
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBuyItem(string priceAndName)
    {
        var tmp = GetComponentInChildren<TextMeshProUGUI>();
        string[] priceAndNameArray = priceAndName.Split(',');
        string name = priceAndNameArray[1];
        int coins = StoragePrefs.GetCoin();
       
        if(tmp.text == "Equipped")
        {
            return;
        }
        int price = int.Parse(priceAndNameArray[0]);
        if (tmp.text == "Equip")
        {
            StoragePrefs.EquipItem(name);
            tmp.text = "Equipped";
            gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
            return;
        }
        // split price and name

       
       
     
       
        // check if player has enough coins
        if (coins >= price)
        {
            // reduce coins
            coins -= price;
            coinText = GameObject.FindGameObjectWithTag("CoinText");
            coinText.GetComponent<TextMeshProUGUI>().text = coins.ToString();
            StoragePrefs.ReduceCoin(price);
            // buy item
            StoragePrefs.BuyItem(name);
            // update UI
           
            tmp.text = "Equip";
        }
    }
}
