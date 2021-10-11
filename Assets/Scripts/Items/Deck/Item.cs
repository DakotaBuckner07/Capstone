using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    #region Sprites

    public Sprite armorSprite;
    public Sprite weaponSprite;
    public Sprite potionSprite;
    public Sprite shieldSprite;
    public Sprite crossSwordsSprite;
    public Sprite healSprite;
    public Sprite earthSprite;
    public Sprite airSprite;
    public Sprite fireSprite;
    public Sprite waterSprite;

    #endregion

    public Text priceTxt;
    public Text pointTxt;
    public Image pointImg;
    public Image elementImg;

    protected Element element;
    protected int price;

    public Element Element { get => element; }
    public int Price { get => price; }
}

public class Armor : Item
{
    private int dmgResistance;
    public int Resistance { get => dmgResistance; }

    public Armor(int resist, Element e, int price)
    {
        dmgResistance = resist;
        element = e;
        this.price = price;
    }
}

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

#region Potions
public class Potion : Item
{
    public Color color;
    protected int value;

    public int Value { get => value; }
}

public class HealthPot : Potion
{
    private int multiplier;

    public HealthPot(int multi, int price)
    {
        multiplier = multi;
        this.price = price;
        color = Color.red;
        value = (int)(multiplier * Random.Range(1.0f, 1.5f));
    }

    public int Use()
    {
        return value;
    }
}

public class ResistancePot : Potion
{
    private Element element;
    private int duration;
    private bool inUse = false;

    public Element Element { get => element; }
    public int Resistance { get => value; }
    public int Duration { get => duration; }

    public ResistancePot(Element e, int resist, int time, int price)
    {
        element = e;
        value = resist;
        duration = time;
        this.price = price;
        switch (element)
        {
            case Element.Air:
                color = Color.grey;
                break;
            case Element.Earth:
                color = new Color(1.0f, .4f, .8f);
                break;
            case Element.Water:
                color = Color.blue;
                break;
            case Element.Fire:
                color = new Color(.8f, .4f, .4f);
                break;
        }
    }

    public ResistancePot Use()
    {
        inUse = true;
        return this;
    }

    public void tickDown()
    {
        if(inUse) duration -= 1;
    }
}

public class ElementPot : Potion
{
    private Element element;

    public ElementPot(Element e, int dmg, int price)
    {
        element = e;
        value = dmg;
        this.price = price;
        switch (element)
        {
            case Element.Air:
                color = Color.grey;
                break;
            case Element.Earth:
                color = new Color(1.0f, .4f, .8f);
                break;
            case Element.Water:
                color = Color.blue;
                break;
            case Element.Fire:
                color = new Color(.8f, .4f, .4f);
                break;
        }
    }

    public int Use(Element enemyElement)
    {
        int weak = Utilities.CheckElements(enemyElement, element);
        if (weak == -1) { return value * 2; }
        if (element == enemyElement || weak == 1) return 0;
        return value;
    }
}
#endregion
