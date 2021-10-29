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
    }

    public int Use()
    {
        return value;
    }
}