using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResistancePotion : Potion
{
    private int duration;
    private bool inUse = false;

    public int Resistance { get => value; }
    public int Duration { get => duration; }

    public ResistancePotion(Element e, int resist, int time, int price)
    {
        element = e;
        value = resist;
        duration = time;
        this.price = price;
    }

    public ResistancePotion Use()
    {
        inUse = true;
        return this;
    }

    public void tickDown()
    {
        if (inUse) duration -= 1;
    }
}