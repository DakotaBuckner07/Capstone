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
}
