using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class confirmation : MonoBehaviour
{
    public Button negative, positive;
    public string title, negativeDesc, positiveDesc;
    public TextMeshProUGUI titleLbl;


    public static bool isPositive { get; set; }

    private void Start()
    {
        isPositive = false;

        titleLbl.text = title;
        negative.GetComponentInChildren<TextMeshProUGUI>().text = negativeDesc;
        positive.GetComponentInChildren<TextMeshProUGUI>().text = positiveDesc;
    }

    public bool getIsPositive { get { return isPositive; }}
}
