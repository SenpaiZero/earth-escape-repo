using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class bossTimer : MonoBehaviour
{
    public TextMeshProUGUI bossNameTxt, bossTimerTxt;
    public Image fillTimer, background;
    private float timer, maxTimer;

    public static string setBossName { get; set; }
    public static GameObject bossObj { get; set; }

    void Start()
    {
        
            StartCoroutine(startBossTimer());
        
    }


    IEnumerator startBossTimer()
    {
        fillTimer.rectTransform.localScale = new Vector3(0,0,0);
        background.rectTransform.localScale= new Vector3(0,0,0);
        bossNameTxt.text = "";
        bossTimerTxt.text = "";

        if (setBossName.Equals(hotair()) || setBossName.Equals(ufo()) || setBossName.Equals(sun()))
        {

            yield return new WaitForSeconds(5);

            fillTimer.rectTransform.localScale = new Vector3(1, 1, 1);
            background.rectTransform.localScale = new Vector3(1, 1, 1);
            timer = 30; // 30 seconds
            maxTimer = timer;
            bossNameTxt.text = setBossName;
            bossTimerTxt.text = timer.ToString();
            fillTimer.fillAmount = (timer / maxTimer);

            while (timer > 0)
            {
                yield return new WaitForSeconds(1);
                timer -= 1;
                fillTimer.fillAmount = (timer / maxTimer);
                bossTimerTxt.text = timer.ToString();
                Debug.Log(timer / maxTimer);
            }

            if (setBossName.Equals(hotair()))
            {
                if (playerPrefScript.getBossCount() < 1)
                    playerPrefScript.setBossCount(1);
            }
            else if (setBossName.Equals(ufo()))
            {
                if (playerPrefScript.getBossCount() < 2)
                    playerPrefScript.setBossCount(2);
            }
            else if (setBossName.Equals(sun()))
            {
                if (playerPrefScript.getBossCount() < 3)
                    playerPrefScript.setBossCount(3);
            }

            // Show a success popup
            Debug.Log("Boss timer is 0");
            Destroy(bossObj);
        }
           
    }

    public string hotair()
    {
        return "EVIL HOT AIR BALLOON";
    }

    public string ufo()
    {
        return "INVASIVE UFO";
    }

    public string sun()
    {
        return "ANGRY SUN";
    }
}
