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

    public int Use(Element enemyElement)
    {
        int weak = Utilities.CheckElements(enemyElement, element);
        if (weak == -1) { return value * 2; }
        if (element == enemyElement || weak == 1) return 0;
        return value;
    }
}
