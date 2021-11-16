using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    protected Text itemText;
    protected Element element;
    protected int price;
    [SerializeField]
    protected bool bought = true;

    public bool isBought { get => bought; }
    public Element Element { get => element; }
    public int Price { get => price; }

    public void BuyItem()
    {
        bought = true;
        UpdateUI();
    }

    public abstract void UpdateUI();
}

public abstract class Potion : Item
{
    [SerializeField]
    protected int value;

    public int Value { get => value; }
}
