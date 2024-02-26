using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ShopButton : MonoBehaviour
{
    public GameObject confirmation;
    public string itemName;
    public int itemPrice;
    public GameObject coinText;
    // Start is called before the first frame update
    void Start()
    {
        // get the Button Text
        var tmp = GetComponentInChildren<TextMeshProUGUI>();

        if(itemName == StoragePrefs.GetEquipItem("JumpingBoots"))
        {
            tmp.text = "Equipped";
            // interactable button
            gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
            return;
        }
        if (itemName == StoragePrefs.GetEquipItem("characterMenu"))
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
            GameObject confirm = Instantiate(confirmation);
            confirm.GetComponentInChildren<confirmation>().title = "Are you sure you want to buy the item?";
            confirm.GetComponentInChildren<confirmation>().negativeDesc = "NO";
            confirm.GetComponentInChildren<confirmation>().positiveDesc = "YES";

            StartCoroutine(isBuy(confirm, price, tmp, coins));

        }
    }

    bool isRunning;
    IEnumerator isBuy(GameObject popup, int price, TextMeshProUGUI tmp, int coins)
    {
        if (isRunning) yield return null;

        isRunning = true;
        bool isBuys = popup.GetComponent<confirmation>().getIsPositive;
        if (!popup.activeInHierarchy) yield return null;

        if (isBuys)
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
        else
        {
            StartCoroutine(isBuy(popup, price, tmp, coins));
        }

        yield return new WaitForSeconds(0.1f);
        isRunning = false;
    }
}
