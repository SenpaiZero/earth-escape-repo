using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class characterChoiceScript : playerPrefScript
{
    public Sprite[] characters;

    public Image charImg;

    private int index;
    public TextMeshProUGUI applyBtnTxt;
    public GameObject insuMoney;

    private void Start()
    {
        index = getCharacter();
        changeCharacter();
    }

    bool checkBought()
    {
        Debug.Log("Index: " + index);
        if(index == 0)
            return true;

        if(getCharacterBuy(index) == 1)
            return true;
        return false;
    }
    void popupBuy()
    {
        int coins = StoragePrefs.GetCoin();
        if(coins >= 500)
        {
            setCharacterBuy(index);
            applyBtnTxt.text = "APPLY";
            return;
        }
        GameObject clone = Instantiate(insuMoney);
        if(clone != null)
            Destroy(clone, 5f);
    }
    public void applyBtn()
    {
        if(applyBtnTxt.text.Equals("500 COINS"))
            popupBuy();
        else
        {
            setCharacter(index);
            applyBtnTxt.SetText("EQUIPPED");
        }
    }

    public void nextBtn()
    {
        index++;
        if (index >= characters.Length)
        {
            index = 0;
        }
        changeCharacter();
    }

    public void prevBtn()
    {
        index--;
        if (index < 0)
        {
            index = characters.Length-1;
        }

        changeCharacter();
    }

    void changeCharacter()
    {
        if (!checkBought())
            applyBtnTxt.SetText("500 COINS");
        else
            applyBtnTxt.SetText("APPLY");

        if (getCharacter() == index)
            applyBtnTxt.SetText("EQUIPPED");
        charImg.sprite = characters[index];
    }
}
