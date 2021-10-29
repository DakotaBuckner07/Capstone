using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Element element;
    [SerializeField]
    private Suit suit;
    [SerializeField]
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

    public void SetCard(Element e, Suit s, int val)
    {
        element = e;
        suit = s;
        value = val;
    }
}


public enum Suit
{
    Spades,
    Hearts,
    Clubs,
    Diamonds
}

