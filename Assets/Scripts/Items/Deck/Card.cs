using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Element element;
    private Suit suit;
    private int value;

    public Element Element { get => element; }
    public Suit Suit { get => suit; }
    public int Value { get => value; }

    public Card(Element e, Suit s, int v)
    {
        element = e;
        suit = s;
        value = v;
    }
}


public enum Suit
{
    Spades,
    Hearts,
    Clubs,
    Diamonds
}

