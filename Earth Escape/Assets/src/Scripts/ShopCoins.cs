using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 
public class ShopCoins : MonoBehaviour
{
    public GameObject coinText;
    public static int coins;
  
    // Start is called before the first frame update
    void Start()
    {
        coinText = GameObject.FindGameObjectWithTag("CoinText");
        int _coins = PlayerPrefs.GetInt("coins", 0);
        coinText.GetComponent<TextMeshProUGUI>().text = _coins.ToString();
        coins = _coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
