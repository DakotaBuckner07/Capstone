using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shield : Item
{
    private int dmgResistance;
    public int Resistance { get => dmgResistance; }

    public Shield(int resist, Element e, int price)
    {
        dmgResistance = resist;
        element = e;
        this.price = price;
    }

    public void changeShield()
    {
        dmgResistance = Utilities.GetRandNumTimesLevel(1, 5);
        element = Utilities.GetRandomElement();
        this.price = (int)(dmgResistance * Random.Range(1.0f, 2.0f));
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (bought)
        {
            itemText.text = "Element: " + element.ToString() +
                "\nProtection: +" + dmgResistance;
        }
        else
        {
            itemText.text = "Element: " + element.ToString() +
                "\nProtection: +" + dmgResistance +
                "\nPrice: " + price;
        }
    }
}