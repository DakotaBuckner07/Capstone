using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Potion
{
    private int multiplier;

    public HealthPotion(int multi, int price)
    {
        multiplier = multi;
        this.price = price;
        value = (int)(multiplier * Random.Range(1.0f, 1.5f));
        UpdateUI();
    }

    public void changePotion()
    {
        element = Utilities.GetRandomElement();
        multiplier = Utilities.GetRandNumTimesLevel(10, 15);
        value = (int)(multiplier * Random.Range(1.0f, 1.5f));
        price = (int)(value * Random.Range(1.0f, 2.0f));
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (bought)
        {
            itemText.text = "Type: Health" +
                "\nHeals: " + value + " hp";
        }
        else
        {
            itemText.text = "Type: Health" +
                "\nHeals: " + value + " hp" +
                "\nPrice: " + price;
        }
    }
}