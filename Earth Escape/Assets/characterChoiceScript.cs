using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterChoiceScript : playerPrefScript
{
    public Sprite[] characters;

    public Image charImg;

    private int index;

    private void Start()
    {
        index = getCharacter();
        changeCharacter();
    }

    public void applyBtn()
    {
        setCharacter(index);
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
        charImg.sprite = characters[index];
    }
}
