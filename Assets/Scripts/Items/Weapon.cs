using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private int damage;
    public int Damage { get => damage; }

    public Weapon(int dmg, Element e, int price)
    {
        damage = dmg;
        element = e;
        this.price = price;
    }

    public void changeWeapon()
    {
        damage = Utilities.GetRandNumTimesLevel(1, 5);
        element = Utilities.GetRandomElement();
        this.price = (int)(damage * Random.Range(1.0f, 2.0f));
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (bought)
        {
            itemText.text = "Element: " + element.ToString() +
                "\nDamage: +" + damage;
        }
        else
        {
            itemText.text = "Element: " + element.ToString() +
                "\nDamage: +" + damage + 
                "\nPrice: " + price;
        }
    }
}
