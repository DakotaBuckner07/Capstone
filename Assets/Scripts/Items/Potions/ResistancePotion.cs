using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistancePotion : Potion
{
    private float duration;
    private bool inUse = false;

    public int Resistance { get => value; }


    public ResistancePotion(Element e, int resist, int time, int price)
    {
        element = e;
        value = resist;
        duration = time;
        this.price = price;
    }

    public void changePotion()
    {
        element = Utilities.GetRandomElement();
    }
    
    public void Use()
    {
        inUse = true;
    }

    private void Update()
    {
        if(inUse)
        {
            duration -= Time.deltaTime;
            if(duration <= 0)
            {
                value = 0;
                inUse = false;
            }
        }
    }
}