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
}