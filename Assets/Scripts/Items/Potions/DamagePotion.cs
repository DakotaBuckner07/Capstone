using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : Potion
{   
    public DamagePotion(Element e, int dmg, int price)
    {
        element = e;
        value = dmg;
        this.price = price;
    }

    public void changePotion()
    {
        element = Utilities.GetRandomElement();

        value = Utilities.GetRandNumTimesLevel(4, 13);
        price = (int)(value * Random.Range(1.0f, 2.0f));
    }

    public void UpdateUI()
    {
        if (bought)
        {
            itemText.text = "Type: Damage" +
                "\nElement: " + element.ToString() +
                "\nDamage: " + value;
        }
        else
        {
            itemText.text = "Type: Resistance" +
                "\nElement: " + element.ToString() +
                "\nDamage: " + value +
                "\nPrice: " + price;
        }
    }

    public int Use(Element enemyElement)
    {
        int weak = Utilities.CheckElements(enemyElement, element);
        if (weak == -1) { return value * 2; }
        if (element == enemyElement || weak == 1) return 0;
        return value;
    }
}

