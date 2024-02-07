
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PickUpCoin : MonoBehaviour
{
    public int amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            CoinCounter.coinCount += amount;
            //get tag CoinText
           Text cointCounter = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();

            int parseText = int.Parse(cointCounter.text);
            int newCoin = parseText + amount;
            StoragePrefs.AddCoin(amount);
            cointCounter.text = StoragePrefs.GetCoin().ToString();
            gameObject.SetActive(false);
          


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
  
    }

    IEnumerator ActiveRoutine()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(true);
    }
}
