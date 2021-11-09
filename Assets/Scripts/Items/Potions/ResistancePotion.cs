using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistancePotion : Potion
{
    private float duration;
    private bool inUse = false;

    public int Resistance { get => value; }
    public float Duration { get => duration; }


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

        value = Utilities.GetRandNumTimesLevel(2, 5);
        duration = Utilities.GetRandNumTimesLevel(5, 10);
        price = (int)(value * Random.Range(1.0f, 2.0f));
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (bought)
        {
            itemText.text = "Type: Resistance" +
                "\nElement: " + element.ToString() +
                "\nResists: " + value;
        }
        else
        {
            itemText.text = "Type: Resistance" +
                "\nElement: " + element.ToString() +
                "\nResists: " + value +
                "\nPrice: " + price;
        }
    }

    public void Use()
    {
        inUse = true;
        Debug.Log("Resistant to " + value + " " + element.ToString() + " for " + duration + " seconds");
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
                Debug.Log("Player is no longer resistant to " + element.ToString());
            }
        }
    }
}