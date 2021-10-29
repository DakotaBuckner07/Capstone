using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{ 
    public Text priceTxt;
    public Text pointTxt;
    public Image elementImg;

    protected Element element;
    protected int price;

    public Element Element { get => element; }
    public int Price { get => price; }
}

public class Potion : Item
{
    protected int value;

    public int Value { get => value; }
}
