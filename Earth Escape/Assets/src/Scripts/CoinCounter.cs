using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public static int coinCount = 0;
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        if (coinText == null)
        {
            coinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();
            
        }
        coinText.text = StoragePrefs.GetCoin().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
