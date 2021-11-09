using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    protected Text itemText;
    protected Element element;
    protected int price;
    protected bool bought = false;

    public Element Element { get => element; }
    public int Price { get => price; }
}

public class Potion : Item
{
    protected int value;

    public int Value { get => value; }
}
