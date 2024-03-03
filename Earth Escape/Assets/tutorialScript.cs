using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public TextMeshProUGUI msg;
    public Image img;
    public Sprite[] images;
    public string[] messages;
    public TextMeshProUGUI btnTxt;

    private int currentIndex = 0;

    private void Start()
    {
        Time.timeScale = 0f;
        updateInfo();
    }

    public void updateInfo()
    {
        if (currentIndex == (images.Length-1))
            btnTxt.text = "CLOSE";

        img.sprite = images[currentIndex];
        msg.text = messages[currentIndex];
        currentIndex++;

        if (btnTxt.text.Equals("CLOSE"))
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
            return;
        }
    }
}
